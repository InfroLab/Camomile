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
            ObservableCollection<ElectricSubViewModel> electricSubs = new ObservableCollection<ElectricSubViewModel>();

            using (DataContext db = new DataContext())
            {
                var table = db.ElectricSubs;

                foreach (var r in table)
                {
                    electricSubs.Add(new ElectricSubViewModel { Id = r.Id, Address = r.Address, Features = r.Features });
                }
            }
            return electricSubs;
        }
        public static ObservableCollection<GasPlantViewModel> GetGasPlants()
        {
            ObservableCollection<GasPlantViewModel> gasPlants = new ObservableCollection<GasPlantViewModel>();

            using (DataContext db = new DataContext())
            {
                var table = db.GasPlants;

                foreach (var r in table)
                {
                    gasPlants.Add(new GasPlantViewModel { Id = r.Id, Address = r.Address, Features = r.Features });
                }
            }
            return gasPlants;
        }
        public static ObservableCollection<FlatViewModel> GetFlats()
        {
            ObservableCollection<FlatViewModel> flats = new ObservableCollection<FlatViewModel>();

            using (DataContext db = new DataContext())
            {
                var table = db.Flats;

                foreach (var r in table)
                {
                    flats.Add(new FlatViewModel { Id = r.Id, Address = r.Address, Area=r.Area, AreaPerPerson=r.AreaPerPerson, Balcony=r.Balcony, Registration=r.Registration, Renter=r.Renter, Rooms=r.Rooms });
                }
            }
            return flats;
        }
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
        public static void AddElectricSub(ElectricSub e)
        {
            using (DataContext db = new DataContext())
            {
                db.ElectricSubs.Add(e);
                db.SaveChanges();
            }
        }
        public static void RemoveElectricSub(int id)
        {
            using (DataContext db = new DataContext())
            {
                var e = db.ElectricSubs.Find(id);
                db.ElectricSubs.Remove(e);
                db.SaveChanges();
            }
        }
        public static void AddGasPlant(GasPlant g)
        {
            using (DataContext db = new DataContext())
            {
                db.GasPlants.Add(g);
                db.SaveChanges();
            }
        }
        public static void RemoveGasPlant(int id)
        {
            using (DataContext db = new DataContext())
            {
                var g = db.GasPlants.Find(id);
                db.GasPlants.Remove(g);
                db.SaveChanges();
            }
        }
        public static void AddFlat(Flat f)
        {
            using (DataContext db = new DataContext())
            {
                db.Flats.Add(f);
                db.SaveChanges();
            }
        }
        public static void RemoveFlat(int id)
        {
            using (DataContext db = new DataContext())
            {
                var f = db.Flats.Find(id);
                db.Flats.Remove(f);
                db.SaveChanges();
            }
        }
        public static ObservableCollection<HouseViewModel> GetHousesByAddress(string Address)
        {
            using (DataContext db = new DataContext())
            {
                if (Address != "")
                {
                    var table = from record in db.Houses
                                where record.Address == Address
                                select record;

                    ObservableCollection<HouseViewModel> houses = new ObservableCollection<HouseViewModel>();
                    foreach (var r in table)
                    {
                        houses.Add(new HouseViewModel { Id = r.Id, Address = r.Address, Antenna = r.Antenna, CabelTV = r.CabelTV, ColdWater = r.ColdWater, Delivery = r.Delivery, Elevator = r.Elevator, EntranceNumber = r.EntranceNumber, Flats = r.Flats, Floors = r.Floors, Gas = r.Gas, HotWater = r.HotWater, ProjectNumber = r.ProjectNumber, Radio = r.Radio, Settlement = r.Settlement, Telephone = r.Telephone });
                    }
                    return houses;
                }
                else
                {
                    var table = db.Houses;

                    ObservableCollection<HouseViewModel> houses = new ObservableCollection<HouseViewModel>();
                    foreach (var r in table)
                    {
                        houses.Add(new HouseViewModel { Id = r.Id, Address = r.Address, Antenna = r.Antenna, CabelTV = r.CabelTV, ColdWater = r.ColdWater, Delivery = r.Delivery, Elevator = r.Elevator, EntranceNumber = r.EntranceNumber, Flats = r.Flats, Floors = r.Floors, Gas = r.Gas, HotWater = r.HotWater, ProjectNumber = r.ProjectNumber, Radio = r.Radio, Settlement = r.Settlement, Telephone = r.Telephone });
                    }
                    return houses;
                }
            }
        }
        public static ObservableCollection<ElectricSubViewModel> GetElectricSubsByAddress(string Address)
        {
            using (DataContext db = new DataContext())
            {
                if (Address != "")
                {
                    var table = from record in db.ElectricSubs
                                where record.Address == Address
                                select record;

                    ObservableCollection<ElectricSubViewModel> electricSubs = new ObservableCollection<ElectricSubViewModel>();
                    foreach (var r in table)
                    {
                        electricSubs.Add(new ElectricSubViewModel { Id = r.Id, Address = r.Address, Features = r.Features });
                    }
                    return electricSubs;
                }
                else
                {
                    var table = db.ElectricSubs;

                    ObservableCollection<ElectricSubViewModel> electricSubs = new ObservableCollection<ElectricSubViewModel>();
                    foreach (var r in table)
                    {
                        electricSubs.Add(new ElectricSubViewModel { Id = r.Id, Address = r.Address, Features = r.Features });
                    }
                    return electricSubs;
                }
            }
        }
        public static ObservableCollection<FlatViewModel> GetFlatsByAddress(string Address)
        {
            using (DataContext db = new DataContext())
            {
                if (Address != "")
                {
                    var table = from record in db.Flats
                                where record.Address == Address
                                select record;

                    ObservableCollection<FlatViewModel> flats = new ObservableCollection<FlatViewModel>();
                    foreach (var r in table)
                    {
                        flats.Add(new FlatViewModel { Id = r.Id, Address = r.Address, Area = r.Area, AreaPerPerson = r.AreaPerPerson, Balcony = r.Balcony, Registration = r.Registration, Renter = r.Renter, Rooms = r.Rooms });
                    }
                    return flats;
                }
                else
                {
                    var table = db.Flats;

                    ObservableCollection<FlatViewModel> flats = new ObservableCollection<FlatViewModel>();
                    foreach (var r in table)
                    {
                        flats.Add(new FlatViewModel { Id = r.Id, Address = r.Address, Area = r.Area, AreaPerPerson = r.AreaPerPerson, Balcony = r.Balcony, Registration = r.Registration, Renter = r.Renter, Rooms = r.Rooms });
                    }
                    return flats;
                }
            }
        }
        public static ObservableCollection<GasPlantViewModel> GetGasPlantsByAddress(string Address)
        {
            using (DataContext db = new DataContext())
            {
                if (Address != "")
                {
                    var table = from record in db.GasPlants
                                where record.Address == Address
                                select record;

                    ObservableCollection<GasPlantViewModel> gasPlants = new ObservableCollection<GasPlantViewModel>();
                    foreach (var r in table)
                    {
                        gasPlants.Add(new GasPlantViewModel { Id = r.Id, Address = r.Address, Features = r.Features });
                    }
                    return gasPlants;
                }
                else
                {
                    var table = db.GasPlants;

                    ObservableCollection<GasPlantViewModel> gasPlants = new ObservableCollection<GasPlantViewModel>();
                    foreach (var r in table)
                    {
                        gasPlants.Add(new GasPlantViewModel { Id = r.Id, Address = r.Address, Features = r.Features });
                    }
                    return gasPlants;
                }
            }
        }
        public static void UpdateHouse(House h)
        {
            using (DataContext db = new DataContext())
            {
                var updatedHouse = db.Houses.Find(h.Id);
                //Changing every company property in turn
                updatedHouse.Address = h.Address;
                updatedHouse.EntranceNumber = h.EntranceNumber;
                updatedHouse.Floors = h.Floors;
                updatedHouse.Flats = h.Flats;
                updatedHouse.Elevator = h.Elevator;
                updatedHouse.HotWater = h.HotWater;
                updatedHouse.ColdWater = h.ColdWater;
                updatedHouse.Gas = h.Gas;
                updatedHouse.Antenna = h.Antenna;
                updatedHouse.CabelTV = h.CabelTV;
                updatedHouse.Telephone = h.Telephone;
                updatedHouse.Radio = h.Radio;
                updatedHouse.ProjectNumber = h.ProjectNumber;
                updatedHouse.Settlement = h.Settlement;
                updatedHouse.Delivery = h.Delivery;
                db.SaveChanges();
            }
        }
    }
}
