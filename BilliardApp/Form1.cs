using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BilliardApp
{
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        public Form1()
        {
            InitializeComponent();
            customizeDesing();
            cn = new SqlConnection(dbcon.myConnection());
            btnDashboard.PerformClick();
        }

        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            lblTitle.Text = childForm.Text;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        #region panelSlide
        public void customizeDesing()
        {
            panelSubUser.Visible = false;
            panelSubServices.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelSubUser.Visible == true)
            {
                panelSubUser.Visible = false;
            }
            if (panelSubServices.Visible == true)
            {
                panelSubServices.Visible = false;
            }
        }

        private void showSubMenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubMenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }
        #endregion panelSlide

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            openChildForm(new Dashboard());
            hideSubMenu();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubUser);
        }

        private void btnUserInfo_Click(object sender, EventArgs e)
        {
            openChildForm(new userinfo());
            hideSubMenu();
        }

        private void btnUserAccount_Click(object sender, EventArgs e)
        {
            openChildForm(new UserAccount());
            hideSubMenu();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            openChildForm(new Table());
            hideSubMenu();
        }

        private void btnSessions_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubServices);
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                login lg = new login();
                lg.Show();
                this.Close();
            }
        }

        private void btnDrinks_Click(object sender, EventArgs e)
        {
            openChildForm(new drinkservice());
            hideSubMenu();
        }

        private void btnFoods_Click(object sender, EventArgs e)
        {
            openChildForm(new foodservice());
            hideSubMenu();
        }

        private void buttonRent_Click(object sender, EventArgs e)
        {
            openChildForm(new stickservice());
            hideSubMenu();
        }
    }
}
