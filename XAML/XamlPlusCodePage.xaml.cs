using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XAML
{
    public partial class XamlPlusCodePage : ContentPage
    {
        public XamlPlusCodePage()
        {
            InitializeComponent();
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            valueLabel.Text = args.NewValue.ToString("F3");
            //valueLabel.Text = ((Slider)sender).Value.ToString("F3");
            Content.FindByName("");
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            var button  = sender as Button;
            await DisplayAlert("Clicked!",
                "The button labeled '" + button.Text + "' has been clicked", "OK");
        }

    }
}
