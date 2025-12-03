using Microsoft.Maui.Controls;
using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Maui.Storage;

namespace AppMovil
{
    public partial class App : Application
    {
        public App()
        {
            // Log first-chance exceptions to help diagnose initialization failures when debugging
            // Keep first-chance logging extremely lightweight: only write to Debug output.
            // Avoid FileSystem or other platform APIs here because they may not be available
            // very early in app startup and can cause additional exceptions.
            AppDomain.CurrentDomain.FirstChanceException += (s, e) =>
            {
                try
                {
                    var details = $"FirstChanceException: {e.Exception?.GetType()} - {e.Exception?.Message}\n{e.Exception?.StackTrace}";
                    Debug.WriteLine(details);
                }
                catch
                {
                    // Ignore any failures in the handler to avoid masking the original exception
                }
            };

            InitializeComponent();
            MainPage = new ConsultorioShell();
        }
    }
}
