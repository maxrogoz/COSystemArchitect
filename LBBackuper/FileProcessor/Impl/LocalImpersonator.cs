using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;
using System.Runtime.ConstrainedExecution;
using System.Security;

using LBCommon;

namespace LBBackuper
{
    /// <summary>
    /// Class to implement user impersonalization
    // Test harness.
    // If you incorporate this code into a DLL, be sure to demand FullTrust.
    /// [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
    /// </summary>
    public class LocalImpersonator
    {
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
            int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);

        /// <summary>
        /// Impersonate the user and fire delegate with user rights
        /// If user is null then impersonalization will not be done
        /// </summary>
        /// <param name="user">The user whose permissions are used to impersonalization</param>
        /// <param name="user">Delegate, executed in impersonate mode</param>
        public static void ImpersonateLocalUser(IUserDef user, Action impersonateDelegate)
        {
            if (user == null)
            {
                impersonateDelegate();
                return;
            }

            SafeTokenHandle safeTokenHandle;
            string userName = user.Login;
            string domainName = user.Domain;
            string password = user.Password;

            const int LOGON32_PROVIDER_DEFAULT = 0;
            //This parameter causes LogonUser to create a primary token.
            const int LOGON32_LOGON_INTERACTIVE = 2;

            // Call LogonUser to obtain a handle to an access token.
            bool returnValue = LogonUser(userName, domainName, password,
                LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT,
                out safeTokenHandle);


            if (false == returnValue)
            {
                int ret = Marshal.GetLastWin32Error();
                throw new UnauthorizedAccessException(String.Format("LogonUser failed with error code : {0}", ret));
            }
            using (safeTokenHandle)
            {
                // Use the token handle returned by LogonUser.
                WindowsIdentity newId = new WindowsIdentity(safeTokenHandle.DangerousGetHandle());
                using (WindowsImpersonationContext impersonatedUser = newId.Impersonate())
                {
                    impersonateDelegate();
                }
            }
        }
    }

    public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeTokenHandle()
            : base(true)
        {
        }

        [DllImport("kernel32.dll")]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr handle);

        protected override bool ReleaseHandle()
        {
            return CloseHandle(handle);
        }
    }
}
