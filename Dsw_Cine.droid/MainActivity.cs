using Android.App;
using Android.Widget;
using Android.OS;

using Android.Support.V4.Widget;
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.App;
using System.Collections.Generic;
using Java.Lang; 
using Android.Content;
using Android.Views;
using Dsw_Cine.droid.Fragments;

namespace Dsw_Cine.droid
{
    [Activity(Theme = "@style/Theme.DesignDemo" ,Label = "CinePobrePolis", MainLauncher = true, Icon = "@drawable/glasses")]
    public class MainActivity : AppCompatActivity
    {

        private DrawerLayout mDrawerLayout;

        //¨Services controller = new Services();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
 
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);



            //MENU 
            SupportToolbar toolBar = FindViewById<SupportToolbar>(Resource.Id.toolBar);
            SetSupportActionBar(toolBar);

            SupportActionBar ab = SupportActionBar;
            ab.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
           //test no visible icon menu ab.SetDisplayHomeAsUpEnabled(true);

            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            if (navigationView != null)
            {
                SetUpDrawerContent(navigationView);
            }

            TabLayout tabs = FindViewById<TabLayout>(Resource.Id.tabs);

            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);

            SetUpViewPager(viewPager);
             

            tabs.SetupWithViewPager(viewPager);

            //Boton Flotante
            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab); 

            fab.Click += (o, e) =>
            {
                View anchor = o as View;

                Snackbar.Make(anchor, "QR de Participante", Snackbar.LengthLong)
                        .SetAction("SCAN", v =>
                       {

                            //Do something here
                            //lector de QR
                            //  var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                            //  var result = await scanner.Scan();
                            /*
                              if (result != null)
                              {
                                  var dato = await controller.ParticipanteInfo(int.Parse(result.ToString()));

                                  if (dato != null)
                                  {
                                      var activity2 = new Intent(this, typeof(InfoParticipanteActivity));
                                      activity2.PutExtra("idparticipante", result.Text);

                                      StartActivity(activity2);
                                  }
                                  else
                                  {
                                      Toast.MakeText(this, "Participante no encontrado", ToastLength.Long).Show();
                                  }
                              }
                              else
                              {
                                  Toast.MakeText(this, "Participante no encontrado", ToastLength.Long).Show();
                              }
                              //lector de QR
                              */
                       }).Show();

            };
            
            /*Boton Flotante*/
            
            //MENU
        }


        private void SetUpViewPager(ViewPager viewPager)
        {

            //tabs agregar tabs 
            TabAdapter adapter = new TabAdapter(SupportFragmentManager);
            adapter.AddFragment(new Fragment1(), "Registro Cliente");
            adapter.AddFragment(new Fragment2(), "Actualizar Cliente");
            adapter.AddFragment(new Fragment4(), "Consultar Reserva");

            viewPager.Adapter = adapter;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {


           // var txtusuario = FindViewById<TextView>(Resource.Id.txtUsuario);
            //txtusuario.Text = nombre_usuario;

            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    mDrawerLayout.OpenDrawer((int)GravityFlags.Left);
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        //Evento de botones del Menu
        private void SetUpDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (object sender, NavigationView.NavigationItemSelectedEventArgs e) =>
            {


                //menu option
                switch (e.MenuItem.ItemId)
                {
                  /*  case Resource.Id.nav_equipo:
                        var inten = new Intent(this, typeof(infoEquipo));
                        inten.PutExtra("idparticipante", id_participante);
                        StartActivity(inten);
                        break;
                    case Resource.Id.nav_perfil:

                        var activity2 = new Intent(this, typeof(InfoParticipanteActivity));
                        activity2.PutExtra("idparticipante", id_participante);
                        StartActivity(activity2);

                        break;

                    default:

                        Intent loginPageIntent = new Intent(this, typeof(Login));
                        //logout
                        loginPageIntent.AddFlags(ActivityFlags.ClearTop);
                        StartActivity(loginPageIntent);

                        break;*/
                }
                //menu option

                e.MenuItem.SetChecked(true);
                mDrawerLayout.CloseDrawers();
            };
        }
        //Evento de botones del Menu

    }



    //TABS
    public class TabAdapter : FragmentPagerAdapter
    {
        public List<SupportFragment> Fragments { get; set; }
        public List<string> FragmentNames { get; set; }

        public TabAdapter(SupportFragmentManager sfm) : base(sfm)
        {
            Fragments = new List<SupportFragment>();
            FragmentNames = new List<string>();
        }

        public void AddFragment(SupportFragment fragment, string name)
        {
            Fragments.Add(fragment);
            FragmentNames.Add(name);
        }

        public override int Count
        {
            get
            {
                return Fragments.Count;
            }
        }

        public override SupportFragment GetItem(int position)
        {
            return Fragments[position];
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(FragmentNames[position]);
        }
    }
    //TABS


}

