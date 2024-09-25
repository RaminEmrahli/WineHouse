using NuGet.Configuration;

namespace WineHouse.Models
{
    public class ShoppingCartVM
    {
        public List<CardItem> CardItems { get; set; } = new List<CardItem>();
        public double Total { get; set; }
    }
}
