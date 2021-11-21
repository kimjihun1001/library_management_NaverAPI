﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

public class DataProcessing : TreatDB_MySQL
{
    public static User currentUser = new User();
    public static Book currentBook = new Book();

    public static List<Book> searchedBookList = new List<Book>();
    public static List<User> searchedUserList = new List<User>();

    public DataProcessing()
    {
    }

    // 검색
    // 책 이름 
    public void SearchBookForName(string input)
    {
        foreach (Book book in bookList)
        {
            if (book.Name.Contains(input))
            {
                searchedBookList.Add(book);
            }
        }
    }
    // 검색
    // 회원 이름  
    public void SearchUserForName(string input)
    {
        foreach (User user in userList)
        {
            if (user.Name.Contains(input))
            {
                searchedUserList.Add(user);
            }
        }
    }
    // 검색
    // 책 출판사 
    public void SearchForPublisher(string input)
    {
        foreach (Book book in bookList)
        {
            if (book.Publisher.Contains(input))
            {
                searchedBookList.Add(book);
            }
        }
    }
    // 검색
    // 책 저자명 
    public void SearchForAuthor(string input)
    {
        foreach (Book book in bookList)
        {
            if (book.Author.Contains(input))
            {
                searchedBookList.Add(book);
            }
        }
    }

    // 삭제
    // 도서
    public bool RemoveBook(string input)
    {
        foreach (Book book in bookList)
        {
            if (book.Id == input)
            {
                if (book.Quantity != book.CurrentQuantity)
                {
                    Console.WriteLine("해당 책은 대출 중입니다. 삭제할 수 없습니다.");
                    return false;
                }
                else
                {
                    bookList.Remove(book);
                    UploadBookDB();
                    Console.WriteLine($"<{book.Name}>이 도서 리스트에서 삭제되었습니다.");
                    return true;
                }
            }
        }
        return false;
    }
    // 삭제
    // 회원
    public bool RemoveUser(string input)
    {
        foreach (User user in userList)
        {
            if (user.Id == input)
            {
                if (user.borrowedBook.Count != 0)
                {
                    Console.WriteLine("해당 회원은 대출중인 책이 있습니다. 삭제할 수 없습니다.");
                    return false;
                }
                else
                {
                    userList.Remove(user);
                    UploadUserDB();
                    Console.WriteLine($"<{user.Name}>님이 회원 리스트에서 삭제되었습니다.");
                    return true;
                }
            }
        }
        return false;
    }

    // 책 대출 
    public bool BorrowBook(string input)
    {
        foreach (Book book in searchedBookList)
        {
            if (book.Id == input)
            {
                if (book.Quantity == 0)
                {
                    Console.Write("대출 가능한 책이 없습니다. 다시 입력해주세요: ");
                    return false;
                }
                else
                {
                    currentUser.borrowedBook.Add(book);
                    book.Quantity--;
                    HistoryOfBorrow(book);
                    UploadBookDB();
                    Console.WriteLine($"<{book.Name}> 대출 완료했습니다.");
                    return true;
                }
            }
        }
        return false;
    }

    // 책 반납
    public bool ReturnBook(string input)
    {
        foreach (Book book in currentUser.borrowedBook)
        {
            if (book.Id == input)
            {
                currentUser.borrowedBook.Remove(book);
                foreach (Book book1 in bookList)
                {
                    if (book1.Id == book.Id)
                    {
                        book1.Quantity++;
                        break;
                    }
                }
                HistoryOfReturn(book);
                UploadBookDB();
                Console.WriteLine($"<{book.Name}> 반납 완료했습니다.");
                return true;
            }
        }
        return false;
    }

    // 도서 대출 기록
    public void HistoryOfBorrow(Book book)
    {
        Log log = new Log("대출");
        if (logList.Count == 0)
        {
            log.Id = 1;
        }
        else
        {
            // 로그 리스트에 저장된 마지막 항목의 id + 1 해서 id 지정 
            log.Id = logList[logList.Count - 1].Id + 1;
        }

        log.UserName = currentUser.Name;
        log.BookName = book.Name;
        log.BorrowTime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        logList.Add(log);
        UploadLogDB();
    }

    // 도서 반납 기록
    public void HistoryOfReturn(Book book)
    {
        Log log = new Log("반납");
        BookHistory bookHistory = new BookHistory(currentUser.Name, book.Name);
        bookHistory.ReturnTime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        bookHistoryList.Add(bookHistory);
        UpdateBookHistoryFile(bookHistoryList);
    }

    // 신규 책 등록
    public void AddNewBook(string id, string isbn, string name, string publisher, string author, int price, int quantity)
    {
        Book book = new Book(id, isbn, name, publisher, author, price, quantity);
        bookList.Add(book);
        UpdateBookFile(bookList);
    }

    // 신규 회원 등록
    public void AddNewUser(string id, string password, string name, int age, string phoneNumber, string address)
    {
        User user = new User(id, password, name, age, phoneNumber, address);
        userList.Add(user);
        UpdateUserFile(userList);
    }

    // 로그인 확인 과정
    // 아이디 
    public bool CheckUserID(string id)
    {
        bool IsIDChecked = false;
        foreach (User user in userList)
        {
            if (user.Id == id)
            {
                IsIDChecked = true;
            }
        }

        if (IsIDChecked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // 로그인 확인 과정
    // 비밀번호 
    public bool CheckUserPassword(string password)
    {
        bool IsPasswordChecked = false;
        foreach (User user in userList)
        {
            if (user.Password == password)
            {
                IsPasswordChecked = true;
                currentUser = user;
            }
        }

        if (IsPasswordChecked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // 책의 총 권수 계산
    public int SumQuantityOfBooks(List<Book> list)
    {
        int totalQuantity = 0;
        foreach (Book book in list)
        {
            totalQuantity += book.Quantity;
        }
        return totalQuantity;
    }

    // 책 정보 체크
    // 책 ID
    public bool CheckBookID(string id)
    {
        foreach (Book book in bookList)
        {
            if (book.Id == id)
                return true;
        }
        return false;
    }
    // 책 이름, 저자가 같은 경우
    public bool CheckBookNameAndAuthor(string name, string publisher, string author)
    {
        foreach (Book book in bookList)
        {
            if (book.Id == name && book.Publisher == publisher && book.Author == author)
                return true;
        }
        return false;
    }
    // 책 이름이 공백인지 체크
    public bool CheckEmpty(string input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != ' ')
                return false;
        }
        return true;
    }

}
