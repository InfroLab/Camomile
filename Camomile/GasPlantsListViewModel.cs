using System.Collections.ObjectModel;
using System.Windows;

namespace Camomile
{
    public class GasPlantsListViewModel : ViewModel
    {
        private GasPlantViewModel selectedGasPlant;
        private ObservableCollection<GasPlantViewModel> gasPlants;
        public static int CurrentGasPlantId = 1;

        public ObservableCollection<GasPlantViewModel> GasPlants
        {
            //The list showing collection contents
            //is not updating without this notification
            get
            {
                return gasPlants;
            }
            set
            {
                if (gasPlants != value)
                {
                    gasPlants = value;
                    OnPropertyChanged("GasPlants");
                }
            }
        }
        public GasPlantViewModel SelectedGasPlant
        {
            get
            {
                return selectedGasPlant;
            }
            set
            {
                if (selectedGasPlant != value)
                {
                    selectedGasPlant = value;
                    OnPropertyChanged("SelectedGasPlant");
                }
            }
        }

        public GasPlantsListViewModel()
        {
            GasPlants = Database.GetGasPlants();

            AddGasPlantCommand = new Command(
                execute: (obj) =>
                {
                    AddGasPlantWindow aesw = new AddGasPlantWindow();

                    if (aesw.ShowDialog() == true)
                    {
                        Database.AddGasPlant(new GasPlant { Address = aesw.Address, Features = aesw.Features });
                        GasPlants = Database.GetGasPlants();
                    }
                }
                );

            DeleteGasPlantCommand = new Command(
                execute: (obj) =>
                {
                    if(SelectedGasPlant != null)
                    {
                        Database.RemoveGasPlant(SelectedGasPlant.Id);
                        GasPlants = Database.GetGasPlants();
                    }
                    else
                    {
                        MessageBox.Show("Выделите строчку в таблице домов!", "Ошибка!", MessageBoxButton.OK);
                    }
                }
                );

            EditGasPlantCommand = new Command(
                execute: (obj) =>
                {
                    if (SelectedGasPlant != null)
                    {
                    }
                    else
                    {
                    }
                }
                );
        }
        public Command AddGasPlantCommand { private set; get; }
        public Command DeleteGasPlantCommand { private set; get; }
        public Command EditGasPlantCommand { private set; get; }
    }
}
