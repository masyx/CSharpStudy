using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace DataBinding
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value)
                    return;

                _name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(DisplayName));
            }
        }

        public string DisplayName => $"Display name:{Name}";

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Command OnTapCommand
        {
            get
            {
                return new Command<StackLayout>((s) =>
                {
                    var label = s as StackLayout;
                    if (label.BackgroundColor == Color.Yellow)
                    {
                        label.BackgroundColor = Color.Default;
                    }
                    else
                    {
                        label.BackgroundColor = Color.Yellow;
                    }
                });
            }
        }
    }
}
