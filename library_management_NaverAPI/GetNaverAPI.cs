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

class NaverAPI
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
        int page = 1;
        bool IsThereResult = true;
        
        while (true)
        {
            if (searchField == "title")
            {
                url = NAVER_URL + NAVER_SearchForTitle + searchWord + NAVER_DISPLAY_STRING + displayNumber + "&start=" + page.ToString();
            }
            else if (searchField == "author")
            {
                url = NAVER_URL + NAVER_SearchForAuthor + searchWord + NAVER_DISPLAY_STRING + "20" + "&start=1";
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
                Console.WriteLine("검색 결과가 없습니다.");
            }
            else if (SearchResultDisplayCountNode.InnerText == "0")
            {
                Console.WriteLine("더 이상 페이지가 없습니다.");
            }
            else
            {
                foreach (XmlNode xmlNode in xmlNodeList)
                {
                    Console.WriteLine(xmlNode.SelectSingleNode("title").InnerText);
                    Console.WriteLine(xmlNode.SelectSingleNode("author").InnerText);
                    Console.WriteLine(xmlNode.SelectSingleNode("price").InnerText);
                    Console.WriteLine(xmlNode.SelectSingleNode("discount").InnerText);
                    Console.WriteLine(xmlNode.SelectSingleNode("publisher").InnerText);
                    Console.WriteLine(xmlNode.SelectSingleNode("isbn").InnerText);
                    Console.WriteLine();
                    //if (xmlNode.SelectSingleNode("discount").InnerText == "")   // 왠지 모르지만 null로 하면 안되길래 ""로 함.
                    //{
                    //    Console.WriteLine(xmlNode.SelectSingleNode("title").InnerText); // 책 제목
                    //    Console.WriteLine("할인 가격 없음");
                    //}
                }
            }

            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.RightArrow)
            {
                if (SearchResultDisplayCountNode.InnerText != "0")
                    page += int.Parse(displayNumber);
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                if (page != 1)
                    page -= int.Parse(displayNumber);
            }
        }
        //Console.WriteLine(CutTag("야야<야>호호"));

        //// 가져온 text 내부의 태그 제거 함수
        //string CutTag(string input)
        //{
        //    return Regex.Replace(input, @"<(.|\n)*?>", string.Empty);
        //}

    }
}