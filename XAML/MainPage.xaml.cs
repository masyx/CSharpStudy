using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XAML
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var buttonToXamlPlusCodePage = new Button()
            {
                Text = "Navigate to XamlPlusCodePage",
                TextColor = Color.BlanchedAlmond,
                FontSize = 16,
                BorderColor = Color.Red,
                BorderWidth = 2,
                BackgroundColor = Color.SteelBlue,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 300
            };

            buttonToXamlPlusCodePage.Clicked += async (s, e) =>
             {
                 await Navigation.PushAsync(new XamlPlusCodePage());
             };

            var buttonToGridDemoPage = new Button()
            {
                Text = "Navigate to Grid Demo Page",
                TextColor = Color.BlanchedAlmond,
                FontSize = 16,
                BorderColor = Color.Red,
                BorderWidth = 2,
                BackgroundColor = Color.SteelBlue,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 300
            };

            buttonToGridDemoPage.Clicked += async (s, e) =>
            {
                await Navigation.PushAsync(new GridDemoPage());
            };

            var buttonToAbsoluteDemoPage = new Button()
            {
                Text = "Navigate to Absolute Demo Page",
                TextColor = Color.BlanchedAlmond,
                FontSize = 16,
                BorderColor = Color.Red,
                BorderWidth = 2,
                BackgroundColor = Color.SteelBlue,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 300
            };

            buttonToAbsoluteDemoPage.Clicked += async (s, e) =>
            {
                await Navigation.PushAsync(new AbsoluteDemoPage());
            };

            var stackLayout = new StackLayout();
            stackLayout.Children.Add(buttonToXamlPlusCodePage);
            stackLayout.Children.Add(buttonToGridDemoPage);
            stackLayout.Children.Add(buttonToAbsoluteDemoPage);
            Content = stackLayout;          
        }

    }
}
