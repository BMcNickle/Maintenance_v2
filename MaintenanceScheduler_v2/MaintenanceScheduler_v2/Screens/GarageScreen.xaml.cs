using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MaintenanceScheduler_v2.Screens
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    //Code behind for the 'Garage' screen.
    public partial class GarageScreen : ContentPage
    {
        public GarageScreen()
        {
            InitializeComponent();
            //Checks for the 
            CheckGarage();
        }

        async void CheckGarage()
        {
            var _garageFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "GarageFile.txt");

            if (_garageFile == null || !File.Exists(_garageFile))
            {
                bool _answer = await DisplayAlert("Garage Empty!", "Your garage is empty!\nWould you like to add a new vehicle now?", "Yes", "No");
                if (_answer)
                {
                    GoTo_AddVehicle_Screen();
                }
            }
            else
            {
                DisplayGarage();
            }
        }

        void AddVehicle_Clicked(object sender, EventArgs e)
        {
            GoTo_AddVehicle_Screen();
        }

        async void Previous_Screen_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        
        async void Delete_Clicked(object sender, EventArgs e)
        {
            var _garageFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "GarageFile.txt");

            if (!File.Exists(_garageFile))
            {
                await DisplayAlert("Error!", "File has already been deleted!", "OK");
            }
            else
            {
                File.Delete(_garageFile);
            }
        }

        async void GoTo_AddVehicle_Screen()
        {
            await Navigation.PushModalAsync(new AddVehicle_Screen());
        }

        public async void DisplayGarage()
        {
            string _fromFile = "";
            var _garageFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "GarageFile.txt");

            using (var _reader = new StreamReader(_garageFile, true))
            {
                string _fileLine;
                while ((_fileLine = await _reader.ReadLineAsync()) != null)
                {
                    if (_fromFile == "")
                    {
                        _fromFile = _fileLine.Trim();
                    }
                    else
                    {
                        _fromFile = $"{_fromFile}{_fileLine.Trim()}";
                    }
                }
            }
            TestLabel.Text = _fromFile;
        }
    }
}