
namespace lab5.Api.Methods.UsersGet
{
    public interface IUsersGet
    {
        public IUsersGetParamsBuilder ParamsBuilder { get; }
        public SUserInfo Invoke(string id, SUsersGetParams @params);
    }
}

