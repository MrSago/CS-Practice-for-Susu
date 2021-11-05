﻿
using System;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using lab5.Extensions;

namespace lab5
{
    public partial class MainForm : Form
    {
        private readonly IApiMethods _api;

        public MainForm(IApiMethods api)
        {
            _api = api;
            InitializeComponent();
            InitTable();
        }

        private void InitTable()
        {
            JToken friendsInfo;
            int cnt;

            try
            {
                JObject obj = _api.FriendsGet("bdate,city,status");
                friendsInfo = obj["response"]["items"];
                cnt = int.Parse(obj.SelectToken("response.count").ToString());
            }
            catch
            {
                MessageBox.Show(
                    "Ошибка заполнения таблицы",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            for (int i = 0; i < cnt; ++i)
            {
                DataGridViewRow row = (DataGridViewRow)_dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = friendsInfo[i]["id"]?.ToString();
                row.Cells[1].Value = friendsInfo[i]["first_name"]?.ToString() + ' ' +
                                     friendsInfo[i]["last_name"]?.ToString();
                row.Cells[2].Value = friendsInfo[i]["bdate"]?.ToString();
                row.Cells[3].Value = friendsInfo[i]["city"]?["title"]?.ToString();
                row.Cells[4].Value = friendsInfo[i]["status"]?.ToString();
                _dataGridView1.Rows.Add(row);
            }
        }

        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Лабораторная работа №5 - VK App\nГордеев А.С. КЭ-201\nЮУрГУ ВШЭКН 2021-2022",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Question
            );
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!WinInetHelper.SupressCookiePersist())
            {
                MessageBox.Show(
                    "Ошибка очистки куки",
                    "Куки",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            Program.Relogin = true;
            Close();
        }

        private void _dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string user_id = _dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            IUsersGetParamsBuilder paramBuilder = _api.UsersGetParamsBuilder;
            paramBuilder.SetStatus();
            paramBuilder.SetPhoto();
            paramBuilder.SetLastSeen();
            UsersGetParams param = paramBuilder.GetProduct();

            UserInfo userInfo = _api.UsersGet(user_id, param);

            UserInfoForm userInfoForm = new(userInfo);
            userInfoForm.ShowDialog();




            //_ = new UserInfoForm(builder.GetProduct()).ShowDialog();
        }
    }
}

