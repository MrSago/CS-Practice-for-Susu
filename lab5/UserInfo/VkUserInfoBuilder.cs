
namespace lab5
{
    class VkUserInfoBuilder : IUserInfoBuilder
    {
        private UserInfo _product;

        public VkUserInfoBuilder()
        {
            Reset();
        }

        public string Name { set { _product.SetName(value); } }
        public string Status { set { _product.SetStatus(value); } }
        public string Image { set { _product.SetImage(value); } }
        public string LastSeen { set { _product.SetLastSeen(value); } }
        public string Another { set { _product.SetAnother(value); } }

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

