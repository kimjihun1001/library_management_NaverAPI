using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

class Program
{
    static void Main(string[] args)
    {
        UI ui = new UI();

        // 프로그램 처음 시작할 때, DB를 가져오는 과정.
        // 일부러 View_Main에 넣지 않았음. 화면 표출할 때마다 가져오면 느려질까봐
        ui.LoadBookDB();
        ui.LoadUserDB();
        ui.LoadLogDB();

        System.Diagnostics.Process.Start("https://www.naver.com");
        ui.View_Main();

    }
    
}
