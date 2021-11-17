using System;

[Serializable]
public class MenuControl
{
    public string ReadString()    // ESC, Enter, Backspace / 한글, 영어, 숫자, 스페이스
    {
        string readString = "";
        ConsoleKeyInfo key;
        while (true)
        {
            key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Escape
                && IsString(key))
            {
                readString += key.KeyChar;
                Console.Write(key.KeyChar);
            }
            else if (key.Key == ConsoleKey.Backspace && readString.Length > 0)
            {   
                int lastIndex = readString.Length - 1;
                if (readString[lastIndex] >= '가' && readString[lastIndex] <= '힣')       //한글일경우
                {
                    readString = readString.Substring(0, (readString.Length - 1));
                    Console.Write("\b\b  \b\b");
                }
                else
                {
                    readString = readString.Substring(0, (readString.Length - 1));  //한글 이외의 문자.
                    Console.Write("\b \b");
                }
            }
            else if (key.Key == ConsoleKey.Escape)      //esc 누를 경우 null 반환
            {
                return "\0";
            }
            else if (key.Key == ConsoleKey.Enter)       //엔터를 누를경우 저장된 스트링 반환
            {
                if (readString == "")
                    continue;
                // 입력끝난 이후, 다음 줄로 넘어가도록 
                Console.WriteLine();
                return readString;
            }
        }
    }
    
    // 책 이름 입력할 때, 공백으로 두지 않도록. 근데 문제는 띄어쓰기도 못하네 ㅜ 그냥 체크 함수 따로 만들자 
    public string ReadStringNotSpace()    // ESC, Enter, Backspace / 한글, 영어, 숫자
    {
        string readString = "";
        ConsoleKeyInfo key;
        while (true)
        {
            key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Escape
                && IsStringNotSpace(key))
            {
                readString += key.KeyChar;
                Console.Write(key.KeyChar);
            }
            else if (key.Key == ConsoleKey.Backspace && readString.Length > 0)
            {
                int lastIndex = readString.Length - 1;
                if (readString[lastIndex] >= '가' && readString[lastIndex] <= '힣')       //한글일경우
                {
                    readString = readString.Substring(0, (readString.Length - 1));
                    Console.Write("\b\b  \b\b");
                }
                else
                {
                    readString = readString.Substring(0, (readString.Length - 1));  //한글 이외의 문자.
                    Console.Write("\b \b");
                }
            }
            else if (key.Key == ConsoleKey.Escape)      //esc 누를 경우 null 반환
            {
                return "\0";
            }
            else if (key.Key == ConsoleKey.Enter)       //엔터를 누를경우 저장된 스트링 반환
            {
                if (readString == "")
                    continue;
                // 입력끝난 이후, 다음 줄로 넘어가도록 
                Console.WriteLine();
                return readString;
            }
        }
    }

    public string ReadNumber()    //숫자만 입력하는 메소드
    {
        string Number = "";
        ConsoleKeyInfo key;
        while (true)
        {
            key = Console.ReadKey(true);
            if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Escape
              && IsNumber(key))
            {
                Number += key.KeyChar;
                Console.Write(key.KeyChar);
            }
            else if (key.Key == ConsoleKey.Backspace && Number.Length > 0)
            {
                Number = Number.Substring(0, (Number.Length - 1));
                Console.Write("\b \b");
            }

            else if (key.Key == ConsoleKey.Escape)      //ESC이면 NULL 반환.
            {
                return "\0";
            }

            else if (key.Key == ConsoleKey.Enter)       //엔터누르면 값반환.
            {
                if (Number == "")
                    continue;
                // 입력끝난 이후, 다음 줄로 넘어가도록 
                Console.WriteLine();
                return Number;
            }
        }
    }

    public string ReadEnglishOrNumber()
    {
        string input = "";
        ConsoleKeyInfo key;
        while (true)
        {
            key = Console.ReadKey(true);
            if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Escape
              && IsEnglishOrNumber(key))
            {
                input += key.KeyChar;
                Console.Write(key.KeyChar);
            }
            else if (key.Key == ConsoleKey.Backspace && input.Length > 0)
            {
                input = input.Substring(0, (input.Length - 1));
                Console.Write("\b \b");
            }

            else if (key.Key == ConsoleKey.Escape)      //ESC이면 NULL 반환.
            {
                return "\0";
            }

            else if (key.Key == ConsoleKey.Enter)       //엔터누르면 값반환.
            {
                if (input == "")
                    continue;
                // 입력끝난 이후, 다음 줄로 넘어가도록 
                Console.WriteLine();
                return input;
            }
        }
    }

    public string ReadKorean()
    {
        string input = "";
        ConsoleKeyInfo key;
        while (true)
        {
            key = Console.ReadKey(true);
            if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Escape
              && IsKorean(key))
            {
                input += key.KeyChar;
                Console.Write(key.KeyChar);
            }
            else if (key.Key == ConsoleKey.Backspace && input.Length > 0)
            {
                input = input.Substring(0, (input.Length - 1));
                Console.Write("\b \b");
            }

            else if (key.Key == ConsoleKey.Escape)      //ESC이면 NULL 반환.
            {
                return "\0";
            }

            else if (key.Key == ConsoleKey.Enter)       //엔터누르면 값반환.
            {
                if (input == "")
                    continue;
                // 입력끝난 이후, 다음 줄로 넘어가도록 
                Console.WriteLine();
                return input;
            }
        }
    }

    public string ReadESC()    //ESC만 입력하는 메소드
    {
        ConsoleKeyInfo key;
        while (true)
        {
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Escape)      //ESC이면 NULL 반환.
            {
                return "\0";
            }
        }
    }

    public bool IsNumber(ConsoleKeyInfo key)      //입력값이 숫자인지 체크
    {
        char trying = key.KeyChar;
        if (key == null) return false;  // 이 부분이 동작을 안하는 것 같긴 한데... 일단 그냥 쓰자. 나중에 확인해보기 
        if ((key.KeyChar >= '0' && key.KeyChar <= '9'))
            return true;
        return false;
    }

    public bool IsString(ConsoleKeyInfo key)      //입력값이 한글, 영어, 숫자, 스페이스인지 체크
    {
        char trying = key.KeyChar;
        if (key == null) return false;
        if ((key.KeyChar >= 'a' && key.KeyChar <= 'z') || (key.KeyChar >= 'A' && key.KeyChar <= 'Z') || (key.KeyChar >= '0' && key.KeyChar <= '9') ||
            (key.KeyChar >= '가' && key.KeyChar <= '힣') || key.KeyChar == ' ')
            return true;
        return false;
    }

    public bool IsStringNotSpace(ConsoleKeyInfo key)      //입력값이 한글, 영어, 숫자인지 체크
    {
        char trying = key.KeyChar;
        if (key == null) return false;
        if ((key.KeyChar >= 'a' && key.KeyChar <= 'z') || (key.KeyChar >= 'A' && key.KeyChar <= 'Z') || (key.KeyChar >= '0' && key.KeyChar <= '9') ||
            (key.KeyChar >= '가' && key.KeyChar <= '힣'))
            return true;
        return false;
    }

    public bool IsKorean(ConsoleKeyInfo key)    //입력값이 한글, 스페이스인지 체크
    {
        char trying = key.KeyChar;
        if (key == null) return false;
        if ((key.KeyChar >= '가' && key.KeyChar <= '힣') || key.KeyChar == ' ')
            return true;
        return false;
    }

    public bool IsEnglish(ConsoleKeyInfo key)    //입력값이 영어, 스페이스인지 체크
    {
        char trying = key.KeyChar;
        if (key == null) return false;
        if ((key.KeyChar >= 'a' && key.KeyChar <= 'z') || (key.KeyChar >= 'A' && key.KeyChar <= 'Z') || key.KeyChar == ' ')
            return true;
        return false;
    }

    public bool IsEnglishOrNumber(ConsoleKeyInfo key)    //입력값이 영어, 숫자, 스페이스인지 체크
    {
        char trying = key.KeyChar;
        if (key == null) return false;
        if ((key.KeyChar >= 'a' && key.KeyChar <= 'z') || (key.KeyChar >= 'A' && key.KeyChar <= 'Z') || (key.KeyChar >= '0' && key.KeyChar <= '9') || key.KeyChar == ' ')
            return true;
        return false;
    }
}