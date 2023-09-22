namespace UI
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
            this.vacationsDatagridview = new System.Windows.Forms.DataGridView();
            this.usernameTextbox = new MetroFramework.Controls.MetroTextBox();
            this.usernameLabel = new MetroFramework.Controls.MetroLabel();
            this.loginButton = new MetroFramework.Controls.MetroButton();
            this.createVacationButton = new MetroFramework.Controls.MetroButton();
            this.buttonApprove = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.vacationsDatagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // vacationsDatagridview
            // 
            this.vacationsDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vacationsDatagridview.Location = new System.Drawing.Point(209, 76);
            this.vacationsDatagridview.Name = "vacationsDatagridview";
            this.vacationsDatagridview.ReadOnly = true;
            this.vacationsDatagridview.Size = new System.Drawing.Size(660, 203);
            this.vacationsDatagridview.TabIndex = 0;
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Location = new System.Drawing.Point(24, 97);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(162, 23);
            this.usernameTextbox.TabIndex = 1;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(24, 75);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(68, 19);
            this.usernameLabel.TabIndex = 2;
            this.usernameLabel.Text = "Username";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(58, 126);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(97, 23);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "LOGIN";
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // createVacationButton
            // 
            this.createVacationButton.Location = new System.Drawing.Point(734, 285);
            this.createVacationButton.Name = "createVacationButton";
            this.createVacationButton.Size = new System.Drawing.Size(135, 23);
            this.createVacationButton.TabIndex = 4;
            this.createVacationButton.Text = "Create Vacation";
            this.createVacationButton.Click += new System.EventHandler(this.createVacationButton_Click);
            // 
            // buttonApprove
            // 
            this.buttonApprove.Location = new System.Drawing.Point(593, 285);
            this.buttonApprove.Name = "buttonApprove";
            this.buttonApprove.Size = new System.Drawing.Size(135, 23);
            this.buttonApprove.TabIndex = 5;
            this.buttonApprove.Text = "Approve";
            this.buttonApprove.Click += new System.EventHandler(this.buttonApprove_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 320);
            this.Controls.Add(this.buttonApprove);
            this.Controls.Add(this.createVacationButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.vacationsDatagridview);
            this.Name = "MainForm";
            this.Text = "Home";
            ((System.ComponentModel.ISupportInitialize)(this.vacationsDatagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView vacationsDatagridview;
        private MetroFramework.Controls.MetroTextBox usernameTextbox;
        private MetroFramework.Controls.MetroLabel usernameLabel;
        private MetroFramework.Controls.MetroButton loginButton;
        private MetroFramework.Controls.MetroButton createVacationButton;
        private MetroFramework.Controls.MetroButton buttonApprove;
    }
}

