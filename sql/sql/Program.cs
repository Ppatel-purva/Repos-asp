using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=EFCYIT-LTR904\MSSQLSERVER01;Initial Catalog=testdatabase;Integrated Security=True");
            SqlDataAdapter sqlda = new SqlDataAdapter("Select * from tblStudents Where Department='IT'", sqlCon);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            foreach (DataRow row in dtbl.Rows)
            {
                Console.WriteLine(row["FirstName"] + " " + row["LastName"] + " " + row["Department"]);
            }


        }
    }
}
