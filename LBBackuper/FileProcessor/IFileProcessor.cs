﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LBCommon;

namespace LBBackuper
{
    public interface IFileProcessor
    {
        /// <summary>
        /// Copies all files from the source path to the destination one
        /// uses impersonation with configured credentials for source and destination paths
        /// </summary>
        /// <param name="sourcePath">Source path</param>
        /// <param name="sourceUser">User for access to the source path</param>
        /// <param name="destPath">Destination path</param>
        /// <param name="destUser">User for access to the destination path</param>
        void CopyPathWithUserRights(string sourcePath, IUser sourceUser, string destPath, IUser destUser); 
    }
}
