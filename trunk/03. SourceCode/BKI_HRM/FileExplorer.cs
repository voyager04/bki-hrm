using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IP.Core.IPCommon;

namespace BKI_HRM
{
    public class FileExplorer
    {
        public string Domain { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DirectoryTo { get; set; }

        public string fileName = "";
        private string directoryFrom = "";
        private string path = "";
        private long timeNow = DateTime.Now.Ticks;

        public FileExplorer(OpenFileDialog fileDialog,
            string domain, 
            string userName, 
            string password,
            string directoryTo)
        {
            Domain = domain;
            UserName = userName;
            Password = password;
            DirectoryTo = directoryTo;

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

        public string UploadFile()
        {
            if (IsExistedFile(this.DirectoryTo + fileName))
            {
                BaseMessages.MsgBox_Infor("Tên file đã tồn tại. Vui lòng đổi tên khác");
                return "";
            }
            //ModifyFileName(directoryFrom, path + fileName);

            //var oNetworkCredential =
            //        new System.Net.NetworkCredential()
            //        {
            //            Domain = this.Domain,
            //            UserName = this.Domain + "\\" + this.UserName,
            //            Password = this.Password
            //        };

            //using (new RemoteAccessHelper.NetworkConnection(@"\\" + this.Domain, oNetworkCredential))
            //{
            //    File.Move(path + fileRenamed,
            //                directoryTo + fileRenamed);
            //}
            File.Move(path + fileName,
                            this.DirectoryTo + fileName);
            return fileName;
        }

        private void ModifyFileName(string from, string to)
        {
            //Coppy file mới
            File.Copy(from, path + "bki" + fileName);
            //Đổi tên file mới
            File.Move(path + "bki" + fileName, to);
        }

        public static void DeleteFile(string path)
        {
            if (IsExistedFile(path))
                File.Delete(path);
        }
    }
}
