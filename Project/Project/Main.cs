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

namespace Project
{
    public partial class Main : MaterialSkin.Controls.MaterialForm
    {
        DataTable dt = new DataTable();
        bool chan = false;
        public Main()
        {
            InitializeComponent();
            
            MaterialSkin.MaterialSkinManager skin = MaterialSkin.MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
            skin.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Green700, MaterialSkin.Primary.BlueGrey900, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Green100, MaterialSkin.TextShade.WHITE);
            dataGridView1.Hide();
            panel2.Hide();
            panel1.Hide();
            fullName.Enabled= false;
            name.Enabled    = false;
            address.Enabled = false;
            email.Enabled   = false;
            phone.Enabled   = false;
            S5.Enabled      = false;
            S6.Enabled      = false;
        }

        private void materialContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
           
        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {
            if(chan)
            {
                pictureBox1.Image = Properties.Resources.Layer;
                chan = false;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.search1;
                chan = true;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mohamed12DataSet.person' table. You can move, or remove it, as needed.
            //this.personTableAdapter.Fill(this.mohamed12DataSet.person);

        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel5_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            dataGridView1.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.DataSource.Equals(""))
            {
                MessageBox.Show("The board search is empty !");
            }
            else
            {
                fullName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                name.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                address.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                email.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                phone.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                S5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                S6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                dataGridView1.Hide();
                panel1.Show();
                chan = false;
            }
        }

        private void materialSingleLineTextField3_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField1_TextChanged(object sender, EventArgs e)
        {
            var response = new DataTable();
            //int r = Convert.ToInt32(materialSingleLineTextField1.Text);
            if (materialSingleLineTextField1.Text == "")
            {
                dataGridView1.Hide();
                panel1.Hide();
            }
            else
            {
                int r = Convert.ToInt32(materialSingleLineTextField1.Text);
                ServiceReference2.WebServiceSoapClient c = new ServiceReference2.WebServiceSoapClient();
                response.Clear();
                response = c.result(r);
            }

            //dt.Clear();
            dataGridView1.Show();
            //Sqlcon.da = new SqlDataAdapter("select * from person where person_id = '" + materialSingleLineTextField1.Text + "'", Sqlcon.cn);
            //Sqlcon.da.Fill(dt);
            dataGridView1.DataSource = response;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Sqlcon.cmd = new SqlCommand("delete from person where person_name = '" + name.Text + "'", Sqlcon.cn);
            //Sqlcon.cn.Open();
            //Sqlcon.cmd.ExecuteNonQuery();
            if (materialSingleLineTextField1.Text == "")
            {
                MessageBox.Show("يستحيل الحذف لعدم وجود رقم في حقل البحث");
            }
            else
            {
                int r = Convert.ToInt32(materialSingleLineTextField1.Text);
                ServiceReference2.WebServiceSoapClient c = new ServiceReference2.WebServiceSoapClient();
                var response = c.delete(r);
                if (response)
                {
                    MessageBox.Show("Delete successfly");
                    fullName.Text = "";
                    name.Text = "";
                    address.Text = "";
                    email.Text = "";
                    phone.Text = "";
                    S5.Text = "";
                    S6.Text = "";
                }
                else
                    MessageBox.Show("يستحيل الحذف لعدم لوجود خطاء غير معروف");
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!chan)
            {
                fullName.Enabled = true;
                name.Enabled     = true;
                address.Enabled  = true;
                email.Enabled    = true;
                phone.Enabled    = true;
                S5.Enabled       = true;
                S6.Enabled       = true;
                pictureBox3.Image = Properties.Resources.done;
                chan = true;

            }
            else if(chan)
            {
                //Sqlcon.cmd = new SqlCommand("update person set person_name = '" + name.Text + "',person_address = '" + address.Text + "',person_email ='" + email.Text + "',person_phone = '" + phone.Text + "'",Sqlcon.cn);
                //Sqlcon.cn.Open();
                //Sqlcon.cmd.ExecuteNonQuery();
                if (materialSingleLineTextField1.Text == "")
                {
                    MessageBox.Show("يستحيل التعديل لعدم وجود رقم في حقل البحث");
                }
                else
                {
                    int r = Convert.ToInt32(materialSingleLineTextField1.Text);
                    ServiceReference2.WebServiceSoapClient c = new ServiceReference2.WebServiceSoapClient();
                    var response = c.edit(r, fullName.Text, name.Text, address.Text, email.Text, phone.Text, S5.Text, S6.Text);
                    if (response)
                    {
                        MessageBox.Show("Edit complated !");
                        fullName.Enabled = false;
                        name.Enabled     = false;
                        address.Enabled  = false;
                        email.Enabled    = false;
                        phone.Enabled    = false;
                        S5.Enabled       = false;
                        S6.Enabled       = false;
                        pictureBox3.Image = Properties.Resources.Capt;
                        chan = false;
                    }
                    else
                        MessageBox.Show("يستحيل التعديل لعدم لوجود خطاء غير معروف");
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void name_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            panel2.Show();
            dataGridView1.Hide();
            pictureBox4.Hide();

        }

        private void materialLabel10_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            dataGridView1.Show();
            pictureBox4.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ServiceReference2.WebServiceSoapClient c = new ServiceReference2.WebServiceSoapClient();
            var response = c.insertResult(fName.Text,su1.Text,su2.Text,su3.Text,su4.Text,su5.Text,su6.Text);
            if (response)
            {
                MessageBox.Show("Add successfuly !");
                fName.Text = "";
                su1.Text = "";
                su2.Text = "";
                su3.Text = "";
                su4.Text = "";
                su5.Text = "";
                su6.Text = "";
            }
            else
                MessageBox.Show("Somethink wrong !");

        }
    }
}
