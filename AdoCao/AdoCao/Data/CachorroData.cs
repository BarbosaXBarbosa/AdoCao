using AdoCao.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdoCao.Data
{
    public class CachorroData
    {
        private SQLiteAsyncConnection _conexaoBD;

        public CachorroData (SQLiteAsyncConnection conexaoBD)
        {
            _conexaoBD = conexaoBD;
        }

        public Task<List<Cachorro>> ListaCachorros()
        {
            var listaDog = _conexaoBD
                .Table<Cachorro>()
                .ToListAsync();

            return listaDog;
        }

        public Task<Cachorro> ObtemCachorro(Guid idDog)
        {
            var cachorro = _conexaoBD
                .Table<Cachorro>()
                .Where(e => e.IdDog == idDog)
                .FirstOrDefaultAsync();
            return cachorro;
        }

        public Task<Cachorro> ObtemCachorro(string NomeDog, string SexoDog, string RacaDog, string RuaDog, string NumeroDog, string ComplementoDog, string CepDog, string CidadeDog)
        {
            var cachorro = _conexaoBD
                .Table<Cachorro>()
                .Where(e => e.NomeDog == NomeDog && e.SexoDog == SexoDog && e.RacaDog == RacaDog && e.RuaDog == RuaDog && e.NumeroDog == NumeroDog && e.ComplementoDog == ComplementoDog && e.CepDog == CepDog && e.CidadeDog == CidadeDog)
                .FirstOrDefaultAsync();
            return cachorro;
        }

        public async Task<int> SalvaCachorro(Cachorro cachorro)
        {
            var cachorroValido = await ObtemCachorro(cachorro.IdDog);
            if (cachorroValido == null)
            {
                return await _conexaoBD.InsertAsync(cachorro);
            }
            else
            {
                return await _conexaoBD.UpdateAsync(cachorro);
            }
        }

        public async Task<int> ExcluiCachorro(Guid idDog)
        {
            return await _conexaoBD.DeleteAsync(idDog);
        }
    }
}