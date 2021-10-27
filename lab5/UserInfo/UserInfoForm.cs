
using System.Windows.Forms;

namespace lab5
{
    public partial class UserInfoForm : Form
    {
        public UserInfoForm(UserInfo info)
        {
            InitializeComponent();
            InitInfo(info);
        }

        private void InitInfo(UserInfo info)
        {
            nameBox.Text = info.Name;
            statusBox.Text = info.Status;
            imageBox.ImageLocation = info.Image;
            lastSeenBox.Text = info.LastSeen;
            anotherInfoBox.Text = info.Another;
        }
    }
}

