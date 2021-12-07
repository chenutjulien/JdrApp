using Xamarin.Forms;
using JdrApp.Views;

namespace JdrApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Donjon01), typeof(Donjon01));
            Routing.RegisterRoute(nameof(Jungle01), typeof(Jungle01));

            Routing.RegisterRoute(nameof(Donjon02), typeof(Donjon02));
        }

    }
}
