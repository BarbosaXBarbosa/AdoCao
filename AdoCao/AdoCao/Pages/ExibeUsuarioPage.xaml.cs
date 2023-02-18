﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdoCao.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExibeUsuarioPage : ContentPage
    {
        public ExibeUsuarioPage()
        {
            InitializeComponent();

            //Obtem o usuario logado
            var usuario = App.Usuario;
            lblNome.Text = usuario.Nome;


        }
    }
}