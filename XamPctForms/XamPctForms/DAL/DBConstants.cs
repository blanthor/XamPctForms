using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace XamPctForms.DAL
{
    public static class DBConstants
    {
        public const string DatabaseFilename = "XamPctFormDB.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;
        
        private static string databasePath;
        public static string DatabasePath
        {
            get
            {
                if (databasePath == null)
                {
                    //TODO: Platform-specific paths.
                    //var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var basePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    databasePath = Path.Combine(basePath, DatabaseFilename);
                }
                return databasePath;
            }
        }
    }
}
