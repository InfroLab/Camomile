using System.Collections.ObjectModel;
using System.Windows;

namespace Camomile
{
    public class FlatsListViewModel : ViewModel
    {
        private FlatViewModel selectedFlat;
        private ObservableCollection<FlatViewModel> flats;
        public static int CurrentFlatId = 1;

        public ObservableCollection<FlatViewModel> Flats
        {
            //The list showing collection contents
            //is not updating without this notification
            get
            {
                return flats;
            }
            set
            {
                if (flats != value)
                {
                    flats = value;
                    OnPropertyChanged("Flats");
                }
            }
        }
        public FlatViewModel SelectedFlat
        {
            get
            {
                return selectedFlat;
            }
            set
            {
                if (selectedFlat != value)
                {
                    selectedFlat = value;
                    OnPropertyChanged("SelectedFlat");
                }
            }
        }

        public FlatsListViewModel()
        {
            Flats = Database.GetFlats();

            AddFlatCommand = new Command(
                execute: (obj) =>
                {
                    AddFlatWindow afw = new AddFlatWindow();

                    if (afw.ShowDialog() == true)
                    {
                        Database.AddFlat(new Flat { Address = afw.Address, Rooms=afw.Rooms, Renter=afw.Renter, Registration=afw.Registration, Balcony=afw.Balcony, AreaPerPerson=afw.AreaPerPerson, Area=afw.Area});
                        Flats = Database.GetFlats();
                    }
                }
                );

            SearchAddressCommand = new Command(
                execute: (obj) =>
                {
                    Flats = Database.GetFlatsByAddress(Address);
                }
                );

            DeleteFlatCommand = new Command(
                execute: (obj) =>
                {
                    if (SelectedFlat != null)
                    {
                        Database.RemoveFlat(SelectedFlat.Id);
                        Flats = Database.GetFlats();
                    }
                    else
                    {
                        MessageBox.Show("Выделите строчку в таблице домов!", "Ошибка!", MessageBoxButton.OK);
                    }
                }
                );

            EditFlatCommand = new Command(
                execute: (obj) =>
                {
                    if (SelectedFlat != null)
                    {
                    }
                    else
                    {
                    }
                }
                );
        }
        public Command AddFlatCommand { private set; get; }
        public Command DeleteFlatCommand { private set; get; }
        public Command EditFlatCommand { private set; get; }
        public Command SearchAddressCommand { private set; get; }
    }
}
