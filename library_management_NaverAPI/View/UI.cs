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
            Console.WriteLine($"책 총 수량: {book.Quantity}");
            Console.WriteLine($"책 현재 수량: {book.CurrentQuantity}");
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
            Console.WriteLine($"신청중인 포인트: {user.AppliedPoint}");
            Console.WriteLine($"보유중인 포인트: {user.Point}");
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

        HistoryOfLogin();

        while (true)
        {
            View_Title();
            Console.WriteLine($"로그인 성공. 반갑습니다. {currentUser.Name}님");
            Console.WriteLine("1. 책 검색");
            Console.WriteLine("2. 책 대출");
            Console.WriteLine("3. 책 반납");
            Console.WriteLine("4. 책 리스트");
            Console.WriteLine("5. 나의 회원 정보");
            Console.WriteLine("6. 인기 도서 확인하기");
            Console.WriteLine("7. 포인트 충전하기");
            Console.WriteLine("8. 처음 메뉴로 가기");
            Console.WriteLine("9. 종료");

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
                    View_1_6();
                    break;
                case "7":
                    View_1_7();
                    break;
                case "8":
                    View_Main();
                    break;
                case "9":
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
        while (true)
        {
            View_Title();
            Console.WriteLine("검색하실 책 이름을 입력하세요: ");

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
                Console.WriteLine("검색 결과가 없습니다. Enter를 눌러 검색화면으로 돌아가세요. ");
                while (Console.ReadKey().Key != ConsoleKey.Enter) { };
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
        while (true)
        {
            View_Title();
            Console.WriteLine("검색하실 책 저자명을 입력하세요: ");

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
        while (true)
        {
            View_Title();
            Console.WriteLine("검색하실 책 출판사를 입력하세요: ");

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
        while (true)
        {
            View_Title();
            Console.WriteLine("검색하실 책 이름을 입력하세요: ");

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
                Console.WriteLine("검색 결과가 없습니다. Enter를 눌러 검색화면으로 돌아가세요. ");
                while (Console.ReadKey().Key != ConsoleKey.Enter) { };
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
                        Console.WriteLine("다시 입력하세요: ");
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
        while (true)
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
        Console.WriteLine($"신청중인 포인트: {currentUser.AppliedPoint}");
        Console.WriteLine($"보유중인 포인트: {currentUser.Point}");
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
                            UploadUserDB();
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
                            UploadUserDB();
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

    // 인기 도서 
    public void View_1_6()
    {
        while (true)
        {
            View_Title();
            Console.WriteLine("다른 사람들은 어떤 도서를 많이 대출했는지 확인해보세요.");
            foreach (Book book in bookList)
            {
                Console.WriteLine(book.Name);
                foreach (Log log in logList)
                {
                    if (book.Name == log.BookName)
                    {
                        Console.Write("⭐️");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------");
            }

            Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
            string input = ReadESC();
            if (input == "\0")
                break;
        }
    }

    // 포인트 충전하기
    public void View_1_7()
    {
        while (true)
        {
            View_Title();
            Console.WriteLine($"{currentUser.Name}님의 포인트 내역입니다.");
            Console.WriteLine($"신청중인 포인트: {currentUser.AppliedPoint}");
            Console.WriteLine($"보유중인 포인트: {currentUser.Point}");
            Console.WriteLine("포인트를 충전하시려면 아래 계좌로 송금 후, 포인트 충전을 신청해주세요. [1000원 = 1000포인트]");
            Console.WriteLine("관리자가 승인하면 충전이 완료되고, 승인하지 않으면 입금하신 계좌로 환불됩니다.");
            Console.WriteLine("예금주명: 도서관장 | 카카오뱅크 12-3456-7890");
            Console.WriteLine("얼마를 충전하시겠습니까? (1000원 단위로 충전할 수 있습니다.)");

            while (true)
            {
                string input1 = ReadNumber();
                if (input1 == "\0")
                    break;
                else if (int.Parse(input1) % 1000 != 0)
                    Console.WriteLine("다시 입력하세요.");
                else
                {
                    Console.WriteLine(input1 + " 포인트 충전 신청했습니다.");
                    currentUser.AppliedPoint += int.Parse(input1);
                    UploadUserDB();
                }

            }
            
            Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
            string input = ReadESC();
            if (input == "\0")
                break;
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
        while (true)
        {
            View_Title();
            Console.WriteLine("관리자 비밀번호를 입력하세요: ");
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
                    Console.WriteLine("5. 네이버로 검색하여 신규 책 등록");
                    Console.WriteLine("6. 책 정보 수정");
                    Console.WriteLine("7. 책 삭제");
                    Console.WriteLine("8. 로그 기록");
                    Console.WriteLine("9. 성실 회원 확인하기");
                    Console.WriteLine("10. 포인트 충전 신청 관리하기");
                    Console.WriteLine("11. 돌아가기");

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
                            View_3_9();
                            break;
                        case "10":
                            View_3_10();
                            break;
                        case "11":
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
        while (true)
        {
            View_Title();
            Console.WriteLine("검색하실 회원 이름을 입력하세요 (한글): ");

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
        while (true)
        {
            while (true)
            {
                View_Title();

                Console.Write("네이버로 구매하고 싶은 책을 검색하세요. 제목으로 검색하려면 1번, 저자로 검색하려면 2번을 눌러주세요.");

                string input = ReadNumber();
                if (input == "\0")
                    break;

                switch (input)
                {
                    case "1":
                        Console.Write("검색 결과를 몇 개씩 보시겠습니까?");
                        string input1 = ReadNumber();
                        if (input1 == "\0")
                            View_AdminMode();

                        Console.Write("검색어를 입력하세요.");
                        string input2 = ReadString();
                        if (input1 == "\0")
                            View_AdminMode();

                        NaverSearchBook("title", input2, input1);
                        break;
                    case "2":
                        Console.Write("검색 결과를 몇 개씩 보시겠습니까?");
                        input1 = ReadNumber();
                        if (input1 == "\0")
                            View_AdminMode();

                        Console.Write("검색어를 입력하세요.");
                        input2 = ReadString();
                        if (input1 == "\0")
                            View_AdminMode();

                        NaverSearchBook("author", input2, input1);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
            string input3 = ReadESC();
            if (input3 == "\0")
                break;
        }
        
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
                            if (input == "\0")
                                break;

                            currentBook.Price = int.Parse(price);
                            foreach (Book book in bookList)
                            {
                                if (book.Id == id)
                                {
                                    book.Price = currentBook.Price;
                                    UploadBookDB();
                                    Console.WriteLine("가격을 변경했습니다.");
                                }
                            }
                            break;
                        case "2":
                            Console.WriteLine("변경할 수량을 입력해주세요. ");
                            string quantityString = ReadNumber();
                            if (input == "\0")
                                break;

                            int quantity = int.Parse(quantityString);
                            currentBook.Quantity = quantity;
                            foreach (Book book in bookList)
                            {
                                if (book.Id == id)
                                {
                                    book.Quantity = currentBook.Quantity;
                                    UploadBookDB();
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
                    Console.WriteLine("다시 입력하세요: ");
            }

            Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
            string input2 = ReadESC();
            if (input2 == "\0")
                break;
        }
    }

    // 로그 기록 보기
    public void View_3_8()
    {
        while (true)
        {
            View_Title();
            foreach (Log log in logList)
            {
                string typeOfLog = log.Type;
                switch (typeOfLog)
                {
                    case "로그인":
                        Console.WriteLine($"{log.Time}: \"{log.UserName}\"님이 로그인했습니다.");
                        break;
                    case "대출":
                        Console.WriteLine($"{log.Time}: \"{log.UserName}\"님이 <{log.BookName}>을 대출했습니다.");
                        break;
                    case "반납":
                        Console.WriteLine($"{log.Time}: \"{log.UserName}\"님이 <{log.BookName}>을 반납했습니다.");
                        break;
                    case "구매":
                        Console.WriteLine($"{log.Time}: \"{log.UserName}\"님이 <{log.BookName}>을 구매했습니다.");
                        break;
                    case "삭제":
                        Console.WriteLine($"{log.Time}: \"{log.UserName}\"님이 <{log.BookName}>을 삭제했습니다.");
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine();
            Console.WriteLine("로그를 타입별로 확인하려면 아래처럼 숫자를 눌러주세요.");
            Console.WriteLine("1: 로그인");
            Console.WriteLine("2: 대출");
            Console.WriteLine("3: 반납");
            Console.WriteLine("4: 구매");
            Console.WriteLine("5: 삭제");
            Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");

            while (true)
            {
                string input = ReadNumber();
                if (input == "\0")
                    break;

                switch (input)
                {
                    case "1":
                        View_Title();
                        Console.WriteLine("1: 로그인");
                        foreach (Log log in logList)
                        {
                            string typeOfLog = log.Type;
                            if (typeOfLog == "로그인")
                                Console.WriteLine($"{log.Time}: \"{log.UserName}\"님이 로그인했습니다.");
                        }
                        break;
                    case "2":
                        View_Title();
                        Console.WriteLine("2: 대출");
                        foreach (Log log in logList)
                        {
                            string typeOfLog = log.Type;
                            if (typeOfLog == "대출")
                                Console.WriteLine($"{log.Time}: \"{log.UserName}\"님이 <{log.BookName}>을 대출했습니다.");
                        }
                        break;
                    case "3":
                        View_Title();
                        Console.WriteLine("3: 반납");
                        foreach (Log log in logList)
                        {
                            string typeOfLog = log.Type;
                            if (typeOfLog == "반납")
                                Console.WriteLine($"{log.Time}: \"{log.UserName}\"님이 <{log.BookName}>을 반납했습니다.");
                        }
                        break;
                    case "4":
                        View_Title();
                        Console.WriteLine("4: 구매");
                        foreach (Log log in logList)
                        {
                            string typeOfLog = log.Type;
                            if (typeOfLog == "구매")
                                Console.WriteLine($"{log.Time}: \"{log.UserName}\"님이 <{log.BookName}>을 구매했습니다.");
                        }
                        break;
                    case "5":
                        View_Title();
                        Console.WriteLine("5: 삭제");
                        foreach (Log log in logList)
                        {
                            string typeOfLog = log.Type;
                            if (typeOfLog == "삭제")
                                Console.WriteLine($"{log.Time}: \"{log.UserName}\"님이 <{log.BookName}>을 삭제했습니다.");
                        }
                        break;
                    default:
                        Console.WriteLine("잘못 입력했습니다. 다시 입력하세요.");
                        break;
                }
            }
            
            Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
            string input1 = ReadESC();
            if (input1 == "\0")
                break;

        }
    }

    public void View_3_9()
    {
        while (true)
        {
            View_Title();
            Console.WriteLine("어떤 회원이 활동을 많이 했는지 확인해보세요.");
            foreach (User user in userList)
            {
                Console.WriteLine("회원명: " + user.Name);
                string login = "";
                string borrowBook = "";
                string returnBook = "";

                foreach (Log log in logList)
                {
                    if (user.Name == log.UserName)
                    {
                        switch (log.Type)
                        {
                            case "로그인":
                                login = login + "⭐️";
                                break;
                            case "대출":
                                borrowBook = borrowBook + "⭐️";
                                break;
                            case "반납":
                                returnBook = returnBook + "⭐️";
                                break;
                            default:
                                break;
                        }
                    }
                }
                Console.WriteLine("로그인: " + login);
                Console.WriteLine("대출: " + borrowBook);
                Console.WriteLine("반납: " + returnBook);
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------");
            }

            Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
            string input = ReadESC();
            if (input == "\0")
                break;
        }
    }

    // 포인트 충전 관리 
    public void View_3_10()
    {
        while (true)
        {
            View_Title();
            Console.WriteLine("회원들의 포인트 충전 신청 내역입니다.");
            foreach (User user in userList)
            {
                Console.WriteLine("회원명: " + user.Name);
                Console.WriteLine("신청한 포인트: " + user.AppliedPoint);
                Console.WriteLine("--------------------------------------------------");
            }
            Console.WriteLine("계좌의 입금 내역을 확인하신 후, 포인트 충전 신청을 승인 / 거절하려면 해당 회원명을 입력하세요.");
            while (true)
            {
                string input = ReadKorean();
                if (input == "\0")
                    break;

                foreach (User user in userList)
                {
                    if (input == user.Name)
                    {
                        Console.WriteLine($"{user.Name}님의 포인트 충전 신청을 승인하려면 1, 거절하려면 2번을 눌러주세요.");
                        string input1 = ReadNumber();
                        if (input1 == "\0")
                            break;
                        else if (input1 == "1")
                        {
                            Console.WriteLine($"{user.Name}님의 포인트 충전 신청이 승인되었습니다.");
                            user.Point += user.AppliedPoint;
                            user.AppliedPoint = 0;
                            UploadUserDB();
                            break;
                        }
                        else if (input1 == "2")
                        {
                            Console.WriteLine($"{user.Name}님의 포인트 충전 신청이 거절되었습니다.");
                            user.AppliedPoint = 0;
                            UploadUserDB();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("잘못 입력하셨습니다.");
                            break;
                        }
                    }
                }
            }
            
            Console.WriteLine("이전 화면으로 돌아가려면 ESC를 눌러주세요.");
            string input2 = ReadESC();
            if (input2 == "\0")
                break;
        }
    }

    // End
}
