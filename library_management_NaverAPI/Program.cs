using System;
using MySql.Data.MySqlClient;

class Program
{
    static void Main(string[] args)
    {
        NaverAPI naverAPI = new NaverAPI();
        Console.WriteLine("검색어를 입력하세요.");
        string input = Console.ReadLine();
        Console.WriteLine($">>{input}<<");
        Console.WriteLine("검색 결과를 몇 개씩 볼 지를 입력하세요.");
        string number = Console.ReadLine();
        naverAPI.NaverSearchBook("title", input, number);
    }
}