using xUnit_testing.Models;

namespace xUnit_testing.Services
{
    public interface IShoopingCartService   
    {
        IEnumerable<ShoppingItem> GetAllItems();
        ShoppingItem Add(ShoppingItem shoppingItem) => throw new NativeOverlapped;
        object GetById(int id);
        object Add(string value);
    }
}
