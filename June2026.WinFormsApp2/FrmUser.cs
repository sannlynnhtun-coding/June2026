using June2026.Database.AppDbContextModels;
using June2026.Domain.Features.User;
using June2026.Domain.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing.Printing;

namespace June2026.WinFormsApp2
{
    public partial class FrmUser : Form
    {
        private readonly UserService _userService;
        private int editUserId = 0;

        public FrmUser()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            var response = _userService.GetUsers(new UserListRequestModel());
            if (!response.IsSuccess)
            {
                MessageBox.Show(response.Message);
                return;
            }

            int rowNo = 0;
            List<UserDto> users = new List<UserDto>();
            foreach (var item in response.Users)
            {
                rowNo++;
                UserDto user = new UserDto();
                user.RowNo = rowNo;
                user.UserId = item.UserId;
                user.Username = item.Username;

                users.Add(user);
            }

            dgvData.DataSource = users;

            ClearControls();
        }

        public class UserDto
        {
            public int RowNo { get; set; }
            public int UserId { get; set; }
            public string Username { get; set; }
            public string? Password { get; set; }
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
            if (editUserId == 0)
            {
                var response = _userService.CreateUser(new UserCreateRequestModel
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text.Trim()
                });
                MessageBox.Show(response.Message);
            }
            else
            {
                var response = _userService.PatchUser(new UserPatchRequestModel
                {
                    UserId = editUserId,
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text.Trim()
                });
                MessageBox.Show(response.Message);
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
                var response = _userService.GetUser(new UserEditRequestModel { UserId = userId });

                if (!response.IsSuccess)
                {
                    MessageBox.Show(response.Message);
                    return;
                }

                txtUsername.Text = response.UserName;
                txtPassword.Text = string.Empty;
                editUserId = response.UserId;
            }
            else if (e.ColumnIndex == 1) // Delete
            {
                var result = MessageBox.Show("Are you sure want to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int userId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells[nameof(colUserId)].Value);
                    var response = _userService.DeleteUser(new UserDeleteRequestModel { UserId = userId });
                    MessageBox.Show(response.Message);

                    BindData();
                }
            }
        }
    }
}
