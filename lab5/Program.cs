
using System;
using System.Windows.Forms;

namespace lab5
{
    static class Program
    {
        public static readonly string ApiVkVer = "5.131";

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            using AuthForm authForm = new();
            if (authForm.ShowDialog() == DialogResult.Yes)
            {
                Application.Run(new MainForm(authForm.Token));
            }
        }
    }
}

