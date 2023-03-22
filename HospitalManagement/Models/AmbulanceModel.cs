using System.Data;
using System.Data.SqlClient;

namespace HospitalManagement.Models
{
    public class AmbulanceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AmbulanceNo { get; set; }

        public string AmbulanceStatus { get; set; }

        public string AmbulanceDriverName { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\asp.net core mvc\HospitalManagement\HospitalManagement\App_Data\Database.mdf"";Integrated Security=True");

        public bool Insertambulance(AmbulanceModel ambulance)
        {
            String query = "insert into Ambulances values(@Name, @AmbulanceNo,@AmbulanceStatus,@AmbulanceDriverName)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", ambulance.Name);
            cmd.Parameters.AddWithValue("@AmbulanceNo", ambulance.AmbulanceNo);
            cmd.Parameters.AddWithValue("@AmbulanceStatus", ambulance.AmbulanceStatus);
            cmd.Parameters.AddWithValue("@AmbulanceDriverName", ambulance.AmbulanceDriverName);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }


        public List<AmbulanceModel> getData()
        {
            List<AmbulanceModel> lstambulance = new List<AmbulanceModel>();
            SqlDataAdapter apt = new SqlDataAdapter("select * from Ambulances", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstambulance.Add(new AmbulanceModel
                {
                    Id = Convert.ToInt32(dr["id"].ToString()),
                    Name = (dr["Name"].ToString()),
                    AmbulanceNo = (dr[columnName: "AmbulanceNo"].ToString()),
                    AmbulanceStatus = (dr[columnName: "AmbulanceStatus"].ToString()),
                    AmbulanceDriverName = (dr[columnName: "AmbulanceDriverName"].ToString()),
                });
            }
            return lstambulance;
        }
    }
}
