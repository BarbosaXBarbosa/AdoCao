using AdoCao.Data;
using AdoCao.UWP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteBD))]
namespace AdoCao.UWP
{
    public class SQLiteBD : ISQLiteBD
    {
        public string SQLiteLocalPath(string bancoDados)
        {
            string path = ApplicationData.Current.LocalFolder.Path;
            return Path.Combine(path, bancoDados);
        }
    }
}
