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
using Windows.UI.Xaml.Controls;
using RobyUWP.models;
using Windows.UI.Popups;

namespace RobyUWP.Viewmodels
{

    class ConfigurerViewModel : INotifyPropertyChanged
    {
        private string adrTCP;
        private string port;
        private FicConfig Fichier;
        private FicConfig Fichier1;
        private FicConfig Fichier2;
        private string nomFichier = "Rover.txt";
        private string TexteEcrit;
        private string TexteLu;
        private string MessageRetour;
        private bool ficExist;

        public string AdrTCP { get => adrTCP; set { adrTCP = value; OnPropertyChanged("AdrTCP"); } }
        public string Port { get => port; set { port = value; OnPropertyChanged("Port"); } }



        public Command Valider { get; set; }
        public Command Quitter { get; set; }


        public ConfigurerViewModel()
        {
            Valider = new Command(ValiderCommand);
            Quitter = new Command(QuitterCommand);

            InitVariable();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        private async void InitVariable(){
            Fichier = new FicConfig(nomFichier);
            Fichier.CreerFic();

             if (Fichier.creationOK != true)
            {
                MessageRetour = Fichier.MessageErreur;
                var messageDialog = new MessageDialog("Une erreur est survenue " + MessageRetour+" !!!");
                await messageDialog.ShowAsync();
            }
            else
            {
                Fichier2 = new FicConfig(nomFichier);
                Fichier2.CreerFic();
                Fichier2.LecFic();
                if (Fichier2.exceptionLevee == true)
                {
                    AdrTCP = "127.0.0.1";
                    Port = "15020";
                }
                else
                {
                    if (Fichier2.Contenu != null) { 
                    TexteLu = Fichier2.Contenu;
                    string[] tabfic = TexteLu.Split("/");
                    AdrTCP = tabfic[0];
                    Port = tabfic[1];
                    ficExist = true;
                    }
                    else
                    {
                        AdrTCP = "127.0.0.1";
                        Port = "15020";
                    }
                }

            }
        }

        private void QuitterCommand(object sender)
        {
            MainPage maFenetre = new MainPage();
            Frame rootframe = Window.Current.Content as Frame;
            rootframe.Navigate(typeof(MainPage));
        }
        private async void ValiderCommand(object sender)
        {
            string MessageRetour;
            Fichier1 = new FicConfig(nomFichier);
            Fichier1.CreerFic();
            if (Fichier1.creationOK != true)
            {
                MessageRetour = Fichier1.MessageErreur;
                var messageDialog1 = new MessageDialog("Une erreur est survenue " + MessageRetour);
                await messageDialog1.ShowAsync();
            }
            else
            {
                if (ficExist == true)
                {
                    await new MessageDialog("Voulez vous ecraser la configuration existante ?", "Question !").ShowAsync();

                    MessageDialog dialog = new MessageDialog("Yes or no?");
                    dialog.Commands.Add(new UICommand("Yes", null));
                    dialog.Commands.Add(new UICommand("No", null));
                    dialog.DefaultCommandIndex = 0;
                    dialog.CancelCommandIndex = 1;
                    var cmd = await dialog.ShowAsync();

                    if (cmd.Label == "Yes")
                    {
                        TexteEcrit = AdrTCP + "/" + Port;
                        Fichier1.EcrFic(TexteEcrit);
                        if (Fichier1.exceptionLevee == true)
                        {
                            var messageDialog = new MessageDialog(Fichier1.MessageErreur);
                            await messageDialog.ShowAsync();
                        }

                        var messageDialog2 = new MessageDialog("Le fichier a été créé avec succès !");
                        await messageDialog2.ShowAsync();
                    }
                }
                else { 
                    TexteEcrit = AdrTCP + "/" + Port;
                    Fichier1.EcrFic(TexteEcrit);
                    if (Fichier1.exceptionLevee == true)
                    {
                        var messageDialog = new MessageDialog(Fichier1.MessageErreur);
                        await messageDialog.ShowAsync();
                    }
                    var messageDialog2 = new MessageDialog("Le fichier a été créé avec succès !");
                    await messageDialog2.ShowAsync();
                }
            }
        }

    }

}
