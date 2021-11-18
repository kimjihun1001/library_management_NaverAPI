using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

public class TreatDB_MySQL
{
    public static List<Book> bookList = new List<Book>();
    public static List<User> userList = new List<User>();
    public static List<BookHistory> bookHistoryList = new List<BookHistory>();

    //MySqlCommand command = new MySqlCommand("DELETE FROM bookmember WHERE bookIDNumber = " + Convert.ToInt32(wantedDeleteBookID), connection);
    //MySqlCommand command = new MySqlCommand("UPDATE bookmember SET bookPrice = '" + modifitedPrice + "'" + " WHERE bookIDNumber = " + Convert.ToInt32(wantedModiftiedBookID), connection);

    public void LoadBookDB()
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=library;Uid=root;Pwd=36671726;");
        connection.Open();

        string query = "SELECT * FROM book";
        MySqlCommand command = new MySqlCommand(query, connection);

        // MySqlDataReader는 연결모드로 데이타를 서버에서 가져오는 반면, MySqlDataAdapter는 한꺼번에 클라이언트 메모리로 데이타를 가져온후 연결을 끊는다.
        MySqlDataReader rdr = command.ExecuteReader();

        // DB에서 데이터를 읽는 동안 새로운 도서 객체에 추가함 
        while (rdr.Read())
        {
            Book book = new Book();

            book.Id = rdr["id"].ToString();
            book.Isbn = rdr["isbn"].ToString();
            book.Name = rdr["name"].ToString();
            book.Author = rdr["author"].ToString();
            book.Publisher = rdr["publisher"].ToString();
            book.Price = int.Parse(rdr["price"].ToString());
            book.Quantity = int.Parse(rdr["quantity"].ToString());
            book.CurrentQuantity = int.Parse(rdr["currentQuantity"].ToString());

            bookList.Add(book);
        }
        rdr.Close();
        connection.Close();
    }

    public void UploadBookDB()
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=library;Uid=root;Pwd=36671726;");
        connection.Open();

        MySqlCommand deleteCommand = new MySqlCommand("DELETE FROM book where id != 0", connection);
        // 위의 command를 실행한다
        // INSERT와 DELETE 할 때만 사용하기. SELECT할 때 사용하면 튕김 
        deleteCommand.ExecuteNonQuery();

        foreach (Book book in bookList)
        {
            string bookInformationString = "VALUES('" + book.Id + "', '" + book.Isbn + "', '" + book.Name + "', '" + book.Author + "', '" + book.Publisher + "', " + book.Price + ", " + book.Quantity + ", " + book.CurrentQuantity + ")";

            MySqlCommand command = new MySqlCommand("INSERT INTO book (id, isbn, name, author, publisher, price, quantity, currentQuantity)" + bookInformationString, connection);

            command.ExecuteNonQuery();
        }
        connection.Close();
    }

    public void UploadTestDB()
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=library;Uid=root;Pwd=36671726;");
        connection.Open();

        MySqlCommand deleteCommand = new MySqlCommand("DELETE FROM new_table where id != 0", connection);
        // 위의 command를 실행한다
        // INSERT와 DELETE 할 때만 사용하기. SELECT할 때 사용하면 튕김 
        deleteCommand.ExecuteNonQuery();

        //foreach (Book book in bookList)
        //{
        //    string bookInformationString = "VALUES('" + book.Id + "', '" + book.Isbn + "', '" + book.Name + "', '" + book.Author + "', '" + book.Publisher + "', " + book.Price + ", " + book.Quantity + ", " + book.CurrentQuantity + ")";

        //    MySqlCommand command = new MySqlCommand("INSERT INTO book (id, isbn, name, author, publisher, price, quantity, currentQuantity)" + bookInformationString, connection);

        //    command.ExecuteNonQuery();
        //}
        connection.Close();
    }

    public void LoadUserDB()
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=library;Uid=root;Pwd=36671726;");
        connection.Open();

        string query = "SELECT * FROM user";
        MySqlCommand command = new MySqlCommand(query, connection);

        // MySqlDataReader는 연결모드로 데이타를 서버에서 가져오는 반면, MySqlDataAdapter는 한꺼번에 클라이언트 메모리로 데이타를 가져온후 연결을 끊는다.
        MySqlDataReader rdr = command.ExecuteReader();

        // DB에서 데이터를 읽는 동안 새로운 회원 객체에 추가함 
        while (rdr.Read())
        {
            User user = new User();

            user.Id = rdr["id"].ToString();
            user.Password = rdr["password"].ToString();
            user.Name = rdr["name"].ToString();
            user.Age = int.Parse(rdr["age"].ToString());
            user.PhoneNumber = rdr["phoneNumber"].ToString();
            user.Address = rdr["address"].ToString();
            user.Point = int.Parse(rdr["point"].ToString());

            userList.Add(user);
        }
        rdr.Close();
        connection.Close();
    }
}
