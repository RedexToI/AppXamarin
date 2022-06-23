using AppXamarin.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageDetail : ContentPage
    {
        public List<Product> Products = new List<Product>();

        public HomePageDetail()
        {
            InitializeComponent();
            InitProduct("Todos");
            FilterPerCategory();
            PickerFilter();
        }

        void PickerFilter()
        {
            filter.SelectedIndexChanged += async (sender, e) =>
            {
                string category = filter.Items[filter.SelectedIndex];

                InitProduct(category);
            };
        }
        
        void InitProduct(string categoryName)
        {
            this.Products = new List<Product>();
            this.products.ItemsSource = App.Database.GetProductsAsync(categoryName).Result;
        }

        void FilterPerCategory() => filter.ItemsSource = App.Database.GetCategoryNames().Result;
    }
}

