
namespace lab5.Api.Methods.UsersGet
{
    public interface IUsersGetParamsBuilder
    {
        void SetStatus();
        void SetLastSeen();
        void SetPhoto();
        SUsersGetParams GetProduct();
    }
}

