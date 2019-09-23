using System.Collections.ObjectModel;
using System.Linq;

namespace Camomile
{
    public class Database
    {
        public static ObservableCollection<CompanyViewModel> GetCompanies()
        {
            ObservableCollection<CompanyViewModel> companies = new ObservableCollection<CompanyViewModel>();

            using(DataContext db = new DataContext())
            {
                var table = db.Companies;

                foreach (var r in table)
                {
                    companies.Add(new CompanyViewModel { Id=r.Id, Name=r.Name, ContractStatus=r.ContractStatus });
                }
            }
            return companies;
        }
        public static ObservableCollection<UserViewModel> GetUsers()
        {
            ObservableCollection<UserViewModel> users = new ObservableCollection<UserViewModel>();

            using (DataContext db = new DataContext())
            {
                var table = db.Users;

                foreach (var r in table)
                {
                    users.Add(new UserViewModel { Id = r.Id, Name = r.Name, Login = r.Login, Password = r.Password, CompanyId = r.CompanyId });
                }
            }
            return users;
        }
        public static void GetUsersByCompany(int id)
        {
            using (DataContext db = new DataContext())
            {
                var table = from u in db.Users
                            where u.CompanyId == id
                            select u;

                UsersListViewModel.Users.Clear();
                foreach (var r in table)
                {
                    UsersListViewModel.Users.Add(new UserViewModel { Id = r.Id, Name = r.Name, Login = r.Login, Password = r.Password, CompanyId = r.CompanyId });
                }
            }
        }
        public static void AddUser(User u)
        {
            using(DataContext db = new DataContext())
            {
                db.Users.Add(u);
                db.SaveChanges();
            }
        }
        public static void AddCompany(Company c)
        {
            using (DataContext db = new DataContext())
            {
                db.Companies.Add(c);
                db.SaveChanges();
            }
        }
        public static void RemoveUser(int id)
        {
            using(DataContext db = new DataContext())
            {
                var u = db.Users.Find(id);
                db.Users.Remove(u);
                db.SaveChanges();
            }
        }
        public static void RemoveCompany(int id)
        {
            using (DataContext db = new DataContext())
            {
                var c = db.Companies.Find(id);
                db.Companies.Remove(c);
                db.SaveChanges();
            }
        }
        public static void UpdateUser(User u)
        {
            using (DataContext db = new DataContext())
            {
                var updatedUser = db.Users.Find(u.Id);
                //Changing every user property in turn
                updatedUser.Name = u.Name;
                updatedUser.Login = u.Login;
                updatedUser.Password = u.Password;
                updatedUser.CompanyId = u.CompanyId;
                db.SaveChanges();
            }
        }
        public static void UpdateCompany(Company c)
        {
            using (DataContext db = new DataContext())
            {
                var updatedCompany = db.Companies.Find(c.Id);
                //Changing every company property in turn
                updatedCompany.Name = c.Name;
                updatedCompany.ContractStatus = c.ContractStatus;
                db.SaveChanges();
            }
        }
    }
}
