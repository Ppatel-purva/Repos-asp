using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace raytexone
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=EFCYIT-LTR903;Initial Catalog=Librarymanagement;Integrated Security=True");


            Console.WriteLine("========Ragistration=======");

            Console.WriteLine("Entre Name");
            string userName = Console.ReadLine();
            Console.WriteLine("Entre Password:");
            string userpass1 = Console.ReadLine();

            Console.WriteLine("==========Login=============");
            Console.WriteLine("Entre Name");
            string userName1 = Console.ReadLine();
            Console.WriteLine("Entre Password:");
            string userpass = Console.ReadLine();

            if (userpass.Equals(userpass1))
            {
                SqlDataAdapter sqlda = new SqlDataAdapter("Insert into dbo.Userinfo(name,password) Values('" + userName + "','" + userpass + "')", sqlCon);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);

            }
            else
            {
                Console.WriteLine("Enter Valid Pasword");
            
            }
             while (true)
             {

                Console.WriteLine("1. Lend a book \n2. Serch a book \n3. Request for a new book\n4. EXIT ");
                int asw = Convert.ToInt32(Console.ReadLine());
                if (asw == 1)
                {
                    Console.WriteLine("Enter Book Name : ");
                    string bookname = Console.ReadLine();

                    Console.WriteLine("Enter Author Name : ");
                    string author = Console.ReadLine();

                    Console.WriteLine("Enter the Recive Date : ");
                    string bookrecive = Console.ReadLine();

                    Console.WriteLine("Enter book Return date : ");
                    string bookreturn = Console.ReadLine();


                    SqlDataAdapter sqlmale = new SqlDataAdapter("insert into Bookdetail(bookname,author,reciveDate,returnDate) values('" + bookname + "','" + author + "', '" + bookrecive + "', '" + bookreturn + "')", sqlCon);
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
                            Console.WriteLine("Book is Aveilable ");
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

                     //Author
                    Console.WriteLine("Entre Name");
                    string authorName = Console.ReadLine();
                    Console.WriteLine("Entre Password:");
                    string authorpass = Console.ReadLine();

                        Console.WriteLine("1. Approve lending of book \n2. charge money \n3. Add new book to the list\n4.Remove a book from the list \n5. EXIT ");
                        int asw = Convert.ToInt32(Console.ReadLine());
                        if (asw == 1)
                        {
                              SqlDataAdapter sql2 = new SqlDataAdapter("select * from Bookdetail", sqlCon);
                              Console.WriteLine("Entre Name");
                              string bookName = Console.ReadLine();
                              Console.WriteLine("Entre Name You want to approve");
                              string bookapprove = Console.ReadLine();
                              SqlDataAdapter sqlda = new SqlDataAdapter("Insert into dbo.bookdetail(Id,bookName,Author) Values('" +bookName + "','" + bookapprove + "')", sqlCon);
                              DataTable dtbl = new DataTable();
                              sqlda.Fill(dtbl);
                        } 
                          else if (asw == 2)
       
                          {
                               Console.WriteLine("Enter User Name");
                               string username = Console.ReadLine();
                              if(bookrecive != bookreturn)
                              {

                                Console.WriteLine("You are Charger");
                              }
                                  else if 
                                   {
                                        Console.WriteLine("Book Recived Successfully");
                                        SqlDataAdapter sqlda = new SqlDataAdapter("Insert into dbo.Bookdetail(Id,bookName,Author) Values('" +name + "','" + authorName + "')", sqlCon);
                                         DataTable dtbl = new DataTable();
                                         sqlda.Fill(dtbl);
                                        Console.WriteLine("<--------Data Inserted Successfully -------->");
                                   }
                                     else if (asw == 3)
       
                                     {
                                       Console.WriteLine("Enter a new book");
                                       string newbookname = Console.ReadLine();
                                       Console.WriteLine("Enter Author name");
                                       string newbookauthorname = Console.ReadLine();
                                       SqlDataAdapter sqlda = new SqlDataAdapter("Insert into dbo.NewBook(id,bookname,authorname) Values('" + newbookname + "','" + newbookauthorname + "')", sqlCon);
                                       DataTable dtbl = new DataTable();
                                       sqlda.Fill(dtbl);
                                       Console.WriteLine("<--------Data Inserted Successfully -------->");
                       
                                     }
                                      else if (asw == 4)
                                      {
                                             Console.WriteLine("Enter a Book name you want to remove");
                                             string bookname = Console.ReadLine();
                                             SqlDataAdapter sqlda = new SqlDataAdapter("DELETE FROM dbo.NewBook(id,bookname,authorname) Values('" + bookname + "')", sqlCon);
                                             DataTable dtbl = new DataTable();
                                             sqlda.Fill(dtbl);
                                      }
                                      else if (asw == 5)
                                      {
                                         
                                         break;
                     
                                         else
                                         {
                                           continue;
                                         }   
                                      }
                         
                          }
                }
             
             }       
        }
    
    }

}

  
    

