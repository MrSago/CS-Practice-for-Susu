
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json.Linq;

namespace lab5
{
    public partial class MainForm : Form
    {
        public MainForm(string token)
        {
            _token = token;
            InitializeComponent();
        }

        public string GetFriendsInfo()
        {
            var client = new WebClient {Encoding = Encoding.UTF8};
            string json = client.DownloadString($"https://api.vk.com/method/friends.get?order=hints&fields=bdate&access_token={_token}&v={Program.ApiVkVer}");
            JObject jsonObject = JObject.Parse(json);
            return jsonObject.ToString();
        }
    }
}

