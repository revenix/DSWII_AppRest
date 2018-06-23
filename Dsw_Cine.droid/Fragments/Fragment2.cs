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
    public class Fragment2 : SupportFragment
    {

        EditText txtdni;
        EditText txtnombre;
        EditText txtEmail;
        EditText txtTele_F;
        EditText txtTele_C;
        Button botonvalidar;
        Button botonActualizar;

        Services controller = new Services();

        Android.App.ProgressDialog progress;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.fragment2, container, false);

            txtdni = view.FindViewById<EditText>(Resource.Id.txtDniValido);


            txtnombre = view.FindViewById<EditText>(Resource.Id.txtNombreval);
            txtEmail = view.FindViewById<EditText>(Resource.Id.txtEmailval);
            txtTele_F = view.FindViewById<EditText>(Resource.Id.txtTelefonoFijoval);
            txtTele_C = view.FindViewById<EditText>(Resource.Id.txtTelefonoCelularval);

            botonvalidar = view.FindViewById<Button>(Resource.Id.btnValidarDNI);
            botonActualizar = view.FindViewById<Button>(Resource.Id.btnActualizar);


            botonvalidar.Click += Botonvalidar_Click;
            botonActualizar.Click += BotonActualizar_Click;

            return view;
        }

        private async void BotonActualizar_Click(object sender, EventArgs e)
        {
            progress = new Android.App.ProgressDialog(this.Context);
            progress.Indeterminate = true;
            progress.SetProgressStyle(Android.App.ProgressDialogStyle.Spinner);
            progress.SetMessage("Actualizando...Espere...");
            progress.SetCancelable(false);
            progress.Show();

            string dni = txtdni.Text;
            string nombre = txtnombre.Text;
            string email = txtEmail.Text;
            string telef = txtTele_F.Text;
            string telec = txtTele_C.Text;

            if (!string.IsNullOrEmpty(dni) || !string.IsNullOrEmpty(nombre) || !string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(telef) || !string.IsNullOrEmpty(telec))
            {
                //await
                var dato = await controller.ActualizaCliente(int.Parse(dni), nombre, email, int.Parse(telef), int.Parse(telec));

                if (dato != null)
                {
                    progress.Dismiss();
                    Toast.MakeText(this.Context, "Actualizado Correctamente", ToastLength.Short).Show();

                }
                else
                {
                    progress.Dismiss();
                    Toast.MakeText(this.Context, "Error al Actualizar", ToastLength.Short).Show();
                }
            }
            else
            {
                progress.Dismiss();
                Toast.MakeText(this.Context, "Campos vacios", ToastLength.Short).Show();

            }


        }

        private async void  Botonvalidar_Click(object sender, EventArgs e)
        {
            progress = new Android.App.ProgressDialog(this.Context);
            progress.Indeterminate = true;
            progress.SetProgressStyle(Android.App.ProgressDialogStyle.Spinner);
            progress.SetMessage("Validando...Espere...");
            progress.SetCancelable(false);
            progress.Show();

            if (!string.IsNullOrEmpty(txtdni.Text))
            {
                var dato = await controller.ValidaCliente(int.Parse(txtdni.Text));

                if (dato != null)
                {

                    txtnombre.Text = dato.nom_clie;
                    txtEmail.Text = dato.correo;
                    txtTele_F.Text = dato.telefono_f;
                    txtTele_C.Text = dato.telefono_c;
                    progress.Dismiss();

                }
                else
                {
                    progress.Dismiss();
                    Toast.MakeText(this.Context, "Cliente no encontrado", ToastLength.Long).Show();
                }

            }
            else
            {
                progress.Dismiss();
                Toast.MakeText(this.Context, "Campo vacio", ToastLength.Long).Show();

            }
                



        }




    }
}