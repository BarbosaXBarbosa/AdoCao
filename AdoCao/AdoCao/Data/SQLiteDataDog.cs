using AdoCao.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoCao.Data
{
    public class SQLiteDataDog
    {
        readonly SQLiteAsyncConnection _conexaoBD;

        public CachorroData CachorroDataTable { get; set; }

        public SQLiteDataDog(string path)
        {
            _conexaoBD = new SQLiteAsyncConnection(path);

            _conexaoBD.CreateTableAsync<Cachorro>().Wait();

            CachorroDataTable = new CachorroData(_conexaoBD);

        }
    }

}

