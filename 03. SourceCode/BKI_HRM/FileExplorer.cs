using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IP.Core.IPCommon;

namespace BKI_HRM
{
    public static class FileExplorer
    {
        public static string Domain { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string DirectoryTo { get; set; }

        public static string fileName = "";
        private static string directoryFrom = "";
        private static string path = "";
        private static long timeNow = DateTime.Now.Ticks;

        public static void SelectFile(OpenFileDialog fileDialog)
        {
            fileDialog.Filter = "(*.*)|*.*";
            fileDialog.Multiselect = false;
            fileDialog.Title = "Chọn file";
            DialogResult result = fileDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;
            if (new FileInfo(fileDialog.FileName).Length > 5096000)
            {
                MessageBox.Show("File quá lớn. Vui lòng chọn file có dung lượng < 5Mb",
                                "Cảnh báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
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
            Domain = domain;
            DirectoryTo = directoryTo;

            if (IsExistedFile(DirectoryTo + fileName))
            {
                BaseMessages.MsgBox_Infor("Tên file đã tồn tại. Vui lòng đổi tên khác");
                return "";
            }
            if (fileName != "")
            {
                File.Copy(path + fileName, DirectoryTo + fileName);
            }
            return fileName;
        }

        public static string UploadFile(string domain, string directoryTo, string userName, string password)
        {
            Domain = domain;
            DirectoryTo = directoryTo;
            UserName = userName;
            Password = password;

            if (IsExistedFile(DirectoryTo + fileName))
            {
                BaseMessages.MsgBox_Infor("Tên file đã tồn tại. Vui lòng đổi tên khác");
                return "";
            }
            if (UserName != null)
            {
                var oNetworkCredential =
                        new System.Net.NetworkCredential()
                        {
                            Domain = Domain,
                            UserName = Domain + "\\" + UserName,
                            Password = Password
                        };

                using (new RemoteAccessHelper.NetworkConnection(@"\\" + Domain, oNetworkCredential))
                {
                    File.Copy(path + fileName, DirectoryTo + fileName);
                }
            }
            return fileName;
        }

        public static void DeleteFile(string path)
        {
            if (IsExistedFile(path))
                File.Delete(path);
        }
    }
}
