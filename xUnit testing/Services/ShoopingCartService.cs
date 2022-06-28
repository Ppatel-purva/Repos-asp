using xUnit_testing.Models;

namespace xUnit_testing.Services
{
    public class ShoopingCartService:IShoppingCartService
    {
        public IEnumerable<ShoopingItem> GetAllItems() => throw new NotFiniteNumberException();
            public ShoppingItem Add(ShoppingItem newItem) => throw new NotFiniteNumberException();

      
    }
}
