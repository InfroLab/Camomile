using System.Collections.ObjectModel;
using System.Windows;

namespace Camomile
{
    public class ElectricSubsListViewModel : ViewModel
    {
        private ElectricSubViewModel selectedElectricSub;
        private ObservableCollection<ElectricSubViewModel> electricSubs;
        public static int CurrentElectricSubId = 1;

        public ObservableCollection<ElectricSubViewModel> ElectricSubs
        {
            //The list showing collection contents
            //is not updating without this notification
            get
            {
                return electricSubs;
            }
            set
            {
                if (electricSubs != value)
                {
                    electricSubs = value;
                    OnPropertyChanged("ElectricSubs");
                }
            }
        }
        public ElectricSubViewModel SelectedElectricSub
        {
            get
            {
                return selectedElectricSub;
            }
            set
            {
                if (selectedElectricSub != value)
                {
                    selectedElectricSub = value;
                    OnPropertyChanged("SelectedElectricSub");
                }
            }
        }

        public ElectricSubsListViewModel()
        {
            ElectricSubs = Database.GetElectricSubs();

            AddElectricSubCommand = new Command(
                execute: (obj) =>
                {
                    AddElectricSubWindow aesw = new AddElectricSubWindow();

                    if (aesw.ShowDialog() == true)
                    {
                        Database.AddElectricSub(new ElectricSub { Address = aesw.Address, Features = aesw.Features });
                        ElectricSubs = Database.GetElectricSubs();
                    }
                }
                );

            DeleteElectricSubCommand = new Command(
                execute: (obj) =>
                {
                    if(SelectedElectricSub != null)
                    {
                        Database.RemoveElectricSub(SelectedElectricSub.Id);
                        ElectricSubs = Database.GetElectricSubs();
                    }
                    else
                    {
                        MessageBox.Show("Выделите строчку в таблице домов!", "Ошибка!", MessageBoxButton.OK);
                    }
                }
                );

            EditElectricSubCommand = new Command(
                execute: (obj) =>
                {
                    if (SelectedElectricSub != null)
                    {
                    }
                    else
                    {
                    }
                }
                );
        }
        public Command AddElectricSubCommand { private set; get; }
        public Command DeleteElectricSubCommand { private set; get; }
        public Command EditElectricSubCommand { private set; get; }
    }
}
