
using System;
using Xamarin.Forms;

namespace JdrApp.Views
{
    public partial class DonjonAccueil : ContentPage
    {
        public DonjonAccueil()
        {
            InitializeComponent();
        }
        async void DebutDonjon (object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Donjon02));
        }
        async void Donjon01Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Donjon01));
        }
    }
}