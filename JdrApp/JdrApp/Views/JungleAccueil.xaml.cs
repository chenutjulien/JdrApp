using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JdrApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JungleAccueil : ContentPage
    {
        public JungleAccueil()
        {
            InitializeComponent();
        }
        async void GoJungleAventure01Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Jungle01));
        }
    }
}