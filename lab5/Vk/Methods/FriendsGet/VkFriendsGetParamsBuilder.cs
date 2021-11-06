
using lab5.Api.Methods.FriendsGet;

namespace lab5.Vk.Methods.FriendsGet
{
    public class VkFriendsGetParamsBuilder : IFriendsGetParamsBuilder
    {
        private SFriendsGetParams _product;

        public VkFriendsGetParamsBuilder()
        {
            Reset();
        }

        public void SetBDate()
        {
            _product.BDate = "bdate";
        }

        public void SetCity()
        {
            _product.City = "city";
        }

        public void SetStatus()
        {
            _product.Status = "status";
        }
        public SFriendsGetParams GetProduct()
        {
            SFriendsGetParams userInfo = _product;
            Reset();
            return userInfo;
        }

        private void Reset()
        {
            _product = new();
        }
    }
}

