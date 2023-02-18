using AdoCao.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoCao.Data
{
    public class SQLiteData
    {
        //Conexao com o banco de dados
        readonly SQLiteAsyncConnection _conexaoBD;

        //Mapeamento das operacoes das tabelas
        public UsuarioData UsuarioDataTable { get; set; }

        public SQLiteData(string path)
        {
            //Inicializa a conexao com o BD
            _conexaoBD = new SQLiteAsyncConnection(path);

            //Configura as tabelas do banco de dados
            _conexaoBD.CreateTableAsync<Usuario>().Wait();
            //_conexaoBD.CreateTableAsync<NovoObjeto>().Wait();

            //Habilita a operação das tabelas de acordo com as plataformas de S.O
            UsuarioDataTable = new UsuarioData(_conexaoBD);
        }


    }
}
