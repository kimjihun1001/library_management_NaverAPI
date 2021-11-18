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
        treatDB_MySQL.LoadUserDB();

        //ui.View_3_9();
        //ui.View_Main();

    }
    
}
