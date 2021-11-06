
using lab5.Api.Methods.UsersGet;

namespace lab5.Vk.Methods.UsersGet
{
    public class VkUsersGetParamsBuilder : IUsersGetParamsBuilder
    {
        private SUsersGetParams _product;

        public VkUsersGetParamsBuilder()
        {
            Reset();
        }

        public void SetStatus()
        {
            _product.Status = "status";
        }

        public void SetPhoto()
        {
            _product.Photo = "photo_200";
        }

        public void SetLastSeen()
        {
            _product.LastSeen = "last_seen";
        }
        public SUsersGetParams GetProduct()
        {
            SUsersGetParams userInfo = _product;
            Reset();
            return userInfo;
        }

        private void Reset()
        {
            _product = new();
        }
    }
}

