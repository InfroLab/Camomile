using System.Collections.ObjectModel;
using System.Windows;

namespace Camomile
{
    public class HousesListViewModel : ViewModel
    {
        private HouseViewModel selectedHouse;
        private ObservableCollection<HouseViewModel> houses;
        public static int CurrentHouseId = 1;

        public ObservableCollection<HouseViewModel> Houses
        {
            //The list showing collection contents
            //is not updating without this notification
            get
            {
                return houses;
            }
            set
            {
                if (houses != value)
                {
                    houses = value;
                    OnPropertyChanged("Houses");
                }
            }
        }
        public HouseViewModel SelectedHouse
        {
            get
            {
                return selectedHouse;
            }
            set
            {
                if (selectedHouse != value)
                {
                    selectedHouse = value;
                    OnPropertyChanged("SelectedHouse");
                }
            }
        }

        public HousesListViewModel()
        {
            Houses = Database.GetHouses();

            AddHouseCommand = new Command(
                execute: (obj) =>
                {
                    AddHouseWindow ahw = new AddHouseWindow();

                    if (ahw.ShowDialog() == true)
                    {
                        Database.AddHouse(new House { Address = ahw.Address, Antenna = ahw.Antenna, CabelTV = ahw.CabelTV, ColdWater = ahw.ColdWater, Delivery = ahw.Delivery, Elevator = ahw.Elevator, EntranceNumber = ahw.EntranceNumber, Flats = ahw.Flats, Floors = ahw.Floors, Gas = ahw.Gas, HotWater = ahw.HotWater, ProjectNumber = ahw.ProjectNumber, Radio = ahw.Radio, Settlement = ahw.Settlement, Telephone = ahw.Telephone });
                        Houses = Database.GetHouses();
                    }
                }
                );

            DeleteHouseCommand = new Command(
                execute: (obj) =>
                {
                    if (SelectedHouse != null)
                    {
                        Database.RemoveHouse(SelectedHouse.Id);
                        Houses = Database.GetHouses();
                    }
                    else
                    {
                        MessageBox.Show("Выделите строчку в таблице домов!", "Ошибка!", MessageBoxButton.OK);
                    }
                }
                );

            EditHouseCommand = new Command(
                execute: (obj) =>
                {
                    if (SelectedHouse != null)
                    {
                    }
                    else
                    {
                    }
                }
                );
        }
        public Command AddHouseCommand { private set; get; }
        public Command DeleteHouseCommand { private set; get; }
        public Command EditHouseCommand { private set; get; }
    }
}
