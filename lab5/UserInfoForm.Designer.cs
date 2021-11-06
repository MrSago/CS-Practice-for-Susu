
namespace lab5
{
    partial class UserInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lastSeenBox = new System.Windows.Forms.TextBox();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.anotherInfoBox = new System.Windows.Forms.RichTextBox();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Controls.Add(this.lastSeenBox);
            this.mainPanel.Controls.Add(this.statusBox);
            this.mainPanel.Controls.Add(this.nameBox);
            this.mainPanel.Controls.Add(this.anotherInfoBox);
            this.mainPanel.Controls.Add(this.imageBox);
            this.mainPanel.Location = new System.Drawing.Point(12, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(776, 426);
            this.mainPanel.TabIndex = 0;
            // 
            // lastSeenBox
            // 
            this.lastSeenBox.Location = new System.Drawing.Point(475, 3);
            this.lastSeenBox.Name = "lastSeenBox";
            this.lastSeenBox.ReadOnly = true;
            this.lastSeenBox.Size = new System.Drawing.Size(284, 23);
            this.lastSeenBox.TabIndex = 4;
            // 
            // statusBox
            // 
            this.statusBox.Location = new System.Drawing.Point(209, 32);
            this.statusBox.Name = "statusBox";
            this.statusBox.ReadOnly = true;
            this.statusBox.Size = new System.Drawing.Size(564, 23);
            this.statusBox.TabIndex = 3;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(209, 3);
            this.nameBox.Name = "nameBox";
            this.nameBox.ReadOnly = true;
            this.nameBox.Size = new System.Drawing.Size(240, 23);
            this.nameBox.TabIndex = 2;
            // 
            // anotherInfoBox
            // 
            this.anotherInfoBox.Location = new System.Drawing.Point(3, 209);
            this.anotherInfoBox.Name = "anotherInfoBox";
            this.anotherInfoBox.ReadOnly = true;
            this.anotherInfoBox.Size = new System.Drawing.Size(770, 214);
            this.anotherInfoBox.TabIndex = 1;
            this.anotherInfoBox.Text = "";
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(3, 3);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(200, 200);
            this.imageBox.TabIndex = 0;
            this.imageBox.TabStop = false;
            // 
            // UserInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Name = "UserInfoForm";
            this.Text = "VkApp - Информация о пользователе";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.RichTextBox anotherInfoBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.TextBox lastSeenBox;
    }
}

