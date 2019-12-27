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

            SearchAddressCommand = new Command(
                execute: (obj) =>
                {
                    Houses = Database.GetHousesByAddress(Address);
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
                        EditHouseWindow ehw = new EditHouseWindow(SelectedHouse.Id, SelectedHouse.Address, SelectedHouse.EntranceNumber, SelectedHouse.Floors, SelectedHouse.Flats, SelectedHouse.Elevator, SelectedHouse.HotWater, SelectedHouse.ColdWater, SelectedHouse.Gas, SelectedHouse.Antenna, SelectedHouse.CabelTV, SelectedHouse.Telephone, SelectedHouse.Radio, SelectedHouse.ProjectNumber, SelectedHouse.Settlement, SelectedHouse.Delivery);
                        if (ehw.ShowDialog() == true)
                        {
                            Database.UpdateHouse(new House { Id = ehw.Id, Address = ehw.Address, Antenna = ehw.Antenna, CabelTV = ehw.CabelTV, ColdWater = ehw.ColdWater, Delivery = ehw.Delivery, Elevator = ehw.Elevator, EntranceNumber = ehw.EntranceNumber, Flats = ehw.Flats, Floors = ehw.Floors, Gas = ehw.Gas, HotWater = ehw.HotWater, ProjectNumber = ehw.ProjectNumber, Radio = ehw.Radio, Settlement = ehw.Settlement, Telephone = ehw.Telephone });
                            Houses = Database.GetHouses();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выделите строчку в таблице домов!", "Ошибка!", MessageBoxButton.OK);
                    }
                }
                );
        }
        public Command AddHouseCommand { private set; get; }
        public Command DeleteHouseCommand { private set; get; }
        public Command EditHouseCommand { private set; get; }
        public Command SearchAddressCommand { private set; get; }
    }
}
