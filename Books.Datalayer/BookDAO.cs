using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using Books.Entities;
namespace Books.Datalayer
{
    public class BookDAO
    {
        SqlConnection connection = new SqlConnection(@"Data Source=MUM02L10276\SQLEXPRESS;Initial Catalog=SQLAssignment1;Integrated Security=True");
        SqlCommand command = null;
        string Qry = string.Empty;

        public List<Book> getAllBook() {
            try
            {
                List<Book> bookList = new List<Book>();
                Qry = $"select * from Book";
                command = new SqlCommand(Qry, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        bookList.Add(new Book()
                        {
                            BookId = (int)reader[0],
                            BookName = reader[1].ToString(),
                            Price = (int)reader[2],
                            Author = reader[3].ToString(),
                            year = DateTime.Parse(reader[4].ToString()),
                            
                        });
                    }
                }
                return bookList;
            }
            catch (Exception)
            {

                throw;
            }
            finally {
                connection.Close();
            } 
        }

        public List<Book> GetBookByAuthor(string authorName)
        {
            try
            {
                List<Book> bookList = new List<Book>();
                Qry = $"select * from Book where Author='{authorName}'";
                command = new SqlCommand(Qry, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        bookList.Add(new Book()
                        {
                            BookId = (int)reader[0],
                            BookName = reader[1].ToString(),
                            Price = (int)reader[2],
                            Author = reader[3].ToString(),
                            year = DateTime.Parse(reader[4].ToString()),

                        });
                    }
                }
                return bookList;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public void AddBook(Book book) {
            try
            {
                Qry = $"insert into Book values('{book.BookName}',{book.Price},'{book.Author}','{book.year}')";
                command = new SqlCommand(Qry, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally {
                connection.Close();
            }
        }

        public void DeleteBook(int bookId) {
            try
            {
                Qry = $"delete from book where BookId={bookId}";
                command = new SqlCommand(Qry, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public void EditBook(int bookId,string BookName,int Price)
        {
            try
            {
                Qry = $"update book set BookName='{BookName}', Price={Price} where BookId={bookId}";
                command = new SqlCommand(Qry, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }


    }
}
