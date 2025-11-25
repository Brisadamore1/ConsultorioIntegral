using Firebase.Auth;
using Firebase.Auth.Providers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class IniciarSesionView : Form
    {
        FirebaseAuthClient firebaseAuthClient;

        private int intentos = 0;

        public IniciarSesionView()
        {
            InitializeComponent();
            ConfiguracionFirebase();
        }

        private void ConfiguracionFirebase()
        {
            // Configuración de Firebase con proveedor de autenticación por correo electrónico y anónimo
            var config = new FirebaseAuthConfig
            {
                ApiKey = Service.Properties.Resources.ApiKeyFirebase,
                AuthDomain = Service.Properties.Resources.AuthDomainFirebase,
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()

                },
            };

            firebaseAuthClient = new FirebaseAuthClient(config);
        }


        private void chkVerContraseña_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkVerContraseña.Checked ? '\0' : '*';
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            UserCredential user = null;
            try
            {
                user = await firebaseAuthClient.SignInWithEmailAndPasswordAsync(txtEmail.Text, txtPassword.Text);
                if (user != null)
                {
                    var token = await user.User.GetIdTokenAsync();
                    GenericService<object>.jwtToken = token;
                }
            }
            catch (FirebaseAuthException error)
            {

                MessageBox.Show($"Ha ocurrido un error en la autenticación:{error.Reason}");
                intentos++;
                if (intentos == 3)
                {
                    MessageBox.Show("Se ha superado la cantidad de intentos permitidos, el sistema se cerrará");
                    this.Close();
                }
                return;
            }

            if (user == null)
            {
                MessageBox.Show("Email o password incorrecto, intentelo nuevamente");
                intentos++;
                if (intentos == 3)
                {
                    MessageBox.Show("Se ha superado la cantidad de intentos permitidos, el sistema se cerrará");
                    this.Close();
                }
                return;
            }


            // Login exitoso
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

       
    }
}
