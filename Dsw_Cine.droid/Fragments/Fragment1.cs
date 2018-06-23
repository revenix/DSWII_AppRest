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
using System.Threading.Tasks;

namespace Dsw_Cine.droid.Fragments
{
    public class Fragment1 : SupportFragment
    {

        EditText txtdni;
        EditText txtnombre;
        EditText txtEmail;
        EditText txtTele_F;
        EditText txtTele_C;

        Services controller = new Services();

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.fragment1, container, false);

              txtdni = view.FindViewById<EditText>(Resource.Id.txtDni);
              txtnombre = view.FindViewById<EditText>(Resource.Id.txtNombre);
              txtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
              txtTele_F = view.FindViewById<EditText>(Resource.Id.txtTelefonoFijo);
              txtTele_C = view.FindViewById<EditText>(Resource.Id.txtTelefonoCelular);

           var  BtnRegistrar = view.FindViewById<Button>(Resource.Id.btnRegistrar);

            BtnRegistrar.Click += BtnRegistrar_ClickAsync;  

            return view;
        }

        private void  BtnRegistrar_ClickAsync(object sender, EventArgs e)
        {
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
                    var dato = controller.RegistraCliente(int.Parse(dni), nombre, email, int.Parse(telef), int.Parse(telec));

                    if (dato != null)
                    {
                        Toast.MakeText(this.Context, "Registrado Correctamente", ToastLength.Short).Show();

                    }
                    else
                    {
                        Toast.MakeText(this.Context, "Error al Registrar", ToastLength.Short).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this.Context, "Campos vacios", ToastLength.Short).Show();

                }
            }
            catch (Exception)
            {

                Toast.MakeText(this.Context, "Error al llamar al Servicio", ToastLength.Short).Show();
            }



        }
    }
}