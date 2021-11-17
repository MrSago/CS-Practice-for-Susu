
namespace lab5
{
    partial class MainForm
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
            this._dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).BeginInit();
            this._menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dataGridView1
            // 
            this._dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.bdate,
            this.city,
            this.status});
            this._dataGridView1.Location = new System.Drawing.Point(12, 27);
            this._dataGridView1.Name = "_dataGridView1";
            this._dataGridView1.RowTemplate.Height = 25;
            this._dataGridView1.Size = new System.Drawing.Size(983, 491);
            this._dataGridView1.TabIndex = 0;
            this._dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._dataGridView1_CellContentClick);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 43;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.name.HeaderText = "Имя";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 56;
            // 
            // bdate
            // 
            this.bdate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bdate.HeaderText = "Дата Рождения";
            this.bdate.Name = "bdate";
            this.bdate.ReadOnly = true;
            this.bdate.Width = 106;
            // 
            // city
            // 
            this.city.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.city.HeaderText = "Город";
            this.city.Name = "city";
            this.city.ReadOnly = true;
            this.city.Width = 65;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.status.HeaderText = "Статус";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // _menuStrip1
            // 
            this._menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuToolStripMenuItem});
            this._menuStrip1.Location = new System.Drawing.Point(0, 0);
            this._menuStrip1.Name = "_menuStrip1";
            this._menuStrip1.Size = new System.Drawing.Size(1007, 24);
            this._menuStrip1.TabIndex = 1;
            this._menuStrip1.Text = "menuStrip1";
            // 
            // _menuToolStripMenuItem
            // 
            this._menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._logoutToolStripMenuItem,
            this._aboutProgramToolStripMenuItem});
            this._menuToolStripMenuItem.Name = "_menuToolStripMenuItem";
            this._menuToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this._menuToolStripMenuItem.Text = "Меню";
            // 
            // _logoutToolStripMenuItem
            // 
            this._logoutToolStripMenuItem.Name = "_logoutToolStripMenuItem";
            this._logoutToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this._logoutToolStripMenuItem.Text = "Выйти из аккаунта";
            this._logoutToolStripMenuItem.Click += new System.EventHandler(this.LogoutToolStripMenuItem_Click);
            // 
            // _aboutProgramToolStripMenuItem
            // 
            this._aboutProgramToolStripMenuItem.Name = "_aboutProgramToolStripMenuItem";
            this._aboutProgramToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this._aboutProgramToolStripMenuItem.Text = "О программе";
            this._aboutProgramToolStripMenuItem.Click += new System.EventHandler(this.AboutProgramToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 530);
            this.Controls.Add(this._dataGridView1);
            this.Controls.Add(this._menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this._menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "VK App - Список друзей";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).EndInit();
            this._menuStrip1.ResumeLayout(false);
            this._menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _dataGridView1;
        private System.Windows.Forms.MenuStrip _menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutProgramToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn bdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn city;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}

