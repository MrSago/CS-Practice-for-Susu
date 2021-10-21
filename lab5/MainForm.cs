
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
            InitTable();
        }

        private JObject GetFriendsInfo()
        {
            var client = new WebClient {Encoding = Encoding.UTF8};
            string json = client.DownloadString($"https://api.vk.com/method/friends.get?order=hints&fields=bdate,city,status&access_token={_token}&v={Program.ApiVkVer}");
            return JObject.Parse(json);
        }

        private void InitTable()
        {
            JObject friendsInfo = GetFriendsInfo();
            int cnt = int.Parse(friendsInfo.SelectToken("response.count").ToString());
            for (int i = 0; i < cnt; ++i)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();

                row.Cells[0].Value = friendsInfo["response"]["items"][i]["id"]?.ToString();

                row.Cells[1].Value = friendsInfo["response"]["items"][i]["first_name"]?.ToString() + ' ' +
                                     friendsInfo["response"]["items"][i]["last_name"]?.ToString();

                row.Cells[2].Value = friendsInfo["response"]["items"][i]["bdate"]?.ToString();

                row.Cells[3].Value = friendsInfo["response"]["items"][i]["city"]?["title"]?.ToString();

                row.Cells[4].Value = friendsInfo["response"]["items"][i]["status"]?.ToString();

                dataGridView1.Rows.Add(row);
            }
        }
    }
}

