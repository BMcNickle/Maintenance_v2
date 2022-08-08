using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MaintenanceScheduler_v2.Screens
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateScreen : ContentPage
    {
        //Code-behind for the 'Update Milage' screen
        //This is still under development
        public UpdateScreen()
        {
            InitializeComponent();
        }

        //When the 'Cancel' button is clicked an alert is displayed to ask
        //for confirmation. If 'Yes' is selected, the instance of 'Update Milage'
        //is popped from the top of the Navigation stack
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            bool _answer = await DisplayAlert("Cancel?", "Are you sure you want to cancel?\nMilage will be updated!", "Yes", "No");
            if (_answer)
            {
                await Navigation.PopModalAsync();
            }
            else
            {
                return;
            }
        }

        //When 'Update' button is clicked, an alert is displayed to say
        //that the function is incomplete. The instance of 'Update Milage'
        //is then popped off the top of the Navigation Stack.
        async void Update_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Error!", "Update function is incomplete!\nMilage has not been updated", "OK");
            await Navigation.PopModalAsync();
        }
    }
}