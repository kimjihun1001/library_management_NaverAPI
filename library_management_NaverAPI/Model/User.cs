using System;
using System.Collections.Generic;

[Serializable]
public class User : DataProcessing
{
    private string id;  // 회원번호
    private string password;   // 비밀번호
    private string name;    // 회원명
    private int age;   // 나이
    private string phoneNumber;  // 전화번호
    private string adress;   // 주소
    public List<Book> borrowedBook = new List<Book>();    // 대출한 책
    //private int number;     // 검색 리스트용 넘버

    public string Id    // get/set method
    {
        get { return id; }
        set { id = value; }
    }

    public string Password
    {
        get; set;
    }

    public string Name
    {
        get; set;
    }

    public int Age
    {
        get; set;
    }

    public string PhoneNumber
    {
        get; set;
    }

    public string Address
    {
        get; set;
    }

    public List<Book> BorrowedBook
    {
        get; set;
    }

    public int Number
    {
        get; set;
    }

    public User()
    {
        // 생성자
        Book book = new Book();
        borrowedBook.Add(book);
    }

    public User(string id, string password, string name, int age, string phoneNumber, string address)
    {
        Id = id;
        Password = password;
        Name = name;
        Age = age;
        PhoneNumber = phoneNumber;
        Address = address;
    }
}
