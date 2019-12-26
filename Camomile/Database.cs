using System.Collections.ObjectModel;
using System.Linq;

namespace Camomile
{
    public class Database
    {
        public static ObservableCollection<HouseViewModel> GetHouses()
        {
            ObservableCollection<HouseViewModel> houses = new ObservableCollection<HouseViewModel>();

            using(DataContext db = new DataContext())
            {
                var table = db.Houses;

                foreach (var r in table)
                {
                    houses.Add(new HouseViewModel { Id=r.Id, Address=r.Address, Antenna=r.Antenna, CabelTV=r.CabelTV, ColdWater=r.ColdWater, Delivery=r.Delivery, Elevator=r.Elevator, EntranceNumber=r.EntranceNumber, Flats=r.Flats, Floors=r.Floors, Gas=r.Gas, HotWater=r.HotWater, ProjectNumber=r.ProjectNumber, Radio=r.Radio, Settlement=r.Settlement, Telephone=r.Telephone });
                }
            }
            return houses;
        }
        public static ObservableCollection<ElectricSubViewModel> GetElectricSubs()
        {
            ObservableCollection<ElectricSubViewModel> houses = new ObservableCollection<ElectricSubViewModel>();

            using (DataContext db = new DataContext())
            {
                var table = db.ElectricSubs;

                foreach (var r in table)
                {
                    houses.Add(new HouseViewModel { Id = r.Id, Address = r.Address, Features = r.Features });
                }
            }
            return houses;
        }
        //public static ObservableCollection<UserViewModel> GetUsers()
        //{
        //    ObservableCollection<UserViewModel> users = new ObservableCollection<UserViewModel>();

        //    using (DataContext db = new DataContext())
        //    {
        //        var table = db.Users;

        //        foreach (var r in table)
        //        {
        //            users.Add(new UserViewModel { Id = r.Id, Name = r.Name, Login = r.Login, Password = r.Password, CompanyId = r.CompanyId });
        //        }
        //    }
        //    return users;
        //}
        //public static void GetUsersByCompany(int id)
        //{
        //    using (DataContext db = new DataContext())
        //    {
        //        var table = from u in db.Users
        //                    where u.CompanyId == id
        //                    select u;

        //        UsersListViewModel.Users.Clear();
        //        foreach (var r in table)
        //        {
        //            UsersListViewModel.Users.Add(new UserViewModel { Id = r.Id, Name = r.Name, Login = r.Login, Password = r.Password, CompanyId = r.CompanyId });
        //        }
        //    }
        //}
        public static void AddHouse(House h)
        {
            using (DataContext db = new DataContext())
            {
                db.Houses.Add(h);
                db.SaveChanges();
            }
        }
        public static void RemoveHouse(int id)
        {
            using (DataContext db = new DataContext())
            {
                var h = db.Houses.Find(id);
                db.Houses.Remove(h);
                db.SaveChanges();
            }
        }
        public static void AddElectricSub(House e)
        {
            using (DataContext db = new DataContext())
            {
                db.Houses.Add(e);
                db.SaveChanges();
            }
        }
        public static void RemoveElectricSub(int id)
        {
            using (DataContext db = new DataContext())
            {
                var e = db.Houses.Find(id);
                db.Houses.Remove(e);
                db.SaveChanges();
            }
        }
        //public static void RemoveCompany(int id)
        //{
        //    using (DataContext db = new DataContext())
        //    {
        //        var c = db.Companies.Find(id);
        //        db.Companies.Remove(c);
        //        db.SaveChanges();
        //    }
        //}
        //public static void UpdateUser(User u)
        //{
        //    using (DataContext db = new DataContext())
        //    {
        //        var updatedUser = db.Users.Find(u.Id);
        //        //Changing every user property in turn
        //        updatedUser.Name = u.Name;
        //        updatedUser.Login = u.Login;
        //        updatedUser.Password = u.Password;
        //        updatedUser.CompanyId = u.CompanyId;
        //        db.SaveChanges();
        //    }
        //}
        //public static void UpdateCompany(Company c)
        //{
        //    using (DataContext db = new DataContext())
        //    {
        //        var updatedCompany = db.Companies.Find(c.Id);
        //        //Changing every company property in turn
        //        updatedCompany.Name = c.Name;
        //        updatedCompany.ContractStatus = c.ContractStatus;
        //        db.SaveChanges();
        //    }
        //}
    }
}
