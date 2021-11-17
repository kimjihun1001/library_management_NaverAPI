using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

class Program
{
    static void Main(string[] args)
    {
        FileManagement file = new FileManagement();
        UI ui = new UI();

        // 처음 bookInformation.dat 파일 만들때 사용
        //file.initializeBookFile();

        // bookList는 static 변수이므로 클래스 이름 사용
        // LoadBookFile은 static이 아닌 메소드이므로 객체 이름 사용
        FileManagement.bookList = file.LoadBookFile(FileManagement.bookList);
        FileManagement.userList = file.LoadUserFile(FileManagement.userList);
        FileManagement.bookHistoryList = file.LoadBookHistoryFile(FileManagement.bookHistoryList);

        ui.View_3_9();
        //ui.View_Main();

    }
    
}
