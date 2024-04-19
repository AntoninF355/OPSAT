using OPSAT.Main;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPSAT.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        /**
         * Lien entre la vue et le modèle, VM notifie la vue du changement (d'ou les observable objects) et VM met a jour le modèle selon les actions et data binding
         * */

        public RelayCommand HomeViewCommand { get; set; } //commande pour changer de page
        public RelayCommand ConvertisseurViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public ConvertisseurViewModel ConvertisseurVm { get; set; }


        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            { 
                _currentView = value;
                onPropertyChanged();
            }
        }


        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            ConvertisseurVm = new ConvertisseurViewModel();


            HomeViewCommand = new RelayCommand(o =>             //clique sur la commande, changement de vue
            {
                CurrentView = HomeVM;
            });

            ConvertisseurViewCommand = new RelayCommand(o =>
            {
                CurrentView = ConvertisseurVm;
            });

        }
    }
}
