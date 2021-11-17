using System;
using System.Collections.Generic;

[Serializable]
public class UI : DataProcessing
{
    public UI()
    {
    }

    // 책 리스트 출력 메소드
    // 파라미터로 원하는 리스트 넣기 
    public void View_BookList(List<Book> list)
    {
        foreach (Book book in list)
        {
            Console.WriteLine($"책 ID: {book.Id}");
            Console.WriteLine($"책 이름: {book.Name}");
            Console.WriteLine($"책 출판사: {book.Publisher}");
            Console.WriteLine($"책 저자: {book.Author}");
            Console.WriteLine($"책 가격: {book.Price}");
            Console.WriteLine($"책 수량: {book.Quantity}");
            Console.WriteLine("--------------------------------------------------");
        }
    }

    // 회원 리스트 출력 메소드
    public void View_UserList(List<User> list)
    {
        foreach (User user in list)
        {
            Console.WriteLine($"ID: {user.Id}");
            Console.WriteLine($"이름: {user.Name}");
            Console.WriteLine($"나이: {user.Age}");
            Console.WriteLine($"전화 번호: {user.PhoneNumber}");
            Console.WriteLine($"주소: {user.Address}");
            if (user.borrowedBook == null)
                Console.WriteLine($"대출한 책: 0권");
            else
                Console.WriteLine($"대출한 책: {user.borrowedBook.Count}권");
            Console.WriteLine($"대출한 책 리스트");
            View_BookList(user.borrowedBook);
            if (user.borrowedBook.Count == 0)
                Console.WriteLine("--------------------------------------------------");
        }
    }

    // 타이틀
    public void View_Title()
    {
        Console.Clear();
        Console.WriteLine("" +
            "█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗\n" +
            "╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝\n" +
            "███████╗███╗   ██╗ ██╗ ██╗     ██╗     ██╗██████╗ ██████╗  █████╗ ██████╗ ██╗   ██╗ \n" +
            "██╔════╝████╗  ██║████████╗    ██║     ██║██╔══██╗██╔══██╗██╔══██╗██╔══██╗╚██╗ ██╔╝ \n" +
            "█████╗  ██╔██╗ ██║╚██╔═██╔╝    ██║     ██║██████╔╝██████╔╝███████║██████╔╝ ╚████╔╝  \n" +
            "██╔══╝  ██║╚██╗██║████████╗    ██║     ██║██╔══██╗██╔══██╗██╔══██║██╔══██╗  ╚██╔╝   \n" +
            "███████╗██║ ╚████║╚██╔═██╔╝    ███████╗██║██████╔╝██║  ██║██║  ██║██║  ██║   ██║    \n" +
            "╚══════╝╚═╝  ╚═══╝ ╚═╝ ╚═╝     ╚══════╝╚═╝╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝    \n" +
            "█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗뒤로가기█████╗\n" +
            "╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝ ESC  ╚════╝");
    }

    // 메인 화면 
    public void View_Main()
    {
        while (true)
        {
            // 회원 로그아웃시켜야 함.
            currentUser = new User();

            View_Title();
            Console.WriteLine("1. 로그인");
            Console.WriteLine("2. 회원가입");
            Console.WriteLine("3. 관리자모드");
            Console.WriteLine("4. 종료");

            string input = ReadNumber();

            switch (input)
            {
                case "1":
                    View_Login();
                    break;
                case "2":
                    View_JoinToUser();
                    break;
                case "3":
                    View_AdminMode();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("잘못 입력했습니다. 다시 입력하세요.");
                    break;
            }
        }
    }

    // 로그인
    public void View_Login()
    {
        View_Title();

        Console.Write("ID를 입력하세요. (숫자/영어)");
        while (true)
        {
            string id = ReadEnglishOrNumber();
            if (id == "\0")
                goto Jump;

            if (CheckUserID(id))
                break;
            else
                Console.Write("존재하지 않는 ID입니다. 다시 입력하세요.");
        }

        Console.Write("비밀번호를 입력하세요. (숫자/영어)");
        while (true)
        {
            string password = ReadEnglishOrNumber();
            if (password == "\0")
                goto Jump;

            if (CheckUserPassword(password))
                break;
            else
                Console.Write("잘못 입력하셨습니다. 다시 입력하세요.");
        }

        while (true)
        {
            View_Title();
            Console.WriteLine($"로그인 성공. 반갑습니다. {currentUser.Name}님");
            Console.WriteLine("1. 책 검색");
            Console.WriteLine("2. 책 대출");
            Console.WriteLine("3. 책 반납");
            Console.WriteLine("4. 책 리스트");
            Console.WriteLine("5. 나의 회원 정보");
            Console.WriteLine("6. 처음 메뉴로 가기");
            Console.WriteLine("7. 종료");

            string input = ReadNumber();
            if (input == "\0")
                break;

            switch (input)
            {
                case "1":
                    View_1_1();
                    break;
                case "2":
                    View_1_2();
                    break;
                case "3":
                    View_1_3();
                    break;
                case "4":
                    View_1_4();
                    break;
                case "5":
                    View_1_5();
                    break;
                case "6":
                    View_Main();
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("잘못 입력했습니다. 다시 입력하세요.");
                    break;
            }
        }
    Jump:
        Console.WriteLine();
    }

    // 책 검색
    public void View_1_1()
    {
        while (true)
        {
            View_Title();
            Console.WriteLine("1. 책 이름으로 검색");
            Console.WriteLine("2. 책 저자명으로 검색");
            Console.WriteLine("3. 책 출판사로 검색");
            Console.WriteLine("4. 종료");

            string input = ReadNumber();
            if (input == "\0")
                break;

            switch (input)
            {
                case "1":
                    View_1_1_1();
                    break;
                case "2":
                    View_1_1_2();
                    break;
                case "3":
                    View_1_1_3();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("잘못 입력했습니다. 다시 입력하세요.");
                    break;
            }
        }
    }

    // 책 이름으로 검색
    public void View_1_1_1()
    {
        View_Title();
        Console.WriteLine("검색하실 책 이름을 입력하세요: ");
        while (true)
        {
            // 검색 리스트 초기화 
            searchedBookList = new List<Book>();

            // 입력받는 메소드 만들기
            string input = ReadString();
            if (input == "\0")
                break;

            // 검색 리스트 생성
            SearchBookForName(input);
            if (searchedBookList.Count == 0)
            {
                Console.WriteLine("검색 결과가 없습니다. 다시 입력하세요. ");
            }
            else
            {
                View_BookList(searchedBookList);
                Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
                input = ReadESC();
                if (input == "\0")
                    break;
            }
        }
    }
    // 책 저자명으로 검색
    public void View_1_1_2()
    {
        View_Title();
        Console.WriteLine("검색하실 책 저자명을 입력하세요: ");
        while (true)
        {
            // 검색 리스트 초기화 
            searchedBookList = new List<Book>();

            // 입력받는 메소드 만들기
            string input = ReadString();
            if (input == "\0")
                break;

            // 검색 리스트 생성
            SearchForAuthor(input);
            if (searchedBookList.Count == 0)
            {
                Console.WriteLine("검색 결과가 없습니다. 다시 입력하세요. ");
            }
            else
            {
                View_BookList(searchedBookList);
                Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
                input = ReadESC();
                if (input == "\0")
                    break;
            }
        }
    }
    // 책 출판사로 검색
    public void View_1_1_3()
    {
        View_Title();
        Console.WriteLine("검색하실 책 출판사를 입력하세요: ");
        while (true)
        {
            // 검색 리스트 초기화 
            searchedBookList = new List<Book>();

            // 입력받는 메소드 만들기
            string input = ReadString();
            if (input == "\0")
                break;

            // 검색 리스트 생성
            SearchForPublisher(input);
            if (searchedBookList.Count == 0)
            {
                Console.WriteLine("검색 결과가 없습니다. 다시 입력하세요. ");
            }
            else
            {
                View_BookList(searchedBookList);
                Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
                input = ReadESC();
                if (input == "\0")
                    break;
            }

        }
    }

    // 책 대출 
    public void View_1_2()
    {
        View_Title();
        Console.WriteLine("검색하실 책 이름을 입력하세요: ");
        while (true)
        {
            // 검색 리스트 초기화 
            searchedBookList = new List<Book>();

            // 입력받는 메소드 만들기
            string input = ReadString();
            if (input == "\0")
                break;

            // 검색 리스트 생성
            SearchBookForName(input);
            if (searchedBookList.Count == 0)
            {
                Console.WriteLine("검색 결과가 없습니다. 다시 입력하세요. ");
            }
            else
            {
                View_BookList(searchedBookList);
                Console.WriteLine("대출하실 책의 ID를 입력해주세요.");
                while (true)
                {
                    input = ReadEnglishOrNumber();
                    if (input == "\0")
                        break;
                    bool check = BorrowBook(input);
                    if (check)
                        break;
                    else
                        Console.WriteLine("잘못 입력했습니다. 다시 입력하세요: ");
                }
                Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
                input = ReadESC();
                if (input == "\0")
                    break;
            }

        }
    }

    // 책 반납 
    public void View_1_3()
    {
        while (true)
        {
            View_Title();
            if (currentUser.borrowedBook.Count == 0)
            {
                Console.WriteLine("현재 대출한 책이 없습니다.");
                Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
                string input1 = ReadESC();
                if (input1 == "\0")
                    break;
            }
            else
            {
                View_BookList(currentUser.borrowedBook);
                Console.WriteLine("반납할 책의 ID를 눌러주세요.");
                while (true)
                {
                    string input2 = ReadEnglishOrNumber();
                    if (input2 == "\0")
                        break;
                    bool check = ReturnBook(input2);
                    if (check)
                        break;
                    else
                        Console.WriteLine("잘못 입력했습니다. 다시 입력하세요: ");
                }
                Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
                string input3 = ReadESC();
                if (input3 == "\0")
                    break;
            }
            
        }
        
    }

    // 전체 책 리스트
    public void View_1_4()
    {
        while(true)
        {
            View_Title();
            Console.WriteLine("도서관에 등록된 모든 책의 리스트입니다.");
            Console.WriteLine();

            View_BookList(bookList);
            Console.WriteLine($"책이 총 {bookList.Count}종류, {SumQuantityOfBooks(bookList)}권 등록되어 있습니다.");

            Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
            string input = ReadESC();
            if (input == "\0")
                break;
        }
        
    }

    // 회원 정보
    public void View_1_5()
    {
        View_Title();
        Console.WriteLine($"{currentUser.Name}님의 회원 정보입니다.");
        Console.WriteLine($"ID: {currentUser.Id}");
        Console.WriteLine($"이름: {currentUser.Name}");
        Console.WriteLine($"나이: {currentUser.Age}");
        Console.WriteLine($"전화 번호: {currentUser.PhoneNumber}");
        Console.WriteLine($"주소: {currentUser.Address}");
        Console.WriteLine($"대출한 책: {currentUser.borrowedBook.Count}권");
        Console.WriteLine($"대출한 책 리스트");
        View_BookList(currentUser.borrowedBook);

        Console.WriteLine();
        Console.WriteLine("이전 화면으로 돌아가시려면 ESC, 전화 번호를 변경하시려면 1번, 주소를 변경하시려면 2번을 눌러주세요.");

        while (true)
        {
            string input = ReadNumber();
            if (input == "\0")
                break;

            switch (input)
            {
                case "1":
                    Console.WriteLine("변경하실 전화번호를 입력하세요. (숫자)");

                    while (true)
                    {
                        string phoneNumber = ReadNumber();
                        if (phoneNumber == "\0")
                            break;
                        if (phoneNumber.Length > 11)
                            Console.Write("전화번호가 너무 깁니다. 11자리 이하로 다시 입력하세요: ");
                        else
                        {
                            currentUser.PhoneNumber = phoneNumber;
                            break;
                        }
                    }

                    foreach (User user in userList)
                    {
                        if (user.Id == currentUser.Id)
                        {
                            user.PhoneNumber = currentUser.PhoneNumber;
                            UpdateUserFile(userList);
                            Console.WriteLine("전화번호를 변경했습니다.");
                        }
                    }
                    break;
                case "2":
                    Console.WriteLine("변경하실 주소를 입력하세요. (숫자/영어/한글)");

                    while (true)
                    {
                        string address = ReadString();
                        if (address == "\0")
                            break;
                        if (CheckEmpty(address))
                            Console.Write("주소는 공백일 수 없습니다. 다시 입력하세요: ");
                        else
                            currentUser.Address = address;
                            break;
                    }

                    foreach (User user in userList)
                    {
                        if (user.Id == currentUser.Id)
                        {
                            user.Address = currentUser.Address;
                            UpdateUserFile(userList);
                            Console.WriteLine("주소를 변경했습니다.");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("잘못 입력하셨습니다. 다시 입력하세요.");
                    break;
            }
        }

    }

    // 회원가입
    public void View_JoinToUser()
    {
        View_Title();

        string id;
        string password;
        string name;
        int age;
        string phoneNumber;
        string address;
        Console.Write("ID를 입력하세요. (숫자/영어)");
        while (true)
        {
            id = ReadEnglishOrNumber();
            if (id == "\0")
                goto Jump;

            if (CheckUserID(id))
                Console.Write("이미 존재하는 ID입니다. 다시 입력하세요: ");
            else if (CheckEmpty(id))
                Console.Write("ID는 공백일 수 없습니다. 다시 입력하세요: ");
            else
                break;
        }

        Console.Write("비밀번호를 입력하세요. (숫자/영어)");
        while (true)
        {
            password = ReadEnglishOrNumber();
            if (password == "\0")
                goto Jump;

            if (password.Length > 10)
                Console.Write("비밀번호가 너무 깁니다. 10자리 이하로 다시 입력하세요: ");
            else if (CheckEmpty(password))
                Console.Write("비밀번호는 공백일 수 없습니다. 다시 입력하세요: ");
            else
                break;
        }

        Console.Write("이름을 입력하세요. (한글)");
        while (true)
        {
            name = ReadKorean();
            if (name == "\0")
                goto Jump;
            if (name.Length > 4)
                Console.Write("이름이 너무 깁니다. 4자리 이하로 다시 입력하세요: ");
            else if (CheckEmpty(name))
                Console.Write("이름은 공백일 수 없습니다. 다시 입력하세요: ");
            else
                break;
        }

        Console.Write("나이를 입력하세요. (숫자)");
        while (true)
        {
            string ageString = ReadNumber();
            if (ageString == "\0")
                goto Jump;
            age = int.Parse(ageString);
            if (age > 100 || age < 1)
                Console.Write("1세부터 100세까지 회원가입 가능합니다. 다시 입력하세요: ");
            else
                break;
        }

        Console.Write("전화번호를 입력하세요. (숫자)");
        while (true)
        {
            phoneNumber = ReadNumber();
            if (phoneNumber == "\0")
                goto Jump;
            if (phoneNumber.Length > 11)
                Console.Write("전화번호가 너무 깁니다. 11자리 이하로 다시 입력하세요: ");
            else
                break;
        }

        Console.Write("주소를 입력하세요. (숫자/한글/영어)");
        while (true)
        {
            address = ReadString();
            if (address == "\0")
                goto Jump;

            if (CheckEmpty(address))
                Console.Write("주소는 공백일 수 없습니다. 다시 입력하세요: ");
            else
                break;
        }
        

        AddNewUser(id, password, name, age, phoneNumber, address);
        Console.WriteLine("회원 가입이 완료되었습니다.");
        Console.WriteLine("메인 화면으로 돌아가려면 ESC를 눌러주세요.");
        string input = ReadESC();
        if (input == "\0")
        {
            View_Main();
        }

    Jump:
        Console.WriteLine();
    }

    // 관리자 모드
    public void View_AdminMode()
    {
        View_Title();
        Console.WriteLine("관리자 비밀번호를 입력하세요: ");
        while (true)
        {
            string input1 = ReadString();
            if (input1 == "\0")
                break;

            if (input1 == "1234")
            {
                while (true)
                {
                    View_Title();
                    Console.WriteLine("1. 회원 리스트");
                    Console.WriteLine("2. 회원 검색");
                    Console.WriteLine("3. 회원 삭제");
                    Console.WriteLine("4. 책 리스트");
                    Console.WriteLine("5. 신규 책 등록");
                    Console.WriteLine("6. 책 정보 수정");
                    Console.WriteLine("7. 책 삭제");
                    Console.WriteLine("8. 책 대출/반납 기록");
                    Console.WriteLine("9. 돌아가기");

                    string input = ReadNumber();
                    if (input == "\0")
                        break;

                    switch (input)
                    {
                        case "1":
                            View_3_1();
                            break;
                        case "2":
                            View_3_2();
                            break;
                        case "3":
                            View_3_3();
                            break;
                        case "4":
                            // View_3_4();
                            View_1_4();
                            break;
                        case "5":
                            View_3_5();
                            break;
                        case "6":
                            View_3_6();
                            break;
                        case "7":
                            View_3_7();
                            break;
                        case "8":
                            View_3_8();
                            break;
                        case "9":
                            View_Main();
                            break;
                        default:
                            Console.WriteLine("잘못 입력했습니다. 다시 입력하세요.");
                            break;
                    }
                }
            }
            else
                Console.Write("비밀 번호가 틀렸습니다. 다시 입력하세요: ");
        }
        
    }

    // 전체 회원 리스트
    public void View_3_1()
    {
        while (true)
        {
            View_Title();
            View_UserList(userList);
            Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
            string input = ReadESC();
            if (input == "\0")
                break;
        }
    }

    // 회원 검색
    public void View_3_2()
    {
        View_Title();
        Console.WriteLine("검색하실 회원 이름을 입력하세요 (한글): ");

        while (true)
        {
            // 검색 리스트 초기화 
            searchedUserList = new List<User>();
            
            string input = ReadKorean();
            if (input == "\0")
                break;

            // 검색 리스트 생성
            SearchUserForName(input);
            if (searchedUserList.Count == 0)
            {
                Console.WriteLine("검색 결과가 없습니다. 다시 입력하세요. ");
            }
            else
            {
                View_UserList(searchedUserList);
                Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
                input = ReadESC();
                if (input == "\0")
                    break;
            }
        }
    }

    // 회원 삭제 
    public void View_3_3()
    {
        while (true)
        {
            View_Title();
            View_UserList(userList);
            Console.WriteLine("삭제하실 회원 ID를 입력하세요: ");
            while (true)
            {
                string input = ReadEnglishOrNumber();
                if (input == "\0")
                    break;

                bool check = RemoveUser(input);
                if (check)
                    break;
                else
                    Console.WriteLine("잘못 입력했습니다. 다시 입력하세요: ");
            }

            Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
            string input2 = ReadESC();
            if (input2 == "\0")
                break;
        }
    }

    // 신규 책 등록
    public void View_3_5()
    {
        View_Title();

        string id;
        string name;
        string publisher;
        string author;
        string price;
        int quantity;

        Console.Write("ID로 사용할 세 자리 숫자를 입력하세요. (숫자)");
        while (true)
        {
            string idNumber = ReadNumber();
            if (idNumber == "\0")
                goto Jump;

            id = "ID" + idNumber;
            if (idNumber.Length > 3)
                Console.Write("세 자리 숫자로 입력하세요.");
            else if (CheckBookID(id))
                Console.Write("이미 존재하는 ID입니다. 다시 입력하세요: ");
            else
                break;
        }

        Console.Write("책 이름을 입력하세요. (숫자/한글/영어)");
        while (true)
        {
            name = ReadString();
            if (name == "\0")
                goto Jump;

            if (CheckEmpty(name))
                Console.WriteLine("책 이름은 공백일 수 없습니다. 다시 입력하세요: ");
            else
                break;
        }

        Console.Write("출판사를 입력하세요. (숫자/한글/영어)");
        while (true)
        {
            publisher = ReadString();
            if (publisher == "\0")
                goto Jump;

            if (CheckEmpty(publisher))
                Console.WriteLine("책 출판사 이름은 공백일 수 없습니다. 다시 입력하세요: ");
            else
                break;
        }

        Console.Write("책 저자를 입력하세요. (한글)");
        while (true)
        {
            author = ReadKorean();
            if (author == "\0")
                goto Jump;

            if (name.Length > 5)
                Console.Write("이름이 너무 깁니다. 4자리 이하로 다시 입력하세요: ");
            else if (CheckEmpty(author))
                Console.WriteLine("책 저자 이름은 공백일 수 없습니다. 다시 입력하세요: ");
            else if (CheckBookNameAndAuthor(name, publisher, author))
                Console.Write("동일 저자, 동일 제목, 동일 출판사의 책이 등록되어 있습니다. 다시 입력하세요: ");
            else
                break;
        }

        Console.Write("가격을 입력하세요. (숫자)");
        while (true)
        {
            price = ReadNumber();
            if (price == "\0")
                goto Jump;

            if (price.Length > 6)
                Console.Write("책의 가격이 너무 높습니다. 6자리 이하로 다시 입력하세요: ");
            else
                break;
        }

        Console.Write("수량을 입력하세요. (숫자)");
        while (true)
        {
            string quantityString = ReadNumber();
            if (quantityString == "\0")
                goto Jump;
            quantity = int.Parse(quantityString);

            if (quantity > 100)
                Console.Write("책의 수량이 너무 많습니다. 100권 이하로 다시 입력하세요: ");
            else
                break;
        }

        string isbn = "1";
        AddNewBook(id, isbn, name, publisher, author, int.Parse(price), quantity);
        Console.WriteLine("신규 책 등록이 완료되었습니다.");
        Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
        string input = ReadESC();
        if (input == "\0")
            View_AdminMode();

        Jump:
        Console.WriteLine();

    }

    // 책 정보 수정
    public void View_3_6()
    {
        View_Title();
        View_BookList(bookList);
        Console.WriteLine("정보를 수정하실 책의 ID를 입력해주세요.");
        while (true)
        {
            // 검색 리스트 초기화 
            searchedBookList = new List<Book>();

            string id = ReadEnglishOrNumber();
            if (id == "\0")
                break;

            if (CheckBookID(id))
            {
                foreach (Book book in bookList)
                {
                    if (book.Id == id)
                    {
                        currentBook = book;
                    }
                }
                searchedBookList.Add(currentBook);
                View_Title();
                View_BookList(searchedBookList);
                Console.WriteLine($"{currentBook.Name}의 가격을 변경하려면 1번, 수량을 변경하려면 2번을 눌러주세요. ");

                while (true)
                {
                    string input = ReadNumber();
                    if (input == "\0")
                        break;

                    switch (input)
                    {
                        case "1":
                            Console.WriteLine("변경할 가격을 입력해주세요. ");
                            string price = ReadNumber();
                            currentBook.Price = int.Parse(price);
                            foreach (Book book in bookList)
                            {
                                if (book.Id == id)
                                {
                                    book.Price = currentBook.Price;
                                    UpdateBookFile(bookList);
                                    Console.WriteLine("가격을 변경했습니다.");
                                }
                            }
                            break;
                        case "2":
                            Console.WriteLine("변경할 수량을 입력해주세요. ");
                            string quantityString = ReadNumber();
                            int quantity = int.Parse(quantityString);
                            currentBook.Quantity = quantity;
                            foreach (Book book in bookList)
                            {
                                if (book.Quantity == quantity)
                                {
                                    book.Quantity = currentBook.Quantity;
                                    UpdateBookFile(bookList);
                                    Console.WriteLine("수량을 변경했습니다.");
                                }
                            }
                            break;
                        default:
                            Console.Write("잘못 입력했습니다. 다시 입력하세요: ");
                            break;
                    }
                }
            }
            else
            {
                Console.Write("검색 결과가 없습니다. 다시 입력하세요: ");
            }
        }
    }

    // 책 삭제
    public void View_3_7()
    {
        while (true)
        {
            View_Title();

            View_BookList(bookList);
            Console.WriteLine("삭제하실 책 ID을 입력하세요: ");
            while (true)
            {
                string input = ReadEnglishOrNumber();
                if (input == "\0")
                    break;

                bool check = RemoveBook(input);
                if (check)
                    break;
                else
                    Console.WriteLine("잘못 입력했습니다. 다시 입력하세요: ");
            }

            Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
            string input2 = ReadESC();
            if (input2 == "\0")
                break;
        }
    }

    // 책 대출, 반납 기록
    public void View_3_8()
    {
        while (true)
        {
            View_Title();
            foreach (BookHistory bookHistory in bookHistoryList)
            {
                if (bookHistory.BorrowTime != null)
                {
                    Console.WriteLine($"{bookHistory.BorrowTime}: \"{bookHistory.UserName}\"님이 <{bookHistory.BookName}> 도서를 대출하셨습니다.");
                }
                else
                {
                    Console.WriteLine($"{bookHistory.ReturnTime}: \"{bookHistory.UserName}\"님이 <{bookHistory.BookName}> 도서를 반납하셨습니다.");
                }
            }
            Console.WriteLine();
            Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
            string input = ReadESC();
            if (input == "\0")
                break;
        }
    }

    // 네이버로 책 검색
    public void View_3_9()
    {
        NaverAPI naverAPI = new NaverAPI();
        Console.WriteLine("검색어를 입력하세요.");
        string input = Console.ReadLine();
        Console.WriteLine($">>{input}<<");

        Console.WriteLine("검색 결과를 몇 개씩 볼 지를 입력하세요.");
        string number = Console.ReadLine();

        naverAPI.NaverSearchBook("title", input, number);
    }

    // End
}
