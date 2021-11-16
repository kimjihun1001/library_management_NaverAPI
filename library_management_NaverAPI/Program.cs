using System;
using MySql.Data.MySqlClient;

class Program
{
    static void Main(string[] args)
    {
        NaverAPI naverAPI = new NaverAPI();
        naverAPI.NaverSearchBook();
    }
}
