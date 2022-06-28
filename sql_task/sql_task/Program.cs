using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            SqlConnection sqlCon = new SqlConnection(@"Data Source=EFCYIT-LTR903;Initial Catalog=Students;Integrated Security=True");
            // SqlDataAdapter sqlda = new SqlDataAdapter("Select * from Person", sqlCon);
            // DataTable dtbl = new DataTable();
            //sqlda.Fill(dtbl);

            Console.WriteLine("Enter ID");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Entre Name");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter Age");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Entre Gender:");
            string userGender = Console.ReadLine();


            if (userGender == "female")
            {
                SqlDataAdapter sqlda = new SqlDataAdapter("Insert into dbo.female(Id,fname,age,F_gender) Values(" + id + ",'" + userName + "','" + age + "','" + userGender + "')", sqlCon);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
            }
            if (userGender == "male")
            {

                SqlDataAdapter sqlda = new SqlDataAdapter("Insert into dbo.male(Id,mname,age,P_gender) Values(" + id + ",'" + userName + "','" + age + "','" + userGender + "')", sqlCon);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
            }

            if (age > 50)
            {
                SqlConnection sqlCon1 = new SqlConnection(@"Data Source=EFCYIT-LTR903;Initial Catalog=Over50;Integrated Security=True");
                SqlDataAdapter sqlda = new SqlDataAdapter("Select * from Person", sqlCon);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
            }
            else
            {
                SqlConnection sqlCon1 = new SqlConnection(@"Data Source=EFCYIT-LTR903;Initial Catalog=Under50;Integrated Security=True");
                SqlDataAdapter sqlda1 = new SqlDataAdapter("Select * from Person", sqlCon);
                DataTable dtbl1 = new DataTable();
                sqlda1.Fill(dtbl1);
            }
        }
    }
}
