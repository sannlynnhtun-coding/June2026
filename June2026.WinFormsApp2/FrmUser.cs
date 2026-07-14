using June2026.Database.AppDbContextModels;
using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing.Printing;

namespace June2026.WinFormsApp2
{
    public partial class FrmUser : Form
    {
        private readonly AppDbContext _db;
        private int editUserId = 0;

        public FrmUser()
        {
            InitializeComponent();
            _db = new AppDbContext();
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            var lst = _db.TblUsers.ToList();

            int rowNo = 0;
            List<UserDto> users = new List<UserDto>();
            foreach (var item in lst)
            {
                rowNo++;
                UserDto user = new UserDto();
                user.RowNo = rowNo;
                user.UserId = item.UserId;
                user.Username = item.Username;
                user.Password = item.Password;

                users.Add(user);

                //UserDto user2 = new UserDto()
                //{
                //    Username = item.Username,
                //    Password = item.Password,
                //    UserId = item.UserId,
                //    RowNo = rowNo
                //};

                //users.Add(new UserDto
                //{
                //     UserId = item.UserId,
                //     Username = item.Username,
                //     Password = item.Password
                //});
            }

            dgvData.DataSource = users;

            ClearControls();
        }

        public class UserDto
        {
            public int RowNo { get; set; }
            public int UserId { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(editUserId == 0)
            {
                _db.TblUsers.Add(new TblUser
                {
                    Password = txtPassword.Text.Trim(), // " mg mg "
                    Username = txtUsername.Text.Trim(),
                });
                _db.SaveChanges();
            }
            else
            {
                var item = _db.TblUsers
                       .Where(x => x.UserId == editUserId)
                       .FirstOrDefault();

                if (item is null) return;

                item.Username = txtUsername.Text.Trim();
                item.Password = txtPassword.Text.Trim();
            }

            editUserId = 0;

            BindData();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == 0) // Edit
            {
                int userId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells[nameof(colUserId)].Value);
                var item = _db.TblUsers
                    .Where(x => x.UserId == userId)
                    .FirstOrDefault();

                if (item is null) return;

                txtUsername.Text = item.Username;
                txtPassword.Text = item.Password;
                editUserId = item.UserId;
            }
            else if (e.ColumnIndex == 1) // Delete
            {
                var result = MessageBox.Show("Are you sure want to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int userId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells[nameof(colUserId)].Value);
                    var item = _db.TblUsers
                        .Where(x => x.UserId == userId)
                        .FirstOrDefault();

                    if (item is null) return;

                    _db.Remove(item);
                    _db.SaveChanges();

                    BindData();
                }
            }
        }
    }
}
