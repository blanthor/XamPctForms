﻿namespace XamPctForms.DAL
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
                    databasePath = App.FilePath;
                }
                return databasePath;
            }
        }
    }
}
