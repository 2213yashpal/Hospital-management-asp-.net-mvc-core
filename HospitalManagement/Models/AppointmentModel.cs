using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace HospitalManagement.Models
{
    public class AppointmentModel
    {
        public int Id { get; set; }
        public string Patientname { get; set; }

        public string Doctorname { get; set; }
        public string AppointmentDate { get; set; }

        public string Problem { get; set; }

        public string Status { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\asp.net core mvc\HospitalManagement\HospitalManagement\App_Data\Database.mdf"";Integrated Security=True");


        public bool addappointment(AppointmentModel appointment)
        {
            String query = "insert into Appointments values(@Patientname, @Doctorname,@AppointmentDate,@Problem,@Status)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Patientname", appointment.Patientname);
            cmd.Parameters.AddWithValue("@Doctorname", appointment.Doctorname);
            cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
            cmd.Parameters.AddWithValue("@Problem", appointment.Problem);
            cmd.Parameters.AddWithValue("@Status", "pending");


            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }


        public List<AppointmentModel> getData()
        {
            List<AppointmentModel> lstaapp = new List<AppointmentModel>();
            SqlDataAdapter apt = new SqlDataAdapter("select * from Appointments where Status='approve'", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstaapp.Add(new AppointmentModel
                {
                    Id = Convert.ToInt32(dr["id"].ToString()),
                    Patientname = (dr["Patientname"].ToString()),
                    Doctorname = (dr[columnName: "Doctorname"].ToString()),
                    AppointmentDate = (dr[columnName: "AppointmentDate"].ToString()),
                    Problem = (dr[columnName: "Problem"].ToString()),
                    Status = (dr[columnName: "Status"].ToString()),

                });
            }
            return lstaapp;
        }


        public List<AppointmentModel> getDatapending()
        {
            List<AppointmentModel> lstpapp = new List<AppointmentModel>();
            SqlDataAdapter apt = new SqlDataAdapter("select * from Appointments where Status='pending'", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstpapp.Add(new AppointmentModel
                {
                    Id = Convert.ToInt32(dr["id"].ToString()),
                    Patientname = (dr["Patientname"].ToString()),
                    Doctorname = (dr[columnName: "Doctorname"].ToString()),
                    AppointmentDate = (dr[columnName: "AppointmentDate"].ToString()),
                    Problem = (dr[columnName: "Problem"].ToString()),
                    Status = (dr[columnName: "Status"].ToString()),

                });
            }
            return lstpapp;
        }


       

        public bool update(AppointmentModel appointment)
        {
            
            String query = "update Appointments set Patientname=@Patientname,Doctorname = @Doctorname, AppointmentDate =@AppointmentDate, Problem= @Problem, Status=@Status where Id = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Patientname", appointment.Patientname);
            cmd.Parameters.AddWithValue("@Doctorname", appointment.Doctorname);
            cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
            cmd.Parameters.AddWithValue("@Problem", appointment.Problem);
            cmd.Parameters.AddWithValue("@Id", appointment.Id);
            cmd.Parameters.AddWithValue("@Status", appointment.Status);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }


        public AppointmentModel getData(string Id)
        {
            AppointmentModel app = new AppointmentModel();
            SqlCommand cmd = new SqlCommand("select * from Appointments where Id=@Id", con);
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            app.Id = Convert.ToInt32(dr["Id"].ToString());
             app.Patientname = dr["Patientname"].ToString();
             app.Doctorname = dr["Doctorname"].ToString();
              app.AppointmentDate = dr["AppointmentDate"].ToString();
             app.Problem = dr["Problem"].ToString();
            app.Status = dr["Status"].ToString();
            con.Close();
            return app;

        }
        public bool delete(AppointmentModel appointment)
        {
            SqlCommand cmd = new SqlCommand("delete Appointments where Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", appointment.Id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
    }
            
           
 }
 






