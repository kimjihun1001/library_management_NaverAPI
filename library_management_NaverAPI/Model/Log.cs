using System;

public class Log
{
    private int id;
    private string type;
    private string userName;
    private string bookName;
    private string time = null;

    public Log()
    {
    }

    public Log(string type)
    {
        Type = type;
    }

    public int Id    // get/set method
    {
        get { return id; }
        set { id = value; }
    }

    public string Type
    {
        // 로그인
        // 대출
        // 반납
        // 검색
        // 구매
        get; set;
    }

    public string UserName
    {
        // admin
        // id
        get; set;
    }

    public string BookName
    {
        // 대출, 반납, 검색, 구매 시에만 존재 
        get; set;
    }
    public string Time
    {
        // 로그인, 대출, 반납 시에만 존재 
        get; set;
    }
}
