﻿namespace Lab1_WeChat
{
    internal class SQLiteConnection
    {
        private string connectionString;

        public SQLiteConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Open()
        {
            System.Console.WriteLine(connectionString);
        }
    }
}