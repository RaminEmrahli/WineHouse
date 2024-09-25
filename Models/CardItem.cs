using WineHouse.Entities;

namespace WineHouse.Models
{
    public class CardItem
    {
        public int Id { get; set; }

        public Wine Wine { get; set; }
        public int Amount { get; set; }
    }
}
