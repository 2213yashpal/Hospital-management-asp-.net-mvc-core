using System.Data;
using System.Data.SqlClient;

namespace HospitalManagement.Models
{
    public class AnnouncementsModel
    {
        public int Id { get; set; }
        public string Announcements { get; set; }
        public string AnnouncementFor { get; set; }

        public string Enddate { get; set; }


        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\asp.net core mvc\HospitalManagement\HospitalManagement\App_Data\Database.mdf"";Integrated Security=True");

        public bool Addannouncement(AnnouncementsModel announcement)
        {
            String query = "insert into Announcements values(@Announcements, @AnnouncementFor,@Enddate)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Announcements", announcement.Announcements);
            cmd.Parameters.AddWithValue("@AnnouncementFor", announcement.AnnouncementFor);
            cmd.Parameters.AddWithValue("@Enddate", announcement.Enddate);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }

        public List<AnnouncementsModel> getData()
        {
            List<AnnouncementsModel> lstannouncement = new List<AnnouncementsModel>();
            SqlDataAdapter apt = new SqlDataAdapter("select * from Announcements", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstannouncement.Add(new AnnouncementsModel
                {
                    Id = Convert.ToInt32(dr["id"].ToString()),
                    Announcements = (dr[columnName: "Announcements"].ToString()),
                    AnnouncementFor = (dr[columnName: "AnnouncementFor"].ToString()),
                    Enddate = (dr[columnName: "Enddate"].ToString()),

                });
            }
            return lstannouncement;
        }
    }
}
