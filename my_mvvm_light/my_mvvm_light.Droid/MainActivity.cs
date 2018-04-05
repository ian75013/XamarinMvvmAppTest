using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using my_mvvm_light.ViewModel;


namespace my_mvvm_light.Droid
{
	[Activity (Label = "my_mvvm_light.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public partial class MainActivity : ActivityBase
	{
	    public MainViewModel ViewModel => App.Locator.Main;
        int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it

		    this.SetBinding(
		        () => ViewModel.TeamName,
		        () => TxtTeamName.Text,
		        BindingMode.TwoWay);
		    this.SetBinding(
		        () => ViewModel.Capacity,
		        () => TxtCapacity.Text,
		        BindingMode.TwoWay);
		    this.SetBinding(
		        () => ViewModel.StadiumName,
		        () => TxtStadium,
		        BindingMode.TwoWay);
		   CreateButtonBinding();
		    
        }
	    void CreateButtonBinding()
	    {
	        BtnShuffle.SetCommand(
	            Events.Click,
	            ViewModel.ButtonClicked);
	    }
    }
   
    public partial class MainActivity
    {
        // create the private references to the objects
        Button btnShuffle;
        TextView txtTeamName, txtStadium, txtCapacity;
        EditText editShuffles;
        // create the public properties for the objects
        public Button BtnShuffle => btnShuffle ?? (btnShuffle = FindViewById<Button>(Resource.
                                        Id.btnShuffle));
        public TextView TxtTeamName => txtTeamName ?? (txtTeamName =
                                           FindViewById<TextView>(Resource.Id.txtTeamName));
        public TextView TxtStadium => txtStadium ?? (txtStadium =
                                          FindViewById<TextView>(Resource.Id.txtStadium));
        public TextView TxtCapacity => txtCapacity ?? (txtCapacity =
                                           FindViewById<TextView>(Resource.Id.txtCapacity));
        public EditText EditShuffles => editShuffles ?? (editShuffles =
                                            FindViewById<EditText>(Resource.Id.editShuffles));
    }
    public static class App
    {
        private static ViewModelLocator locator;
        public static ViewModelLocator Locator => locator ?? (locator = new ViewModelLocator());
    }
    public static class Events
    {
        public const string Click = "Click";
    }
   
}


