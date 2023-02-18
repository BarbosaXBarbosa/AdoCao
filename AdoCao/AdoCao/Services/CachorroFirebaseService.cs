using AdoCao.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoCao.Services
{
    public class CachorroFirebaseService : FirebaseService
    {
        FirebaseClient _firebaseClient;

        public CachorroFirebaseService()
        {
            _firebaseClient = new FirebaseClient(urlFirebase);
        }

        public async Task Envia(Cachorro cachorro)
        {
            try
            {
                await _firebaseClient
                    .Child(nameof(Cachorro).ToString())
                    .PostAsync(cachorro);
            }
            catch (Exception erro)
            {
                Debug.WriteLine(erro);
            }
        }

        public async Task<List<Cachorro>> Lista()
        {
            var tabelaCachorro = await _firebaseClient
                .Child(nameof(Cachorro).ToString())
                .OnceAsync<Cachorro>();
            return tabelaCachorro.Select(cachorro => new Cachorro
            {
                KeyDog = cachorro.Key,
                IdDog = cachorro.Object.IdDog,
                IdDono= cachorro.Object.IdDono,
                NomeDog = cachorro.Object.NomeDog,
                SexoDog = cachorro.Object.SexoDog,
                RacaDog = cachorro.Object.RacaDog,
                RuaDog = cachorro.Object.RuaDog,
                NumeroDog = cachorro.Object.NumeroDog,
                ComplementoDog = cachorro.Object.ComplementoDog,
                CepDog = cachorro.Object.CepDog,
                CidadeDog = cachorro.Object.CidadeDog,
                ImagemDog = cachorro.Object.ImagemDog
            }).ToList();

        }
        public async Task<Cachorro> ObtemCachorroId(Guid idDog)
        {
            var cachorros = await Lista();
            var cachorro = cachorros.FirstOrDefault(e => e.IdDog == idDog);
            return cachorro;
        }
        public async Task<List<Cachorro>> ObtemCachorroPorUsuario(Guid IdDono)
        {
            var cachorros = await Lista();
            var cachorro = cachorros.Where(e => e.IdDono == IdDono).ToList();
            return cachorro;
        }
    }
}
