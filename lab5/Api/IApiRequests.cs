
using Newtonsoft.Json.Linq;

using lab5.Api.Methods.UsersGet;
using lab5.Api.Methods.FriendsGet;

namespace lab5.Api
{
    public interface IApiRequests
    {
        public JObject Request(string method, params string[] @params);
        public IFriendsGet FriendsGet { get; }
        public IUsersGet UsersGet { get; }
    }
}

