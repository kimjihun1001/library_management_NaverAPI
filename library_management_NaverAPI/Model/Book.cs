using System;

[Serializable]
public class Book : DataProcessing
{
    private string id;  // 도서번호
    private string name;    // 도서명
    private string publisher;   // 출판사명
    private string author;  // 저자명
    private string price;   // 가격
    private int quantity;    // 수량
    //private int number;     // 검색 리스트용 넘버

    public Book()
    {
        // 생성자
    }

    public Book(string id, string name, string publisher, string author, string price, int quantity)
    {
        Id = id;
        Name = name;
        Publisher = publisher;
        Author = author;
        Price = price;
        Quantity = quantity;
    }

    public string Id    // get/set method
    {
        get { return id; }
        set { id = value; }
    }

    public string Name
    {
        get; set;
    }

    public string Publisher
    {
        get; set;
    }

    public string Author
    {
        get; set;
    }

    public string Price
    {
        get; set;
    }

    public int Quantity
    {
        get; set;
    }

    public int Number
    {
        get; set;
    }
}
