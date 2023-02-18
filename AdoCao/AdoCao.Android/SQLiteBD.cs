using AdoCao.Data;
using AdoCao.Droid;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteBD))]
namespace AdoCao.Droid
{
    public class SQLiteBD : ISQLiteBD
    {
        public string SQLiteLocalPath(string bancoDados)
        {
            var path = System.Environment
                .GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, bancoDados);
        }
    }
}