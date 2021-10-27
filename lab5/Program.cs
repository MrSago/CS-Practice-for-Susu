
using System;
using System.Windows.Forms;

namespace lab5
{
    static class Program
    {
        public static bool Relogin = false;

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            do
            {
                Relogin = false;
                using AuthForm authForm = new();
                if (authForm.ShowDialog() == DialogResult.Yes)
                {
                    Application.Run(new MainForm(authForm.Api));
                }
            }
            while (Relogin);
        }
    }
}

