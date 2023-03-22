using System.Data;
using System.Data.SqlClient;
namespace HospitalManagement.Models
{
    public class UserModel
    {
        public int u_id { get; set; }
        public string name { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string role { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\asp.net core mvc\HospitalManagement\HospitalManagement\App_Data\Database.mdf"";Integrated Security=True");

        public bool Insert(UserModel user)
        {
            String query = "insert into Users values(@name, @email,@password,@role)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", user.name);
            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.Parameters.AddWithValue("@password", user.password);
            cmd.Parameters.AddWithValue("@role", "User");

            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }


        public bool login(UserModel user)
        {
            String query = "select email,password,role from Users where email=@email and password=@password";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.Parameters.AddWithValue("@password", user.password);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return true;
            }
            return false;
            //String data = dr.GetString(2);
            //cmd.ExecuteNonQuery();
           //con.Close();
            //return data;
        }



     
    }
}
