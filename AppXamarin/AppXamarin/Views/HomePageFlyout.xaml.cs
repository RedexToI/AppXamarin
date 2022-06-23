using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageFlyout : ContentPage
    {
        public ListView ListView;

        public HomePageFlyout()
        {
            InitializeComponent();

            BindingContext = new HomePageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class HomePageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<HomePageFlyoutMenuItem> MenuItems { get; set; }

            public HomePageFlyoutViewModel()
            {
                var role = Preferences.Get("UserRol", "");

                if(role.Equals("Admin"))
                {
                    MenuItems = new ObservableCollection<HomePageFlyoutMenuItem>(new[]
                    {
                        new HomePageFlyoutMenuItem { Id = 0, Title = "Pagina Principal", TargetType = typeof(HomePageDetail) },
                        new HomePageFlyoutMenuItem { Id = 1, Title = "Crear Productos", TargetType = typeof(ProductsNewPage) },
                        new HomePageFlyoutMenuItem { Id = 2, Title = "Cerrar Sesion", TargetType = typeof(LoginPage) },
                    });
                }
                else
                {
                    MenuItems = new ObservableCollection<HomePageFlyoutMenuItem>(new[]
                    {
                        new HomePageFlyoutMenuItem { Id = 0, Title = "Pagina Principal", TargetType = typeof(HomePageDetail) },
                        new HomePageFlyoutMenuItem { Id = 2, Title = "Cerrar Sesion", TargetType = typeof(LoginPage) },
                    });
                }
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}