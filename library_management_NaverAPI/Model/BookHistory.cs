using System;

[Serializable]
public class BookHistory
{
    private string userName;
    private string bookName;
    private string borrowTime = null;
    private string returnTime = null;

    public BookHistory()
    {
    }

    public BookHistory(string userName, string bookName)
    {
        UserName = userName;
        BookName = bookName;
    }

    public string UserName
    {
        get; set;
    }
    public string BookName
    {
        get; set;
    }
    public string BorrowTime
    {
        get; set;
    }
    public string ReturnTime
    {
        get; set;
    }
}
