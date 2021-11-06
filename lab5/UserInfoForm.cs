
using System.Windows.Forms;

using lab5.Api;

namespace lab5
{
    public partial class UserInfoForm : Form
    {
        public UserInfoForm(SUserInfo info)
        {
            InitializeComponent();
            InitInfo(info);
        }

        private void InitInfo(SUserInfo info)
        {
            nameBox.Text = info.FirstName + ' ' + info.LastName;
            statusBox.Text = info.Status;
            imageBox.ImageLocation = info.Image;
            lastSeenBox.Text = info.LastSeen;
            anotherInfoBox.Text = info.Another;
        }
    }
}

