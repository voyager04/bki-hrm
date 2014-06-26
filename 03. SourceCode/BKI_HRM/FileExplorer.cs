using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using IP.Core.IPCommon;

namespace BKI_HRM
{
    public static class FileExplorer
    {
        public static string DomainName { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string DirectoryTo { get; set; }

        public static string fileName = "";
        private static string directoryFrom = "";
        private static string path = "";

        public static void SelectFile(OpenFileDialog fileDialog, string fileNameOld)
        {
            // Khai báo dialog
            fileDialog.Filter = "(*.*)|*.*";
            fileDialog.Multiselect = false;
            fileDialog.Title = "Chọn file";
            fileDialog.FileName = "";
            DialogResult result = fileDialog.ShowDialog();
            // Nếu bỏ không chọn file nữa, trả về tên file cũ
            if (result != DialogResult.OK)
            {
                fileName = fileNameOld;
                return;
            }
            fileName = fileDialog.SafeFileName;
            directoryFrom = fileDialog.FileName;
            var index = directoryFrom.Trim().LastIndexOf("\\", System.StringComparison.Ordinal);
            path = directoryFrom.Trim().Substring(0, index + 1);
        }

        public static bool IsExistedFile(string path)
        {
            if (File.Exists(path))
                return true;
            return false;
        }

        public static string UploadFile(string domain, string directoryTo)
        {
            DomainName = domain;
            DirectoryTo = directoryTo;
            if (fileName != "")
                File.Copy(path + fileName, DirectoryTo + fileName);
            return fileName;
        }

        public static string UploadFile(string domain, string directoryTo, string userName, string password)
        {
            DomainName = domain;
            DirectoryTo = directoryTo;
            UserName = userName;
            Password = password;

            if (UserName != null)
                using (new RemoteAccessHelper.NetworkConnection(DomainName, new NetworkCredential(UserName, Password, DomainName)))
                    File.Copy(path + fileName, DirectoryTo + fileName);
            return fileName;
        }

        public static void DeleteFile(string path)
        {
            if (IsExistedFile(path))
                File.Delete(path);
        }

        public static void DownloadFile()
        {

        }
    }
}
