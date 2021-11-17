using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

class ReadDB_MySQL
{
    public void ReadDB()
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=library;Uid=root;Pwd=36671726;");
        connection.Open();


        string bookInformationString = "VALUES(100122, '악12312벤과 22', '베톤222', '예솔222', '12', 5, '', '', '')";

        MySqlCommand command = new MySqlCommand("INSERT INTO bookmember (bookIDNumber,bookName,bookAuthorName," +
            "bookPublisherName,bookPrice,bookQuantity,bookISBN,bookPublicationDate,bookDescription)"
            + bookInformationString, connection);

        //MySqlCommand command = new MySqlCommand("SELECT *FROM bookmember", connection);
        //MySqlCommand command = new MySqlCommand("DELETE FROM bookmember WHERE bookIDNumber = " + Convert.ToInt32(wantedDeleteBookID), connection);
        //MySqlCommand command = new MySqlCommand("UPDATE bookmember SET bookPrice = '" + modifitedPrice + "'" + " WHERE bookIDNumber = " + Convert.ToInt32(wantedModiftiedBookID), connection);

        command.ExecuteNonQuery();
        connection.Close();

    }

}
