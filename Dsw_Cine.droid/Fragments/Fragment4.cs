using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SupportFragment = Android.Support.V4.App.Fragment;
using Dsw_Cine.portable;

namespace Dsw_Cine.droid.Fragments
{
    public class Fragment4 : SupportFragment
    {
        EditText txtdni;
        EditText txtnombre;
        EditText txtEmail;
        EditText txtTele_F;
        EditText txtTele_C;

        Button botonregistrar;

        Services controller = new Services();
        Android.App.ProgressDialog progress;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment1, container, false);

            txtdni = view.FindViewById<EditText>(Resource.Id.txtDnireg);
            txtnombre = view.FindViewById<EditText>(Resource.Id.txtNombrereg);
            txtEmail = view.FindViewById<EditText>(Resource.Id.txtEmailreg);
            txtTele_F = view.FindViewById<EditText>(Resource.Id.txtTelefonoFijoreg);
            txtTele_C = view.FindViewById<EditText>(Resource.Id.txtTelefonoCelularreg);

            botonregistrar = view.FindViewById<Button>(Resource.Id.btnRegistrarReg);

            botonregistrar.Click += Botonregistrar_Click;

            return view;
        }

        private async void Botonregistrar_Click(object sender, EventArgs e)
        {
            progress = new Android.App.ProgressDialog(this.Context);
            progress.Indeterminate = true;
            progress.SetProgressStyle(Android.App.ProgressDialogStyle.Spinner);
            progress.SetMessage("Registrando...Espere...");
            progress.SetCancelable(false);
            progress.Show();

            string dni = txtdni.Text;
            string nombre = txtnombre.Text;
            string email = txtEmail.Text;
            string telef = txtTele_F.Text;
            string telec = txtTele_C.Text;
            try
            {
                if (!string.IsNullOrEmpty(dni) || !string.IsNullOrEmpty(nombre) || !string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(telef) || !string.IsNullOrEmpty(telec))
                {
                    //await
                    var dato = await controller.RegistraCliente(int.Parse(dni), nombre, email, int.Parse(telef), int.Parse(telec));

                    if (dato != null)
                    {
                        progress.Dismiss();
                        Toast.MakeText(this.Context, "Registrado Correctamente", ToastLength.Short).Show();
                        LimpiarCasillas();
                    }
                    else
                    {
                        progress.Dismiss();
                        Toast.MakeText(this.Context, "Error al Registrar", ToastLength.Short).Show();
                        LimpiarCasillas();
                    }
                }
                else
                {
                    progress.Dismiss();
                    Toast.MakeText(this.Context, "Campos vacios", ToastLength.Short).Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
               
            }
           

        }

        void LimpiarCasillas()
        {
            txtdni.Text = "";
            txtnombre.Text = "";
            txtEmail.Text = "";
            txtTele_F.Text = "";
            txtTele_C.Text = "";
        }

    }
}