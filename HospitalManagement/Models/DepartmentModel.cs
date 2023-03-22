using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace HospitalManagement.Models
{
    public class DepartmentModel
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\asp.net core mvc\HospitalManagement\HospitalManagement\App_Data\Database.mdf"";Integrated Security=True");


        public bool Insertdep(DepartmentModel dep)
        {
            String query = "insert into Departments values(@Name, @Description,@Status)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", dep.Name);
            cmd.Parameters.AddWithValue("@Description", dep.Description);
            cmd.Parameters.AddWithValue("@Status", dep.Status);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }

        public List<DepartmentModel> getData()
        {
            List<DepartmentModel> lstdep = new List<DepartmentModel>();
            SqlDataAdapter apt = new SqlDataAdapter("select * from Departments", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstdep.Add(new DepartmentModel
                {
                    Id = Convert.ToInt32(dr["id"].ToString()),
                    Name = (dr["Name"].ToString()),
                    Description = (dr[columnName: "Description"].ToString()),
                    Status = (dr[columnName: "Status"].ToString()),

                });
            }
            return lstdep;
        }
    }
}
