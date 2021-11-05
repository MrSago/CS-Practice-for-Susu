
namespace lab5
{
    public class VkUserInfoBuilder : IUserInfoBuilder
    {
        private UserInfo _product;

        public VkUserInfoBuilder()
        {
            Reset();
        }

        public string Name { set { _product.Name = value; } }
        public string Status { set { _product.Status = value; } }
        public string Image { set { _product.Image = value; } }
        public string LastSeen { set { _product.LastSeen = value; } }
        public string Another { set { _product.Another = value; } }

        public UserInfo GetProduct()
        {
            UserInfo userInfo = _product;
            Reset();
            return userInfo;
        }

        private void Reset()
        {
            _product = new();
        }
    }
}

