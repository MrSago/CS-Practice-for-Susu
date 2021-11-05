
using Newtonsoft.Json.Linq;

namespace lab5
{
    public interface IApiMethods
    {
        public JObject Request(string method, params string[] param);


        public JObject FriendsGet(string fields);

        public IUsersGetParamsBuilder UsersGetParamsBuilder { get; }
        public UserInfo UsersGet(string id, UsersGetParams param);
    }
}

