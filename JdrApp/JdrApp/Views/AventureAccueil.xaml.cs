
using System;
using Xamarin.Forms;

namespace JdrApp.Views
{
    public partial class AventureAccueil : ContentPage
    {
        public AventureAccueil()
        {
            InitializeComponent();
        }
        async void DebutAventure(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Donjon02));
        }
    }
}