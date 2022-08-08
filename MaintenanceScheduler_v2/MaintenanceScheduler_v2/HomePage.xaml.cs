using System;
using Xamarin.Forms;
using MaintenanceScheduler_v2.Screens;

namespace MaintenanceScheduler_v2
{
    //Code-behind for the HomePage Screen
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        //When the 'Update Milage' button is clicked, a new instance of
        //'UpdateScreen' is pushed on to the top of the Navigation Stack
        async void Update_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new UpdateScreen());
        }

        //When the 'Perform Maintenance' button is clicked, the text of 
        //the button changes to say the feature is incomplete
        void Perform_Clicked(object sender, EventArgs e)
        {
            (sender as Button).Text = "Maintenance section is incomplete!";
        }

        //When the 'Garage' button is clicked, a new instance of 'GarageScreen'
        //is pushed on to the top of the Navigation stack
        async void Garage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new GarageScreen());
        }
    }
}
