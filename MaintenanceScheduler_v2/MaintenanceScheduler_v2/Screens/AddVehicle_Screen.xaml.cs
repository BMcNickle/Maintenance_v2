using MaintenanceScheduler_v2.Models;
using MaintenanceScheduler_v2.Screens;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MaintenanceScheduler_v2.Screens
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    //Code-behind for 'AddVehicle' Screen
    public partial class AddVehicle_Screen : ContentPage
    {
        //Creates a private variable named '_myVehicle' of type 'Vehicle' (defined in the 'Vehicle' class)
        private Vehicle _myVehicle;

        //The text typed in the boxes on the .xaml side are bound to these variables so they will always match.
        //The { get; set; } of the variables will then assign thier values to '_myVehicle.[VariableName]' as the values change
        public string VehicleType
        {
            get { return _myVehicle.VehicleType; }
            set { _myVehicle.VehicleType = value; }
        }
        public string Registration
        {
            get { return _myVehicle.Registration; }
            set { _myVehicle.Registration = value; }
        }
        public string Make
        {
            get { return _myVehicle.Make; }
            set { _myVehicle.Make = value; }
        }
        public string Model
        {
            get { return _myVehicle.Model; }
            set { _myVehicle.Model = value; }
        }
        public int Year
        {
            get { return _myVehicle.Year; }
            set { _myVehicle.Year = value; }
        }
        public int Milage
        {
            get { return _myVehicle.Milage; }
            set { _myVehicle.Milage = value; }
        }

        public AddVehicle_Screen()
        {
            //Initialises the variable '_myVehicle' my assigning it to an new instance of the object 'Vehicle'
            _myVehicle = new Vehicle();

            //Tells the script on the .xaml side that it's binding should be directed to this class
            BindingContext = this;
            InitializeComponent();
            //'Garage' screen does not refresh when this screen is popped from Navigation stack
            //TODO: Remove 'Garage' screen from stack so that it is reloaded when
            //user moves back to it from 'AddVehicle' screen
        }


        //When 'Cancel' button is pressed an alert is displayed to ask user if they are sure,
        //then 'AddVehicle' screen is popped from the navigation stack
        async void Cancel_AddVehicle(object sender, EventArgs e)
        {
            bool _answer = await DisplayAlert("Cancel?", "Are you sure you want to cancel this new vehicle?\nAll entries will be lost!", "Yes", "No");
            if (_answer)
            {
                await Navigation.PopModalAsync();
            }
            else
            {
                return;
            }
        }

        //Appends or creates a file called 'GarageFile.txt' and writes the contents of '_myVehicle' to file
        async void Save_Vehicle(object sender, EventArgs e)
        {
            //The values of '_myVehicle' must be formatted correctly before writing
            string _vehicleToBeSaved = FormatVehicle();

            //Gets the location of 'GarageFile.txt' and assigns it to the variable '_garageFile'
            var _garageFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "GarageFile.txt");

            //Opens or creates the file at the above location, then wrties the value of '_vehicleToBeSaved' at the end of file
            using (var _writer = File.AppendText(_garageFile))
            {
                await _writer.WriteLineAsync(_vehicleToBeSaved);
            }
            await DisplayAlert("Success!", "Data has been saved\nPlease reload garage screen", "OK");
            await Navigation.PopModalAsync();
        }

        //Takes the values held in each part of the object '_myVehicle' and concatinates
        //them to the variable '_formattedVehicle' in preparation for wirtting to file
        private string FormatVehicle()
        {
            string _tempString;
            string _formattedVehicle;

            _tempString = _myVehicle.Registration.Replace(" ", "");
            _formattedVehicle = $"{_tempString.ToUpper()}";

            _tempString = _myVehicle.VehicleType.Trim();
            _formattedVehicle = $"{_formattedVehicle}|{_tempString}";

            _tempString = _myVehicle.Make.Trim();
            _formattedVehicle = $"{_formattedVehicle}|{_tempString}";

            _tempString = _myVehicle.Model.Trim();
            _formattedVehicle = $"{_formattedVehicle}|{_tempString}";

            _tempString = _myVehicle.Year.ToString();
            _formattedVehicle = $"{_formattedVehicle}|{_tempString}";

            _tempString = _myVehicle.Milage.ToString();
            _formattedVehicle = $"{_formattedVehicle}|{_tempString}~";

            return _formattedVehicle;
        }
    }
}