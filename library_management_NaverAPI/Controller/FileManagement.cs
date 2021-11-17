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
