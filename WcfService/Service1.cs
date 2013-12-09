using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Security;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public bool CheckTheLogIn(string username, string password)
        {
            bool check = false;
            SqlConnection sqlConnection = new SqlConnection("data source=.;initial catalog=ClassProjectDataBase;integrated security=True");
            String SQLQuery = "SELECT * FROM people WHERE username = @userName and password = @password";
            SqlCommand command = new SqlCommand(SQLQuery, sqlConnection);
            command.Parameters.Add(new SqlParameter("@userName", username));
            command.Parameters.Add(new SqlParameter("@password", password));
            sqlConnection.Open();
            DataTable person = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(person);
            da.Dispose();
            sqlConnection.Close();
            if (person.Rows.Count > 0)
                check = true;
            //if (Membership.ValidateUser(username, password))
            //{
            //    check = true;
            //}


            return check;
        }


    }
}
