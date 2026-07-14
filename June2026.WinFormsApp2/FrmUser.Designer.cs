namespace June2026.WinFormsApp2
{
    partial class FrmUser
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvData = new DataGridView();
            colEdit = new DataGridViewButtonColumn();
            colDelete = new DataGridViewButtonColumn();
            colRowNo = new DataGridViewTextBoxColumn();
            colUserId = new DataGridViewTextBoxColumn();
            colUsername = new DataGridViewTextBoxColumn();
            colPassword = new DataGridViewTextBoxColumn();
            label1 = new Label();
            txtUsername = new TextBox();
            btnSave = new Button();
            label2 = new Label();
            txtPassword = new TextBox();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { colEdit, colDelete, colRowNo, colUserId, colUsername, colPassword });
            dgvData.Dock = DockStyle.Bottom;
            dgvData.Location = new Point(0, 261);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersWidth = 82;
            dgvData.Size = new Size(800, 454);
            dgvData.TabIndex = 7;
            dgvData.CellContentClick += dgvData_CellContentClick;
            // 
            // colEdit
            // 
            colEdit.HeaderText = "Edit";
            colEdit.MinimumWidth = 10;
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            colEdit.Text = "Edit";
            colEdit.UseColumnTextForButtonValue = true;
            // 
            // colDelete
            // 
            colDelete.HeaderText = "Delete";
            colDelete.MinimumWidth = 10;
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            colDelete.Text = "Delete";
            colDelete.UseColumnTextForButtonValue = true;
            // 
            // colRowNo
            // 
            colRowNo.DataPropertyName = "RowNo";
            colRowNo.HeaderText = "Row No.";
            colRowNo.MinimumWidth = 10;
            colRowNo.Name = "colRowNo";
            colRowNo.ReadOnly = true;
            // 
            // colUserId
            // 
            colUserId.DataPropertyName = "UserId";
            colUserId.HeaderText = "User ID";
            colUserId.MinimumWidth = 10;
            colUserId.Name = "colUserId";
            colUserId.ReadOnly = true;
            // 
            // colUsername
            // 
            colUsername.DataPropertyName = "Username";
            colUsername.HeaderText = "Username";
            colUsername.MinimumWidth = 10;
            colUsername.Name = "colUsername";
            colUsername.ReadOnly = true;
            // 
            // colPassword
            // 
            colPassword.DataPropertyName = "Password";
            colPassword.HeaderText = "Password";
            colPassword.MinimumWidth = 10;
            colPassword.Name = "colPassword";
            colPassword.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 33);
            label1.Name = "label1";
            label1.Size = new Size(133, 32);
            label1.TabIndex = 1;
            label1.Text = "Username: ";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(218, 30);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(354, 39);
            txtUsername.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(387, 185);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(185, 46);
            btnSave.TabIndex = 5;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 111);
            label2.Name = "label2";
            label2.Size = new Size(123, 32);
            label2.TabIndex = 3;
            label2.Text = "Password: ";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(218, 108);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(354, 39);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(218, 185);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(163, 46);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmUser
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 715);
            Controls.Add(btnCancel);
            Controls.Add(txtPassword);
            Controls.Add(label2);
            Controls.Add(btnSave);
            Controls.Add(txtUsername);
            Controls.Add(label1);
            Controls.Add(dgvData);
            Name = "FrmUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += FrmUser_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvData;
        private Label label1;
        private TextBox txtUsername;
        private Button btnSave;
        private Label label2;
        private TextBox txtPassword;
        private Button btnCancel;
        private DataGridViewButtonColumn colEdit;
        private DataGridViewButtonColumn colDelete;
        private DataGridViewTextBoxColumn colRowNo;
        private DataGridViewTextBoxColumn colUserId;
        private DataGridViewTextBoxColumn colUsername;
        private DataGridViewTextBoxColumn colPassword;
    }
}
