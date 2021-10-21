
namespace lab5
{
    partial class AuthForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this._webBrowser = new System.Windows.Forms.WebBrowser();
            this._webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this._webBrowser.Location = new System.Drawing.Point(0, 0);
            this._webBrowser.Name = "webBrowser";
            this._webBrowser.Size = new System.Drawing.Size(700, 400);
            this._webBrowser.TabIndex = 0;
            this._webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.WebBrowserNavigated);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Text = "AuthForm";
            this.Controls.Add(this._webBrowser);
            this.Shown += new System.EventHandler(this.AuthFormShown);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.WebBrowser _webBrowser;
    }
}

