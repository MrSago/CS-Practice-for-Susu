
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using lab5.Api;
using lab5.Api.Methods.FriendsGet;
using lab5.Api.Methods.UsersGet;
using lab5.Extensions;

namespace lab5
{
    public partial class MainForm : Form
    {
        private readonly IApiRequests _api;

        public MainForm(IApiRequests api)
        {
            _api = api;
            InitializeComponent();
            InitTable();
        }

        private void InitTable()
        {
            IFriendsGetParamsBuilder paramsBuilder = _api.FriendsGet.ParamsBuilder;
            paramsBuilder.SetBDate();
            paramsBuilder.SetCity();
            paramsBuilder.SetStatus();
            SFriendsGetParams @params = paramsBuilder.GetProduct();

            IEnumerable<SUserInfo> friendsInfo;
            try
            {
                 friendsInfo = _api.FriendsGet.Invoke(@params);
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

            foreach (SUserInfo user in friendsInfo)
            {
                DataGridViewRow row = (DataGridViewRow)_dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = user.Id;
                row.Cells[1].Value = user.FirstName + ' ' + user.LastName;
                row.Cells[2].Value = user.BDate;
                row.Cells[3].Value = user.City;
                row.Cells[4].Value = user.Status;
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

            IUsersGetParamsBuilder paramsBuilder = _api.UsersGet.ParamsBuilder;
            paramsBuilder.SetStatus();
            paramsBuilder.SetPhoto();
            paramsBuilder.SetLastSeen();
            SUsersGetParams @params = paramsBuilder.GetProduct();

            SUserInfo userInfo;
            try
            {
                userInfo = _api.UsersGet.Invoke(user_id, @params);
            }
            catch
            {
                MessageBox.Show(
                    "Ошибка получения данных о пользователе",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            UserInfoForm userInfoForm = new(userInfo);
            userInfoForm.ShowDialog();
        }
    }
}

