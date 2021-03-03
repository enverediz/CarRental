using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Core.Utilities.Results;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static(string newPath, string Path2) newPath(IFormFile file) 
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;

            var creatingUniqueFileName = Guid.NewGuid().ToString("N") + "_" + DateTime.Now.Month + "_" 
                + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;

            string path = Environment.CurrentDirectory + @"\wwwroot\CarImages";

            string result = $@"{path}\{creatingUniqueFileName}";

            return (result, $"\\CarImages\\{creatingUniqueFileName}");
        }

        public static string AddAsync(IFormFile file) 
        {
            var result = newPath(file);
            try
            {
                var sourcepath = Path.GetTempFileName();
                if (file.Length>0)
                {
                    using (var stream= new FileStream(sourcepath,FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                File.Move(sourcepath, result.newPath);
            }
            catch (Exception exception)
            {
                return exception.Message;                
            }
            return result.Path2;
        }

        public static string UpdateAsync(string sourcepath,IFormFile file) 
        {
            var result = newPath(file);
            try
            {
                if (sourcepath.Length>0)
                {
                    using (var stream = new FileStream(result.newPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                File.Delete(sourcepath);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return result.Path2;
        }

        public static IResult DeleteAsync(string path)
        {            
            try
            {                
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }
            return new SuccessResult();
        }
    }
}
