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
    public class Fragment3 : SupportFragment
    {
        TextView txtnroTicket;
        Button BotonConsultar;

        TextView txtpelicula;
        TextView txtlocal;
        TextView txtsala;
        TextView txtinicio;
        TextView txtfin;
        TextView txtdnicliente;
        TextView txtnombrecliente;

        Services controller = new Services();

        Android.App.ProgressDialog progress;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

           
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View view = inflater.Inflate(Resource.Layout.fragment3, container, false);
            BotonConsultar = view.FindViewById<Button>(Resource.Id.btnConsultarReserva);
            txtnroTicket = view.FindViewById<EditText>(Resource.Id.txtNroTicket);


            txtpelicula = view.FindViewById<TextView>(Resource.Id.txtPelicula);
            txtlocal = view.FindViewById<TextView>(Resource.Id.txtLocal);
            txtsala = view.FindViewById<TextView>(Resource.Id.txtSala);
            txtinicio = view.FindViewById<TextView>(Resource.Id.txtInicio);
            txtfin = view.FindViewById<TextView>(Resource.Id.txtFin);
            txtdnicliente = view.FindViewById<TextView>(Resource.Id.txtDniCliente);
            txtnombrecliente = view.FindViewById<TextView>(Resource.Id.txtNombreCliente);

            BotonConsultar.Click += BotonConsultar_Click;

            return view;
        }

        private async void BotonConsultar_Click(object sender, EventArgs e)
        {

            progress = new Android.App.ProgressDialog(this.Context);
            progress.Indeterminate = true;
            progress.SetProgressStyle(Android.App.ProgressDialogStyle.Spinner);
            progress.SetMessage("Consultando...Espere...");
            progress.SetCancelable(false);
            progress.Show();

            if (!string.IsNullOrEmpty(txtnroTicket.Text))
            {
                var dato = await controller.ConsultaReserva(int.Parse(txtnroTicket.Text));

                if (dato != null)
                {

                    txtpelicula.Text = dato.nombre_peli;
                    txtlocal.Text = dato.nombre_local;
                    txtsala.Text = dato.num_sala+"";
                    txtinicio.Text = dato.inicio; 
                    txtfin.Text = dato.fin;
                    txtdnicliente.Text = dato.dni;
                    txtnombrecliente.Text = dato.nom_cliente;


                    progress.Dismiss();

                }
                else
                {
                    progress.Dismiss();
                    Toast.MakeText(this.Context, "Reserva no encontrada", ToastLength.Long).Show();
                    LimpiarCasillas();
                }

            }
            else
            {
                progress.Dismiss();
                Toast.MakeText(this.Context, "Campo vacio", ToastLength.Long).Show();


            }



        }


        void LimpiarCasillas()
        {
            txtnroTicket.Text = ""; 
            txtpelicula.Text = "";
            txtlocal.Text = "";
            txtsala.Text = "";
            txtinicio.Text = "";
            txtfin.Text = "";
            txtdnicliente.Text = "";
            txtnombrecliente.Text = "";

        }
    }
}