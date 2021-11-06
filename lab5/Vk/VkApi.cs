
using System;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

using lab5.Api;
using lab5.Api.Methods.FriendsGet;
using lab5.Api.Methods.UsersGet;

using lab5.Vk.Methods.FriendsGet;
using lab5.Vk.Methods.UsersGet;

namespace lab5.Vk
{
    public class VkApi : IApiRequests
    {
        private readonly string _vkmethod = "https://api.vk.com/method/";
        private readonly WebClient _client = new() { Encoding = Encoding.UTF8 };

        private readonly string _version;
        private readonly int _clientId;
        private readonly string _token;

        private readonly IFriendsGet _friendsGet;
        private readonly IUsersGet _usersGet;

        public VkApi(string version, int cliendId, string token)
        {
            if (string.IsNullOrEmpty(version)) throw new Exception("Empty Vk Api version");
            if (string.IsNullOrEmpty(token)) throw new Exception("Empty token");

            _version = version;
            _clientId = cliendId;
            _token = token;

            _friendsGet = new VkFriendsGet(this, new VkFriendsGetParamsBuilder());
            _usersGet = new VkUsersGet(this, new VkUsersGetParamsBuilder());

            if (Request("account.getInfo").ContainsKey("error"))
            {
                throw new Exception("Authorization failed");
            }
        }

        public JObject Request(string method, params string[] param)
        {
            Uri request = new(_vkmethod + method + '?' + string.Join('&', param) + $"&access_token={_token}&v={_version}");
            return JObject.Parse(_client.DownloadString(request));
        }

        public IFriendsGet FriendsGet => _friendsGet;

        public IUsersGet UsersGet => _usersGet;
    }
}

