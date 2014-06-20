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
        public string Password { get; private set; }

        private string directoryFrom = "";
        private string directoryTo = "";
        private string fileName = "";
        private string path = "";
        private long timeNow = DateTime.Now.Ticks;

        public FileExplorer(OpenFileDialog fileDialog,
            string domain, 
            string userName, 
            string password)
        {
            Domain = domain;
            UserName = userName;
            Password = password;

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

        private bool IsExistedFile(string path)
        {
            if (File.Exists(path))
                return true;
            return false;
        }

        public string UploadFile()
        {
            ModifyFileName(directoryFrom, path + timeNow + "-" + fileName);

            var oNetworkCredential =
                    new System.Net.NetworkCredential()
                    {
                        Domain = this.Domain,
                        UserName = this.Domain + "\\" + this.UserName,
                        Password = this.Password
                    };

            using (new RemoteAccessHelper.NetworkConnection(@"\\" + this.Domain, oNetworkCredential))
            {
                File.Move(path + timeNow + "-" + fileName,
                            directoryTo + timeNow + "-" + fileName);
            }
            return fileName;
        }

        private void ModifyFileName(string from, string to)
        {
            //Coppy file mới
            File.Copy(from, path + "bki" + fileName);
            //Đổi tên file mới
            File.Move(path + "bki" + fileName, to);
        }

        public void DeleteFile(string path)
        {
            if (IsExistedFile(directoryFrom))
            {
                File.Delete(path);
                return;
            }
            BaseMessages.MsgBox_Infor("File không tồn tại.");
        }
    }
}
