
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Web;

using lab5.Api;
using lab5.Vk;

namespace lab5
{
    public partial class VkAuthForm : Form
    {
        private readonly string _authorizeUri = "https://oauth.vk.com/authorize";
        private readonly string _authRedirUri = "https://oauth.vk.com/auth_redirect";
        private readonly string _redirectUri = "https://oauth.vk.com/blank.html";
        private readonly string _loginUri = "https://oauth.vk.com/login";

        private readonly string _version = "5.131";
        private int _clientId = 7979675;
        private string _token = string.Empty;

        public IApiRequests Api => new VkApi(_version, _clientId, _token);

        public VkAuthForm()
        {
            InitializeComponent();
        }

        private void AuthFormShown(object sender, EventArgs e)
        {
            _webBrowser.Navigate(
                new Uri(  $"{_authorizeUri}?"
                        + $"client_id={_clientId}&display=page&redirect_uri={_redirectUri}"
                        +  "&scope=friends"
                        + $"&response_type=token&v={_version}&state=123456"
                )
            );
        }

        private void WebBrowserNavigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            string uri = HttpUtility.UrlDecode(Uri.UnescapeDataString(e.Url.ToString()));
            if (uri.StartsWith(_authorizeUri) || uri.StartsWith(_loginUri) || uri.StartsWith(_authRedirUri)) return;

            if (!uri.StartsWith(_redirectUri))
            {
                DialogResult = DialogResult.No;
                return;
            }

            var parameters = (from param in uri.Split('#')[1].Split('&')
                              let parts = param.Split('=')
                              select new
                              {
                                  Name = parts[0],
                                  Value = parts[1]
                              }
                             ).ToDictionary(v => v.Name, v => v.Value);

            _token = parameters["access_token"];
            DialogResult = DialogResult.Yes;
        }
    }
}

