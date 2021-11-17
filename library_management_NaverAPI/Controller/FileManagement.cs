using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class FileManagement : Exception
{
    // 객체 저장할 리스트 생성 
    public static List<Book> bookList = new List<Book>();
    public static List<User> userList = new List<User>();
    public static List<BookHistory> bookHistoryList = new List<BookHistory>();

    public FileManagement()
    {
    }

    // Book
    // file 읽기 : .dat file에서 데이터를 불러와 list에 저장
    // 받아온 list를 반환하도록!! (아직도 메소드 헷갈리냐 ㅠㅠ 이거에 2시간 썼네...)
    public List<Book> LoadBookFile(List<Book> bookList)
    {
        FileInfo fileBookInfo = new FileInfo("bookInfomation.dat");

        if (fileBookInfo.Exists)   // dat file이 존재한다면
        {
            Stream rs = new FileStream("bookInfomation.dat", FileMode.Open); //일단 불러온다.
            BinaryFormatter deserializer = new BinaryFormatter();
            bookList = (List<Book>)deserializer.Deserialize(rs);       //역직렬화,리스트에 저장함.
            rs.Close();
        }

        // dat file로부터 받아온 데이터가 저장된 리스트
        return bookList;
    }
    // Book
    // file 쓰기 : list에 저장된 데이터를 .dat file에 저장
    public void UpdateBookFile(List<Book> bookList)
    {
        Stream ws;
        FileInfo fileBookInfo = new FileInfo("bookInfomation.dat");

        if (!fileBookInfo.Exists)       //파일이 없을경우, 생성
        {
            ws = new FileStream("bookInfomation.dat", FileMode.Create);
            ws.Close();
        }

        // 리스트를 dat file에 새로 업데이트 
        ws = new FileStream("bookInfomation.dat", FileMode.Open);
        BinaryFormatter serializer = new BinaryFormatter();
        serializer.Serialize(ws, bookList);     //직렬화(저장)
        ws.Close();
    }
    // Book
    // file 초기화: .dat file을 직접 만들어야 해서, 한 번 사용하고 주석 처리할 예정.
    // 메소드: 객체 생성 -> 리스트 생성 -> dat file 생성
    public void initializeBookFile()
    {
        // 객체 생성
        Book firstBook = new Book("ID001","메타버스","더큰내일센터","김종현","8000",10);
        Book secondBook = new Book("ID002", "다함께 아자!", "더큰내일센터", "김종현", "9000", 10);
        Book thirdBook = new Book("ID003", "야근조아", "더큰내일센터", "백승민", "9000", 10);
        Book fourthBook = new Book("ID004", "닭가슴살조아", "린랩", "백승민", "10000", 10);
        Book fifthBook = new Book("ID005", "주식과 코인", "린랩", "이충훈", "12000", 10);
        Book sixthBook = new Book("ID006", "인싸의 삶", "린랩", "김지훈", "12000", 10);
        Book seventhBook = new Book("ID007", "스터디조아", "린랩", "김창연", "13000", 10);
        Book eightthBook = new Book("ID008", "벤처마루 탈출기", "벤처마루", "김진양", "15000", 10);

        // 리스트 생성
        bookList.Add(firstBook);
        bookList.Add(secondBook);
        bookList.Add(thirdBook);
        bookList.Add(fourthBook);
        bookList.Add(fifthBook);
        bookList.Add(sixthBook);
        bookList.Add(seventhBook);
        bookList.Add(eightthBook);

        // dat file 생성
        UpdateBookFile(bookList);
    }


    // User
    // file 읽기 
    public List<User> LoadUserFile(List<User> userList)
    {
        FileInfo fileUserInfo = new FileInfo("userInfomation.dat");

        if (fileUserInfo.Exists)   // dat file이 존재한다면
        {
            Stream rs = new FileStream("userInfomation.dat", FileMode.Open); //일단 불러온다.
            BinaryFormatter deserializer = new BinaryFormatter();
            userList = (List<User>)deserializer.Deserialize(rs);       //역직렬화,리스트에 저장함.
            rs.Close();
        }

        // dat file로부터 받아온 데이터가 저장된 리스트
        return userList;
    }
    // User
    // file 쓰기 : list에 저장된 데이터를 .dat file에 저장
    public void UpdateUserFile(List<User> userList)
    {
        Stream ws;
        FileInfo fileUserInfo = new FileInfo("userInfomation.dat");

        if (!fileUserInfo.Exists)       //파일이 없을경우, 생성
        {
            ws = new FileStream("userInfomation.dat", FileMode.Create);
            ws.Close();
        }

        // 리스트를 dat file에 새로 업데이트 
        ws = new FileStream("userInfomation.dat", FileMode.Open);
        BinaryFormatter serializer = new BinaryFormatter();
        serializer.Serialize(ws, userList);     //직렬화(저장)
        ws.Close();
    }

    // BookHistory
    // file 읽기 
    public List<BookHistory> LoadBookHistoryFile(List<BookHistory> bookHistoryList)
    {
        FileInfo fileBookHistoryInfo = new FileInfo("bookHistory.dat");

        if (fileBookHistoryInfo.Exists)   // dat file이 존재한다면
        {
            Stream rs = new FileStream("bookHistory.dat", FileMode.Open); //일단 불러온다.
            BinaryFormatter deserializer = new BinaryFormatter();
            bookHistoryList = (List<BookHistory>)deserializer.Deserialize(rs);       //역직렬화,리스트에 저장함.
            rs.Close();
        }

        // dat file로부터 받아온 데이터가 저장된 리스트
        return bookHistoryList;
    }
    // User
    // file 쓰기 : list에 저장된 데이터를 .dat file에 저장
    public void UpdateBookHistoryFile(List<BookHistory> bookHistoryList)
    {
        Stream ws;
        FileInfo fileBookHistoryInfo = new FileInfo("bookHistory.dat");

        if (!fileBookHistoryInfo.Exists)       //파일이 없을경우, 생성
        {
            ws = new FileStream("bookHistory.dat", FileMode.Create);
            ws.Close();
        }

        // 리스트를 dat file에 새로 업데이트 
        ws = new FileStream("bookHistory.dat", FileMode.Open);
        BinaryFormatter serializer = new BinaryFormatter();
        serializer.Serialize(ws, bookHistoryList);     //직렬화(저장)
        ws.Close();
    }

}
