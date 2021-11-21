using System;

public class Book : DataProcessing
{
    private string id;  // Primary Key
    private string isbn;    // 도서번호
    private string name;    // 도서명
    private string author;  // 저자명
    private string publisher;   // 출판사명
    private int price;   // 가격
    private int quantity;    // 전체 수량
    private int currentQuantity;    // 현재 수량
    //private int number;     // 검색 리스트용 넘버

    public Book()
    {
        // 생성자
    }

    public Book(string id, string isbn, string name, string publisher, string author, int price, int quantity, int currentQuantity)
    {
        Id = id;
        Isbn = isbn;
        Name = name;
        Publisher = publisher;
        Author = author;
        Price = price;
        Quantity = quantity;
        CurrentQuantity = currentQuantity;
    }

    public string Id    // get/set method
    {
        get { return id; }
        set { id = value; }
    }

    public string Isbn
    {
        get; set;
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

    public int Price
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

    public int CurrentQuantity
    {
        get; set;
    }
}
