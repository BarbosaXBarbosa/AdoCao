using AdoCao.Data;
using AdoCao.iOS;
using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteBD))]
namespace AdoCao.iOS
{
    public class SQLiteBD : ISQLiteBD
    {
        public string SQLiteLocalPath(string bancoDados)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string pathProtegido = Path.Combine(path, "..", "Library", "Databases");
            if (!Directory.Exists(pathProtegido))
            {
                Directory.CreateDirectory(pathProtegido);
            }
            return Path.Combine(pathProtegido, bancoDados);
        }
    }
}