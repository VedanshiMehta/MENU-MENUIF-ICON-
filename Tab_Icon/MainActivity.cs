using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.Tabs;
using System;

namespace Tab_Icon
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TabLayout _mytab;
        private TextView _mytext;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            _mytab = FindViewById<TabLayout>(Resource.Id.Tabb);
            _mytext = FindViewById<TextView>(Resource.Id.textView1);


            _mytab.TabSelected += _mytab_TabSelected;
            SetTabIcon();
        }

        private void _mytab_TabSelected(object sender, TabLayout.TabSelectedEventArgs e)
        {
            switch (e.Tab.Position)
            {
                case 0: _mytext.SetText(Resource.String.home);
                    break;

                case 1: _mytext.SetText(Resource.String.favourite);
                    break;

                case 2:_mytext.SetText(Resource.String.notification);
                    break;
            
            }
        }

        private void SetTabIcon()
        {
            _mytab.AddTab(_mytab.NewTab().SetIcon(Resource.Drawable.ic_newhome),true);
            _mytab.AddTab(_mytab.NewTab().SetIcon(Resource.Drawable.ic_newfav), true);
            _mytab.AddTab(_mytab.NewTab().SetIcon(Resource.Drawable.ic_newnotifi), true);

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
           

            switch(item.ItemId)
            {
                case (Resource.Id.action_search):

                   
                   //StartActivity(typeof(AutoComplete));
                   Toast.MakeText(this, "Searched Clicked", ToastLength.Short).Show();
                   return true;

                case (Resource.Id.action_buletooth):
                    Toast.MakeText(this, "Bluetooth Clicked", ToastLength.Short).Show();
                    return true;


                case (Resource.Id.action_email):
                    Toast.MakeText(this, "Email Clicked", ToastLength.Short).Show();
                    return true;
                case (Resource.Id.action_calllog):
                    Toast.MakeText(this, "Call Log Clicked", ToastLength.Short).Show();
                    return true;
                case (Resource.Id.action_contacts):
                    Toast.MakeText(this, "Contacts Clicked", ToastLength.Short).Show();
                    return true;

            }

            return base.OnOptionsItemSelected(item);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

}