using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using Microsoft.Win32;
using System.IO;

using LBCommon;

namespace LBBackuper
{
    public class FileProcessor : IFileProcessor
    {
        /// <summary>
        /// Copies all files from the source path to the destination one
        /// uses impersonation with configured credentials for source and destination paths
        /// </summary>
        /// <param name="SourceFolder">Source path</param>
        /// <param name="sourceUser">User for access to the source path</param>
        /// <param name="DestFolder">Destination path</param>
        /// <param name="destUser">User for access to the destination path</param>
        public void CopyPathWithUserRights(string SourceFolder, IUserDef sourceUser, string DestFolder, IUserDef destUser)
        {
            RemoteImpersonator.ImpersonateRemoteUser(destUser, DestFolder, delegate() {
                LocalImpersonator.ImpersonateLocalUser(sourceUser, delegate()
                {
                    CopyPath(SourceFolder, DestFolder);
                });
            });
        }

        /// <summary>
        /// Copies all files from the source path to the destination
        /// </summary>
        /// <param name="SourceFolder">Source path</param>
        /// <param name="DestFolder">Destination path</param>
        private void CopyPath(string SourceFolder, string DestFolder)
        {
            SourceFolder = SourceFolder.TrimEnd('\\');
            DestFolder = DestFolder.TrimEnd('\\');
            int fileStartIndex = SourceFolder.Length;
            foreach (string fileName in Directory.EnumerateFiles(SourceFolder, "*", SearchOption.AllDirectories))
            {
                string newFileName = fileName.Substring(fileStartIndex);
                CopyFile(fileName, DestFolder + newFileName);
            }
        }

        /// <summary>
        /// Copies file from the source to the destination
        /// </summary>
        private void CopyFile(string sourceFileName, string destFileName)
        {
            string dir = Path.GetDirectoryName(destFileName);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            File.Copy(sourceFileName, destFileName, true);
        }

    }
}
