using System.Data;
using System.Data.SqlClient;

namespace HospitalManagement.Models
{
    public class MedicineModel
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Quantity { get; set; }
        public string Price { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\asp.net core mvc\HospitalManagement\HospitalManagement\App_Data\Database.mdf"";Integrated Security=True");

        public bool Insertmed(MedicineModel med)
        {
            String query = "insert into Medicines values(@Name, @Description,@Quantity,@Price)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", med.Name);
            cmd.Parameters.AddWithValue("@Description", med.Description);
            cmd.Parameters.AddWithValue("@Quantity", med.Quantity);
            cmd.Parameters.AddWithValue("@Price", med.Price);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }

        public List<MedicineModel> getData()
        {
            List<MedicineModel> lstmed = new List<MedicineModel>();
            SqlDataAdapter apt = new SqlDataAdapter("select * from Medicines", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstmed.Add(new MedicineModel
                {
                    Id = Convert.ToInt32(dr["Id"].ToString()),
                    Name = (dr["Name"].ToString()),
                    Description = (dr[columnName: "Description"].ToString()),
                    Quantity = (dr[columnName: "Quantity"].ToString()),

                    Price = (dr[columnName: "Price"].ToString()),

                });
            }
            return lstmed;
        }
    }
}
