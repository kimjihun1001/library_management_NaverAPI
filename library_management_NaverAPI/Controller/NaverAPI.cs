using System;
// Naver API 이용할 때 필요
using System.Net;
using System.Text;
using System.IO;

using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using System.Text.RegularExpressions;

public class NaverAPI : TreatDB_MySQL
{
    public void NaverSearchBook(string searchField, string searchWord, string displayNumber)
    {
        const string NAVER_ID = "xQKhYDcaW4DZ5JNHdmXJ";
        const string NAVER_SECRET = "869iq_F6ep";
        const string NAVER_URL = "https://openapi.naver.com/v1/search/book_adv.xml";
        const string NAVER_SearchForTitle = "?d_titl=";
        const string NAVER_SearchForAuthor = "?d_auth=";
        const string NAVER_DISPLAY_STRING = "&display=";

        string url;
        int startNumber = 1;    // 화면에 표시 시작할 부분 
        int page = 1;   // 현재 페이지 
        int totalPage = 1;  // 전체 페이지 

        while (true)
        {
            // 타이틀 출력 
            UI ui2 = new UI();
            ui2.View_Title();

            // 제목 혹은 저자로 검색 
            if (searchField == "title")
            {
                url = NAVER_URL + NAVER_SearchForTitle + searchWord + NAVER_DISPLAY_STRING + displayNumber + "&start=" + startNumber.ToString();
            }
            else if (searchField == "author")
            {
                url = NAVER_URL + NAVER_SearchForAuthor + searchWord + NAVER_DISPLAY_STRING + displayNumber + "&start=" + startNumber.ToString();
            }
            else
            {
                url = "";
                Console.WriteLine("검색 분야를 잘못 설정했습니다.");
            }

            // 요청
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // API 접근
            request.Headers.Add("X-Naver-Client-Id", NAVER_ID);
            request.Headers.Add("X-Naver-Client-Secret", NAVER_SECRET);

            // 응답 받기
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Xml 파일 받아오기
            Stream stream = response.GetResponseStream();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(stream);
            //Console.WriteLine(xmlDocument.InnerXml);

            // Xml 파일 분해하기
            XmlNode firstNode = xmlDocument.SelectSingleNode("rss");
            XmlNode secondNode = firstNode.SelectSingleNode("channel");
            XmlNodeList xmlNodeList = secondNode.SelectNodes("item");
            // 검색 결과의 갯수
            XmlNode SearchResultCountNode = secondNode.SelectSingleNode("total");
            XmlNode SearchResultDisplayCountNode = secondNode.SelectSingleNode("display");

            if (SearchResultCountNode.InnerText == "0")
            {
                Console.WriteLine($"총 검색 결과: {SearchResultCountNode.InnerText}건");
                Console.WriteLine("검색 결과가 없습니다.");
                break;
            }
            else if (SearchResultDisplayCountNode.InnerText == "0")
            {
                Console.WriteLine("더 이상 페이지가 없습니다.");
            }
            else
            {
                int quotient = int.Parse(SearchResultCountNode.InnerText) / int.Parse(displayNumber);
                int remainder = int.Parse(SearchResultCountNode.InnerText) % int.Parse(displayNumber);

                if (remainder != 0)
                {
                    totalPage = quotient + 1;
                }
                else
                {
                    totalPage = quotient;
                }
                
                Console.WriteLine($"총 검색 결과: {SearchResultCountNode.InnerText}권 ");
                Console.WriteLine($"현재 페이지: {page} / {totalPage}");
                Console.WriteLine();

                foreach (XmlNode xmlNode in xmlNodeList)
                {
                    string name = CutTag(xmlNode.SelectSingleNode("title").InnerText);
                    string author = CutTag(xmlNode.SelectSingleNode("author").InnerText);
                    string price = CutTag(xmlNode.SelectSingleNode("price").InnerText);
                    string discount = CutTag(xmlNode.SelectSingleNode("discount").InnerText);
                    string publisher = CutTag(xmlNode.SelectSingleNode("publisher").InnerText);
                    string isbn = CutTag(xmlNode.SelectSingleNode("isbn").InnerText);

                    Console.WriteLine("제목: " + name);
                    Console.WriteLine("저자: " + author);
                    Console.WriteLine("가격: " + price);
                    Console.WriteLine("할인 가격: " + discount);
                    Console.WriteLine("출판사: " + publisher);
                    Console.WriteLine("ISBN: " + isbn);
                    Console.WriteLine("--------------------------------------------------");

                }
            }

            Console.WriteLine("목록에서 구매할 책이 있으면 Enter, 뒤로 돌아가려면 ESC, 검색 목록의 다른 페이지로 이동하려면 좌우방향키를 눌러주세요.");

            ConsoleKeyInfo key;
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Escape) 
            {
                break;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine("구매할 책의 ISBN 뒷 13자리를 입력하세요");
                
                while (true)
                {
                    string input = ReadNumber();
                    if (input == "\0")
                        break;

                    bool IsThereResult = false;
                    bool IsThereAlready = false;

                    foreach (XmlNode xmlNode in xmlNodeList)
                    {
                        string name = CutTag(xmlNode.SelectSingleNode("title").InnerText);
                        string author = CutTag(xmlNode.SelectSingleNode("author").InnerText);
                        string price = CutTag(xmlNode.SelectSingleNode("price").InnerText);
                        string discount = CutTag(xmlNode.SelectSingleNode("discount").InnerText);
                        string publisher = CutTag(xmlNode.SelectSingleNode("publisher").InnerText);
                        string isbn = CutTag(xmlNode.SelectSingleNode("isbn").InnerText);

                        string[] isbnShort = isbn.Split(" ");
                        if (input == isbnShort[1])
                        {
                            foreach (Book book in bookList)
                            {
                                if (book.Isbn == input)
                                {
                                    Console.WriteLine("이미 존재하는 책입니다.");
                                    IsThereAlready = true;
                                    break;
                                }
                            }

                            if (!IsThereAlready)
                            {
                                Console.WriteLine("구매하실 수량을 입력하세요");
                                string input1 = ReadNumber();
                                if (input1 == "\0")
                                    break;

                                int idNumber = int.Parse(bookList[bookList.Count - 1].Id) + 1;
                                string id = idNumber.ToString();
                                if (id.Length == 1)
                                {
                                    id = "00" + id;
                                }
                                else if (id.Length == 2)
                                {
                                    id = "0" + id;
                                }

                                // 왠지 모르지만 null로 하면 안되길래 ""로 함.
                                if (discount != "")
                                {
                                    price = discount;
                                }

                                Book book1 = new Book(id, input, name, publisher, author, int.Parse(price), int.Parse(input1), int.Parse(input1));
                                DataProcessing dataProcessing = new DataProcessing();
                                dataProcessing.HistoryOfAdd(book1);
                                bookList.Add(book1);
                                UploadBookDB();
                                Console.WriteLine("신규 책 등록이 완료되었습니다.");
                                IsThereResult = true;
                                while (Console.ReadKey().Key != ConsoleKey.Enter) { };
                            }

                            break;
                        }
                    }

                    if (IsThereResult)
                        break;
                    else
                        Console.WriteLine("다시 입력하세요.");
                }
                
                    
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                // 그냥 page랑 totalPage 만들어서 사용 
                if (page < totalPage)
                {
                    page++;
                    startNumber += int.Parse(displayNumber);
                }
                
                //// display하기로 한 숫자보다 현재 display된 항목이 적을 경우, 마지막 페이지기 때문에 뒤로 넘어가지 않음
                //if (int.Parse(SearchResultDisplayCountNode.InnerText) == int.Parse(displayNumber))
                //    startNumber += int.Parse(displayNumber);
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                if (page != 1)
                {
                    page--;
                    startNumber -= int.Parse(displayNumber);
                }

                //if (startNumber != 1)
                //    startNumber -= int.Parse(displayNumber);
            }
        }


        // 가져온 text 내부의 HTML 태그 제거 함수
        // 저자명의 |는 안 지워짐
        string CutTag(string input)
        {
            return Regex.Replace(input, @"<(.|\n)*?>", string.Empty);
        }
    }

    public bool NaverSearchAdult(string searchWord)
    {
        const string NAVER_ID = "xQKhYDcaW4DZ5JNHdmXJ";
        const string NAVER_SECRET = "869iq_F6ep";
        const string NAVER_URL = "https://openapi.naver.com/v1/search/adult.xml";
        const string NAVER_SearchFor = "?query=";
        string url = NAVER_URL + NAVER_SearchFor + searchWord;

        // 요청
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

        // API 접근
        request.Headers.Add("X-Naver-Client-Id", NAVER_ID);
        request.Headers.Add("X-Naver-Client-Secret", NAVER_SECRET);

        // 응답 받기
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        // Xml 파일 받아오기
        Stream stream = response.GetResponseStream();
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(stream);
        //Console.WriteLine(xmlDocument.InnerXml);

        // Xml 파일 분해하기
        XmlNode firstNode = xmlDocument.SelectSingleNode("result");
        XmlNode secondNode = firstNode.SelectSingleNode("item");
        XmlNode adultNode = secondNode.SelectSingleNode("adult");

        if (adultNode.InnerText == "1")
        {
            return true;
        }
        else if (adultNode.InnerText == "0")
        {
            return false;
        }
        else
        {
            return false;
        }
    }

}