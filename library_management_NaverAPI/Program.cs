using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

class Program
{
    static void Main(string[] args)
    {
        //UI ui = new UI();


        TreatDB_MySQL treatDB_MySQL = new TreatDB_MySQL();

        treatDB_MySQL.LoadBookDB();

        Book book1 = new Book("008", "0123456789123", "신나는 코딩", "제주엔샵", "김지훈", 10000, 10);
        TreatDB_MySQL.bookList.Add(book1);

        foreach (Book book in TreatDB_MySQL.bookList)
        {
            Console.WriteLine(book.Name);
        }

        treatDB_MySQL.UploadBookDB();

        //ui.View_3_9();
        //ui.View_Main();

    }
    
}
