
using Newtonsoft.Json.Linq;

namespace lab5
{
    public interface IApiMethods
    {
        JObject Request(string method, params string[] param);
        JObject FriendsGet(string fields);
        JToken UsersGet(string id, string fields);
    }
}

