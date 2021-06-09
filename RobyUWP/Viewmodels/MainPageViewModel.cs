using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobyUWP.Views;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using RobyUWP.Models;

namespace RobyUWP.Viewmodels 
{
    
    class MainPageViewModel : INotifyPropertyChanged
    {
        public Command QuitterRoby { get; set; }
        public ICommand ConfigurerRoby { get; set; }
        public ICommand PiloterRoby { get; set; }

        public MainPageViewModel()
        {
        ConfigurerRoby = new Command(ConfigurerRobyCommand);
        PiloterRoby = new Command(PiloterRobyCommand);
        QuitterRoby = new Command(QuitterRobyCommand);
        }

    public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        private void QuitterRobyCommand(object sender)
        {
            Application.Current.Exit();
        }
        private void PiloterRobyCommand(object sender)
        {
            Application.Current.Exit();
        }
        private void ConfigurerRobyCommand(object sender)
        {
            Application.Current.Exit();
        }
    }
}
