using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1.DATA
{
    public interface DSQLite
    {
        string GetLocalFilePath(string fileName);
        //SQLiteConnection GetConnection();

    }
}
