
using System;
using Newtonsoft.Json.Linq;

using lab5.Api;
using lab5.Api.Methods.UsersGet;
using lab5.Extensions;

namespace lab5.Vk.Methods.UsersGet
{
    public class VkUsersGet : IUsersGet
    {
        private readonly VkApi _api;
        private readonly VkUsersGetParamsBuilder _paramsBuilder;

        public VkUsersGet(VkApi api, VkUsersGetParamsBuilder paramsBuilder)
        {
            _api = api;
            _paramsBuilder = paramsBuilder;
        }

        public IUsersGetParamsBuilder ParamsBuilder => _paramsBuilder;

        public SUserInfo Invoke(string id, SUsersGetParams @params)
        {
            JToken info = _api.Request("users.get", $"user_ids={id}", $"fields={@params.Status + ',' + @params.Photo + ',' + @params.LastSeen}")["response"][0];

            SUserInfo userInfo = new();
            userInfo.Id = id;
            userInfo.FirstName = info["first_name"]?.ToString();
            userInfo.LastName = info["last_name"]?.ToString();
            userInfo.Status = info["status"]?.ToString();
            userInfo.Image = info["photo_200"]?.ToString();

            DateTime last_seen = UnixTimeToDateTime.Convert(info["last_seen"]?["time"]?.ToString());
            userInfo.LastSeen = last_seen.ToString();

            return userInfo;
        }
    }
}

