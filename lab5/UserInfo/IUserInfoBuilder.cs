
namespace lab5
{
    public interface IUserInfoBuilder
    {
        string Name { set; }
        string Status { set; }
        string Image { set; }
        string LastSeen { set; }
        string Another { set; }
        UserInfo GetProduct();
    }
}

