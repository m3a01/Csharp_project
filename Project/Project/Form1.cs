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
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        SqlConnection cn = new SqlConnection("server = M3A-PC\\SqlExpress ; DataBase = Mohamed12 ; Integrated Security = true ");
        SqlCommand cmd;
        SqlDataReader dr;
        bool change = true;
        public Form1()//This for materialis
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skin = MaterialSkin.MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
            skin.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Green600, MaterialSkin.Primary.BlueGrey900, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Green100, MaterialSkin.TextShade.WHITE);
          
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            
            if (pass_field.Text == "" || user_field.Text == "")
            {
                MessageBox.Show("The field is empty !" +pass_field.Text);
            }
            else {
               
                    ServiceReference2.WebServiceSoapClient c = new ServiceReference2.WebServiceSoapClient();
                    var response = c.login(user_field.Text, pass_field.Text);
                       
                        if (response == "1")
                        {
                            Main main = new Main();
                            main.Show();
                        }
                        else if(response == "0")
                            MessageBox.Show("Not scussfuly");
                   else
                {
                    MessageBox.Show(response);
                }
                
           }
               
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // string ss;
           //char[] ch =  textBox1.Text.ToCharArray();
           // for (int i = 0; i < textBox1.Text.Length; i++)
           // {
           //     if (ch[i] >= 97 && ch[i] <= 121)
           //     {
           //         ss = En_DeCrypte.encryote(textBox1.Text);
           //         MessageBox.Show(ss);
           //     }
           //     else
           //         MessageBox.Show("This not alphbatic");
           // }
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {

            if (change)
            {
                change = false; pictureBox2.Image = Properties.Resources.Layer_01;
            }
            else
            {
                change = true;   pictureBox2.Image = Properties.Resources.Layer_123;
            }
        }

        private void register(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register r = new Register();
           // r.Show(this);
           // this.CenterToParent();
            r.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }
    }
    }
