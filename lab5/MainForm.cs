
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
using System.Net.Http.Headers;

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

        private void InitTable()
        {
            var client = new WebClient { Encoding = Encoding.UTF8 };
            JObject friendsInfo;
            int cnt;

            try
            {
                friendsInfo = JObject.Parse(client.DownloadString($"https://api.vk.com/method/friends.get?order=hints&fields=bdate,city,status&access_token={_token}&v={Program.ApiVkVer}"));
                cnt = int.Parse(friendsInfo.SelectToken("response.count").ToString());
            }
            catch
            {
                MessageBox.Show(
                    "Ошибка заполнения таблицы",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            for (int i = 0; i < cnt; ++i)
            {
                DataGridViewRow row = (DataGridViewRow)_dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = friendsInfo["response"]["items"][i]["id"]?.ToString();
                row.Cells[1].Value = friendsInfo["response"]["items"][i]["first_name"]?.ToString() + ' ' +
                                     friendsInfo["response"]["items"][i]["last_name"]?.ToString();
                row.Cells[2].Value = friendsInfo["response"]["items"][i]["bdate"]?.ToString();
                row.Cells[3].Value = friendsInfo["response"]["items"][i]["city"]?["title"]?.ToString();
                row.Cells[4].Value = friendsInfo["response"]["items"][i]["status"]?.ToString();
                _dataGridView1.Rows.Add(row);
            }
        }

        private void AboutAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Лабораторная работа №5\nГордеев Александр Сергеевич КЭ-201\n2021-2022",
                "Об авторе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Question
            );
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Program.Relogin = true;
            Close();
        }
    }
}

