
using System;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using lab5.Extensions;

namespace lab5
{
    public class VkApi : IApiMethods
    {
        private readonly string _vkmethod = "https://api.vk.com/method/";
        private readonly WebClient _client = new() { Encoding = Encoding.UTF8 };

        private readonly string _version;
        private readonly int _clientId;
        private readonly string _token;

        public VkApi(string version, int cliendId, string token)
        {
            if (string.IsNullOrEmpty(version)) throw new Exception("Empty Vk Api version");
            if (string.IsNullOrEmpty(token)) throw new Exception("Empty token");

            _version = version;
            _clientId = cliendId;
            _token = token;

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

        public IUsersGetParamsBuilder UsersGetParamsBuilder => new VkUsersGetParamsBuilder();

        public JObject FriendsGet(string fields)
        {
            return Request("friends.get", "order=hints", $"fields={fields}");
        }

        public UserInfo UsersGet(string id, UsersGetParams param)
        {
            JToken info = Request("users.get", $"user_ids={id}", $"fields={param.Status + ',' + param.Photo + ',' + param.LastSeen}")["response"][0];
            VkUserInfoBuilder builder = new();

            builder.Name = info["first_name"]?.ToString() + ' ' + info["last_name"]?.ToString();
            builder.Status = info["status"]?.ToString();
            builder.Image = info["photo_200"]?.ToString();

            DateTime last_seen = UnixTimeToDateTime.Convert(info?["last_seen"]?["time"].ToString());
            builder.LastSeen = last_seen.ToString();
            return builder.GetProduct();
        }
    }
}


