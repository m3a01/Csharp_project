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
    public partial class Register : MaterialSkin.Controls.MaterialForm
    {
        public Register()
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skin = MaterialSkin.MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
            skin.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Green600, MaterialSkin.Primary.BlueGrey900, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Green100, MaterialSkin.TextShade.WHITE);
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            //string En_pass  = En_DeCrypte.encryote(password.Text);//This functin to make password Encryption.
            //string E_user = En_DeCrypte.encryote(user.Text);
            ServiceReference2.WebServiceSoapClient c = new ServiceReference2.WebServiceSoapClient();
            var response = c.fun(user.Text, password.Text, name.Text);
            MessageBox.Show(response);
            //Sqlcon.cmd = new SqlCommand("insert into Users values ('" + name.Text + "','" + user.Text + "','" + En_pass + "')", Sqlcon.cn);
            //Sqlcon.cn.Open();
            //Sqlcon.cmd.ExecuteNonQuery();
            //MessageBox.Show("Done !");
            //Sqlcon.cn.Close();
        }
    }
}
