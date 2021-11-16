using System;
using MySql.Data.MySqlClient;

class Program
{
    static void Main(string[] args)
    {
        NaverAPI naverAPI = new NaverAPI();
        string input = Console.ReadLine();
        Console.WriteLine($">>{input}<<");
        naverAPI.NaverSearchBook(input);
    }
}
