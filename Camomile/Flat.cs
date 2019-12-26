/// <summary>
/// Model for Companies table
/// </summary>
namespace Camomile
{
    public class Flat
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Rooms { get; set; }
        public string Renter { get; set; }
        public int Registration { get; set; }
        public int Area { get; set; }
        public int AreaPerPerson { get; set; }
        public string Balcony { get; set; }
    }
}
