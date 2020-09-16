using System.IO;
using XamPctForms.DAL;

//[assembly: Dependency(typeof(XamPctForms.Droid.Services.DatabasePathService))]
namespace XamPctForms.Droid.Services
{
    public class DatabasePathService : IDatabasePathService
    {
        public string GetPath(string DatabaseFileName)
        {
            var basePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string databasePath = Path.Combine(basePath, DatabaseFileName);
            return databasePath;
        }
    }
}