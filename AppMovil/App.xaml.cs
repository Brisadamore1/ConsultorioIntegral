﻿using AppMovil.Views;

namespace AppMovil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new ProfesionalesView();
        }
    }
}
