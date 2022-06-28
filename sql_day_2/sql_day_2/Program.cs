using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace sql_day_2
{
    internal class Program
    {
        static void Main(string[] args)
        {


            SqlConnection sqlCon = new SqlConnection(@"Data Source=EFCYIT-LTR903\MSSQLSERVER01;Initial Catalog=Librarymanagement;Integrated Security=True");

            Console.WriteLine("====Rgistration=====");
            Console.WriteLine("Entre Name");
            string name = Console.ReadLine();
            
            Console.WriteLine("Enter Password");
            string pass1 = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("====Login========");
            Console.WriteLine("Entre Name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Password");
            string pass = Convert.ToInt32(Console.ReadLine());


            if (pass1 == pass)
            {
                SqlDataAdapter sqlda = new SqlDataAdapter("Insert into dbo.Userinfo(Id,name,pass) Values('" + name + "','" + pass+ "')", sqlCon);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
            }
            else
            {
                Console.WriteLine("Password is Incorrect");
            }
            while (true)
            {

                Console.WriteLine("1. Lend a book \n2. Serch a book \n3. Request for a new book\n4. EXIT ");
                int asw = Convert.ToInt32(Console.ReadLine());
                if (asw == 1)
                {
                    Console.WriteLine("Enter Book Name : ");
                    string bookname = Console.ReadLine();

                    Console.WriteLine("Enter the Recive Date : ");
                    string bookrecive = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter book Return date : ");
                    string bookreturn = Convert.ToInt32(Console.ReadLine());


                    SqlDataAdapter sqlmale = new SqlDataAdapter("insert into bookdetail(BookName,ReciveDate,ReturnDate) values('" + bookname + "', '" + bookrecive + "', '" + bookreturn + "')", sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlmale.Fill(dtbl);
                    Console.ReadLine();

                    Console.WriteLine("<--------Data Inserted Successfully -------->");

                    continue;

                }
                else if (asw == 2)
                {
                    SqlDataAdapter sql1 = new SqlDataAdapter("select * from BookDetail", sqlCon);
                    DataTable dtbl1 = new DataTable();
                    sql1.Fill(dtbl1);
                    foreach (DataRow dataRow in dtbl1.Rows)
                    {
                        Console.WriteLine(dataRow["id"] + "   " + dataRow["BookName"] + "    " + dataRow["AuthorName"] + "   ");
                    }

                    Console.WriteLine("Enter Which Book you want to Search :");
                    Console.WriteLine("Enter Book Name :");
                    string booksearchname = Console.WriteLine();
                    Console.WriteLine("Enter Author Name:");
                    string Author = Console.ReadLine();
                    
                   

                    SqlDataAdapter sql2 = new SqlDataAdapter("select * from SearchBook", sqlCon);
                    DataTable dtbl2 = new DataTable();
                    sql1.Fill(dtbl1);
                   
                        if (booksearchname == Convert.ToInt32(dataRow["id"]))
                        {
                            Console.WriteLine("Book is Aveilable ")
                        }
                    }  

                }
                else
                {
                Console.WriteLine("Book is Not Aveilable ");
                }

                else if (asw == 3)
                {
                Console.WriteLine("Enter a Book Name ");
                string reqbookname = Console.ReadLine();
                Console.WriteLine("Enter Author Name ");
                string authorname = Console.ReadLine();

                SqlDataAdapter sqlda = new SqlDataAdapter("Insert into dbo.newbook(Id,bookName,Author) Values('" + reqbookname + "','" + authorname + "')", sqlCon);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);

            }
                else if (asw == 4)
                {
                    break;
                }
                else
                {
                    continue;
                }

            }

        }
    }
}
