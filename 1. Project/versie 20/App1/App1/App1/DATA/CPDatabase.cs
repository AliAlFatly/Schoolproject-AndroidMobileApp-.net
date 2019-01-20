using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using App1.Models_data_;
using System.Threading.Tasks;

namespace App1.DATA
{
    public class CPDatabase
    {
        readonly SQLiteAsyncConnection database;
        public CPDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<CP>().Wait();
            //database.CreateTablesAsync<CP, YT>().Wait();
        }

        public Task<List<CP>> GetCPAsync()
        {
            return database.Table<CP>().ToListAsync();
        }

        public Task<CP> GetCPAsync(int Num)
        {
            return database.Table<CP>().Where(i => i.cNum == Num).FirstOrDefaultAsync();
        }

        public Task<int> SaveCPAsync(CP cp)
        {
            if (cp.cNum == 0)
            {
                return database.InsertAsync(cp);
            }
            else
            {
                return database.UpdateAsync(cp);
            }
        }

        public Task<int> DeleteCPAsync(CP cp)
        {

            return database.DeleteAsync(cp);
        }


        //public Task<List<YT>> GetYTAsync()
        //{
        //    return database.Table<YT>().ToListAsync();
        //}

        //public Task<YT> GetYTAsync(int Num)
        //{
        //    return database.Table<YT>().Where(i => i.YTNum == Num).FirstOrDefaultAsync();
        //}

        //public Task<int> SaveYTAsync(YT yt)
        //{
        //    if (yt.YTNum == 0)
        //    {
        //        return database.InsertAsync(yt);
        //    }
        //    else
        //    {
        //        return database.UpdateAsync(yt);
        //    }
        //}

        //public Task<int> DeleteYTAsync(YT yt)
        //{

        //    return database.DeleteAsync(yt);
        //}

    }
}
