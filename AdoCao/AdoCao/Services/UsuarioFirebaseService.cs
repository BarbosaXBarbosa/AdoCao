﻿using AdoCao.Models;
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
    public class UsuarioFirebaseService : FirebaseService
    {
        FirebaseClient _firebaseClient;

        public UsuarioFirebaseService()
        {
            _firebaseClient = new FirebaseClient(urlFirebase);
        }

        public async Task Envia(Usuario usuario)
        {
            try
            {
                //Enviando a entidade para o Firebase
                await _firebaseClient
                    .Child(nameof(Usuario).ToString())
                    .PostAsync(usuario);
            }
            catch (Exception erro)
            {
                //Logo de erros
                Debug.WriteLine(erro);
            }
        }

        public async Task<List<Usuario>> Lista()
        {
            var tabelaUsuario = await _firebaseClient
                .Child(nameof(Usuario).ToString())
                .OnceAsync<Usuario>();
            return tabelaUsuario.Select(usuario => new Usuario
            {
                Key = usuario.Key,
                Id = usuario.Object.Id,
                Nome = usuario.Object.Nome,
                Email = usuario.Object.Email,
                Senha = usuario.Object.Senha,
                CPF = usuario.Object.CPF,
                Confirmasenha = usuario.Object.Confirmasenha,
                Cidade = usuario.Object.Cidade,
                Bairro = usuario.Object.Bairro,
                Rua = usuario.Object.Rua,
                Numero = usuario.Object.Numero,

            }).ToList();

            //Cache local para o SQLite
        }


        //Consulta direta sem o uso de cache local para o SQLite
        public async Task<Usuario> Obtem(Guid id)
        {
            var usuarios = await Lista();
            var usuario = usuarios.FirstOrDefault(e => e.Id == id);
            return usuario;
        }

        public async Task<Usuario> ObtemUsuarioCPFEmail(string cpf, string email)
        {
            var usuarios = await Lista();
            var usuario = usuarios.FirstOrDefault(e => e.CPF == cpf || e.Email == email);
            return usuario;
        }

        public async void AlteraUsuarioId(Guid idU, string NameU, string email , string senha, string csenha, string numeroU, string complementoU, string bairro, string cpf, string cidadeU, byte[] imagemU, string ruaU)
        {
            var usuarioAltera = (await _firebaseClient
              .Child("Usuario")
              .OnceAsync<Usuario>()).Where(a => a.Object.Id == idU).FirstOrDefault();

            await _firebaseClient
              .Child("Usuario")
              .Child(usuarioAltera.Key)
              .PutAsync(new Usuario()
              {
                  Id = idU,
                  Nome = NameU,
                  Email = email,
                  Senha = senha,
                  Confirmasenha = csenha,
                  Bairro = bairro,
                  Complemento = complementoU,
                  CPF = cpf,
                  Cidade = cidadeU,
                  Rua = ruaU,
                  Imagem = imagemU,
                  Numero= numeroU,
              });

        }
    }
}
