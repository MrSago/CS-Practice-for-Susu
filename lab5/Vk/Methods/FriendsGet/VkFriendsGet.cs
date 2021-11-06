
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

using lab5.Api;
using lab5.Api.Methods.FriendsGet;

namespace lab5.Vk.Methods.FriendsGet
{
    public class VkFriendsGet : IFriendsGet
    {
        private readonly VkApi _api;
        private readonly VkFriendsGetParamsBuilder _paramsBuilder;

        public VkFriendsGet(VkApi api, VkFriendsGetParamsBuilder paramsBuilder)
        {
            _api = api;
            _paramsBuilder = paramsBuilder;
        }

        public IFriendsGetParamsBuilder ParamsBuilder => _paramsBuilder;

        public IEnumerable<SUserInfo> Invoke(SFriendsGetParams @params)
        {
            string fields = @params.BDate + ',' + @params.City + ',' + @params.Status;

            JObject obj = _api.Request("friends.get", "order=hints", $"fields={fields}");
            JToken friendsInfo = obj["response"]["items"];
            int cnt = int.Parse(obj.SelectToken("response.count").ToString());

            List<SUserInfo> result = new();
            for (int i = 0; i < cnt; ++i)
            {
                SUserInfo userInfo = new();
                userInfo.Id = friendsInfo[i]["id"]?.ToString();
                userInfo.FirstName = friendsInfo[i]["first_name"]?.ToString();
                userInfo.LastName = friendsInfo[i]["last_name"]?.ToString();
                userInfo.BDate = friendsInfo[i]["bdate"]?.ToString();
                userInfo.City = friendsInfo[i]["city"]?["title"]?.ToString();
                userInfo.Status = friendsInfo[i]["status"]?.ToString();
                result.Add(userInfo);
            }

            return result;
        }
    }
}

