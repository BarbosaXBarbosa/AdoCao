using AdoCao.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdoCao.Data
{
    public class UsuarioData
    {
        private SQLiteAsyncConnection _conexaoBD;

        public UsuarioData(SQLiteAsyncConnection conexaoBD)
        {
            _conexaoBD = conexaoBD;
        }

        public Task<List<Usuario>> ListaUsuarios()
        {
            //Consulta e retorna todos os registro da tabela
            var lista = _conexaoBD
                .Table<Usuario>()
                .ToListAsync();

            return lista;
        }

        public Task<Usuario> ObtemUsuario(Guid id)
        {
            var usuario = _conexaoBD
                .Table<Usuario>()
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
            return usuario;
        }

        public Task<Usuario> ObtemUsuario(string email, string senha)
        {
            var usuario = _conexaoBD
                .Table<Usuario>()
                .Where(e => e.Email == email && e.Senha == senha)
                .FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<int> SalvaUsuario(Usuario usuario)
        {
            var usuarioValido = await ObtemUsuario(usuario.Id);
            if (usuarioValido == null)
            {
                //Faz a inclusao de um novo usuario
                return await _conexaoBD.InsertAsync(usuario);
            }
            else
            {
                //Faz a alteração do usuario
                return await _conexaoBD.UpdateAsync(usuario);
            }
        }

        public async Task<int> ExcluiUsuario(Guid id)
        {
            return await _conexaoBD.DeleteAsync(id);
        }
    }
}
