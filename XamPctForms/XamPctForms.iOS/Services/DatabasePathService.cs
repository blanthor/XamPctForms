using System;
using System.IO;
using XamPctForms.DAL;

namespace XamPctForms.iOS.Services
{
    public class DatabasePathService : IDatabasePathService
    {
        public string GetPath(string fileName)
        {
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library");
            string fullPath = Path.Combine(folderPath, fileName);

            return fullPath;
        }
    }
}