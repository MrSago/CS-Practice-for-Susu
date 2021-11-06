
using System.Collections.Generic;

namespace lab5.Api.Methods.FriendsGet
{
    public interface IFriendsGet
    {
        public IFriendsGetParamsBuilder ParamsBuilder { get; }
        public IEnumerable<SUserInfo> Invoke(SFriendsGetParams @params);
    }
}

