using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    DataSet dt= new DataSet() ;
    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //[WebMethod]
    public string Rate(double x)
    {
        if (x >= 0 && x < 50)
            return "رسوب";
        else if (x >= 50 && x < 70)
            return "جيد";
        else if (x >= 70 && x < 80)
            return "جيدجدا";
        else if (x >= 80 && x <= 100)
            return "ممتاز";

        return "";
        
    }
    [WebMethod]
    public string fun(string user1 , string pass1 , string name)
    {
        string user = Encryption.encryote(user1);
        string pass = Encryption.encryote(pass1);
        try
        {

            using (SqlConnection con = new SqlConnection("Server = M3A-PC; DataBase = mohamed12; Integrated Security = true"))
            {
                using (SqlCommand cmd = new SqlCommand("insert into account01 (name ,username , password) values(@name ,@user , @pass)"))
                {
                    cmd.Connection = con;
                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
                    cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }

            return "Add Seccessfuly !";


        }
        catch (SqlException ex)
        {
            return ex.Message;
        }

    }
    [WebMethod]
    public string login(string user ,string pass)
    {
        string En_u = Encryption.encryote(user);
        string En_p = Encryption.encryote(pass);
        string re1;
        string re2;
        string re3;
        string re4;
        SqlDataReader dr;
        
        try
        {
            SqlConnection con = new SqlConnection("Server = M3A-PC; DataBase = mohamed12; Integrated Security = true");
            SqlCommand cmd = new SqlCommand("select username , password from account01 where username = '" + En_u + "' and password = '" + En_p + "'", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                re1 = dr["username"].ToString();
                re2 = dr["password"].ToString();
                re3 = Encryption.dcryote(re1);
                re4 = Encryption.dcryote(re2);
                if (user == re3 && pass == re4)
                    return "1";
                else
                    return "0";
                
            }
            else
                return "no data pass";
        }
        catch(SqlException ex)
        {
            return ex.Message;

        }
    }
    [WebMethod()]
    public DataTable result(int id)
    {
        DataSet result = new DataSet();
        SqlDataAdapter dr = new SqlDataAdapter();
        SqlConnection con = new SqlConnection("Server = M3A-PC; DataBase = mohamed12; Integrated Security = true");
        SqlCommand cmd = new SqlCommand("select * from person where StudantNumber = "+id+"" ,con);
        dr.SelectCommand = cmd;
        try

        {

            con.Open();

            dr.Fill(result ,"person");

        }

        catch (Exception ex)

        {

            throw ex;

        }

        finally

        {

            con.Close();

        }

        return result.Tables["person"];

    }
    [WebMethod]
    public bool insertResult(string name, string s1, string s2, string s3, string s4, string s5, string s6)
    {
        try
        {

            using (SqlConnection con = new SqlConnection("Server = M3A-PC; DataBase = mohamed12; Integrated Security = true"))
            {
                using (SqlCommand cmd = new SqlCommand("insert into person (StudantName ,S_1 ,S_2 , S_3,S_4,S_5,S_6,Total , Rate) values(@name,@s_1 ,@s_2 , @s_3,@s_4 ,@s_5 , @s_6,@total, @rate)"))
                {
                    double s =(Convert.ToDouble(s1 )+ Convert.ToDouble(s2) + Convert.ToDouble(s3) + Convert.ToDouble(s4 )+ Convert.ToDouble(s5) + Convert.ToDouble(s6))/6;
                    double s0 = Math.Round(s, 2);
                    cmd.Connection = con;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    cmd.Parameters.Add("@s_1", SqlDbType.Float).Value = s1;
                    cmd.Parameters.Add("@s_2", SqlDbType.Float).Value = s2;
                    cmd.Parameters.Add("@s_3", SqlDbType.Float).Value = s3;
                    cmd.Parameters.Add("@s_4", SqlDbType.Float).Value = s4;
                    cmd.Parameters.Add("@s_5", SqlDbType.Float).Value = s5;
                    cmd.Parameters.Add("@s_6", SqlDbType.Float).Value = s6;
                    cmd.Parameters.Add("@total", SqlDbType.Float).Value = s0;
                    cmd.Parameters.Add("@rate", SqlDbType.NVarChar).Value = Rate(s0);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }

            return true;


        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }
    [WebMethod]
    public bool delete(int id)
    {
        try {
            SqlConnection con = new SqlConnection("Server = M3A-PC; DataBase = mohamed12; Integrated Security = true");
            SqlCommand cmd = new SqlCommand("delete from person where StudantNumber =" + id + "",con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        catch(SqlException ex)
        {
            return false;
            throw ex;
        }
    }
    [WebMethod]
    public bool edit(int id , string name, string s1, string s2, string s3, string s4, string s5, string s6)
    {
        try
        {

            using (SqlConnection con = new SqlConnection("Server = M3A-PC; DataBase = mohamed12; Integrated Security = true"))
            {
                using (SqlCommand cmd = new SqlCommand("update person set StudantName = @name, S_1 = @s_1 ,S_2 = @s_2 ,S_3 = @s_3,S_4 = @s_4 ,S_5 = @s_5 ,S_6 =  @s_6,total = @total,Rate = @rate  where StudantNumber = "+id+""))
                {
                    double s = (Convert.ToDouble(s1) + Convert.ToDouble(s2) + Convert.ToDouble(s3) + Convert.ToDouble(s4) + Convert.ToDouble(s5) + Convert.ToDouble(s6)) / 6;
                    double s0 = Math.Round(s, 2);
                    cmd.Connection = con;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    cmd.Parameters.Add("@s_1", SqlDbType.Float).Value = s1;
                    cmd.Parameters.Add("@s_2", SqlDbType.Float).Value = s2;
                    cmd.Parameters.Add("@s_3", SqlDbType.Float).Value = s3;
                    cmd.Parameters.Add("@s_4", SqlDbType.Float).Value = s4;
                    cmd.Parameters.Add("@s_5", SqlDbType.Float).Value = s5;
                    cmd.Parameters.Add("@s_6", SqlDbType.Float).Value = s6;
                    cmd.Parameters.Add("@total", SqlDbType.Float).Value = s0;
                    cmd.Parameters.Add("@rate", SqlDbType.NVarChar).Value = Rate(s0);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }

            return true;


        }
        catch (SqlException ex)
        {

            return false;
            throw ex;

        }
    }

}


