//using BusinessLogic.Model;
using QLNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Framework.Extensions;
using System.IO;
using QLNhanSu.Filters;
using EHR.Helper;
using System.Web.Helpers;
//using BusinessLogic.Management;
namespace EHR.Helper
{
    /// <summary>
    /// A class to store the properties of the file:
    /// </summary>
    public class ViewDataUploadFilesResult
    {
        public string name { get; set; }
        public int size { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string delete_url { get; set; }
        public string thumbnail_url { get; set; }
        public string delete_type { get; set; }
    }
    /// <summary>
    /// Upload file 
    /// </summary>
    public class CUploadFile {

        public static List<ViewDataUploadFilesResult> UploadFiles(HttpRequestBase request, string ip_str_urlImage, List<string> ip_lstName)
        {

            if (ip_lstName == null)
            {
                for (int i = 0; i < request.Files.Count; i++)
                {
                    var file = request.Files[i];
                    ip_lstName.Add(file.FileName);
                }
            }
            
            var r = new List<ViewDataUploadFilesResult>();
            foreach (string file in request.Files)
            {
                var statuses = new List<ViewDataUploadFilesResult>();
                var headers = request.Headers;
                if (string.IsNullOrEmpty(headers["X-File-Name"]))
                {
                    UploadWholeFile(request, ip_str_urlImage, ip_lstName, statuses);
                }
                else
                {
                    UploadPartialFile(headers["X-File-Name"], ip_str_urlImage, request, statuses);
                }
                
                var result = statuses;
                
                return result;
            }

            return r;
        }
        /// <summary>
        /// base64 sample Encoder
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string EncodeFile(string fileName)
        {
            return Convert.ToBase64String(System.IO.File.ReadAllBytes(fileName));
        }
        /// <summary>
        /// Returns the physical file path that corresponds to the specified virtual path.
        /// </summary>
        /// <param name="ip_url"></param>
        /// <returns></returns>
        public static string StorageRoot(string ip_url)
        {
            return Path.Combine(System.Web.HttpContext.Current.Server.MapPath(ip_url));
        }
        /// <summary>
        /// // Upload partial file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="ip_urlImg"></param>
        /// <param name="request"></param>
        /// <param name="statuses"></param>
        public static void UploadPartialFile(string fileName,string ip_urlImg, HttpRequestBase request, List<ViewDataUploadFilesResult> statuses)
        {
            if (request.Files.Count != 1) throw new HttpRequestValidationException("Attempt to upload chunked file containing more than one fragment per request");
            var file = request.Files[0];
            var inputStream = file.InputStream;

            var fullName = Path.Combine(StorageRoot(ip_urlImg), Path.GetFileName(fileName));
            using (var fs = new FileStream(fullName, FileMode.Append, FileAccess.Write))
            {
                var buffer = new byte[1024];
                var l = inputStream.Read(buffer, 0, 1024);
                while (l > 0)
                {
                    fs.Write(buffer, 0, l);
                    l = inputStream.Read(buffer, 0, 1024);
                }
                fs.Flush();
                fs.Close();
            }
            statuses.Add(new ViewDataUploadFilesResult()
            {
                name = fileName,
                size = file.ContentLength,
                type = file.ContentType,
                url = ip_urlImg + fileName,
                delete_url = ip_urlImg + fileName,
                thumbnail_url = @"data:image/png;base64," + EncodeFile(fullName),
                delete_type = "GET",
            });
        }
        /// <summary>
        ///  // Upload entire file
        /// </summary>
        /// <param name="request"></param>
        /// <param name="ip_urlImg"></param>
        /// <param name="ip_lstNameImg"></param>
        /// <param name="statuses"></param>
        public static void UploadWholeFile(HttpRequestBase request,string ip_urlImg, List<string> ip_lstNameImg, List<ViewDataUploadFilesResult> statuses)
        {
            for (int i = 0; i < request.Files.Count; i++)
            {
                var file = request.Files[i];
                var fullPath = Path.Combine(StorageRoot(ip_urlImg), Path.GetFileName(ip_lstNameImg[i]));
                file.SaveAs(fullPath);
                statuses.Add(new ViewDataUploadFilesResult()
                {
                    name = ip_lstNameImg[i],
                    size = file.ContentLength,
                    type = file.ContentType,
                    url = ip_urlImg + ip_lstNameImg[i],
                    delete_url = ip_urlImg + ip_lstNameImg[i],
                    thumbnail_url = @"data:image/png;base64," + EncodeFile(fullPath),
                    delete_type = "GET",
                });
                
            }
        }
    }



}