using System;
// Naver API 이용할 때 필요
using System.Net;
using System.Text;
using System.IO;

using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

class NaverAPI
{
    public void NaverSearchBook(string searchWord)
    {
        const string NAVER_DISPLAY_STRING = "&display=";
        const string NAVER_ID = "xQKhYDcaW4DZ5JNHdmXJ";
        const string NAVER_SECRET = "869iq_F6ep";
        const string NAVER_URL = "https://openapi.naver.com/v1/search/book_adv.xml";
        const string NAVER_SearchTitle = "?d_titl=";

        WebRequest request;
        WebResponse response;
        Stream stream;
        XmlNode firstNode;
        XmlNode secondNode;
        XmlDocument xmlDocument = new XmlDocument();
        XmlNodeList xmlNodeList;

        XmlNode totalNode;

        string url = NAVER_URL + NAVER_SearchTitle + searchWord + NAVER_DISPLAY_STRING + "13" + "&start=1";
        request = (HttpWebRequest) WebRequest.Create(url);

        request.Headers.Add("X-Naver-Client-Id", NAVER_ID);
        request.Headers.Add("X-Naver-Client-Secret", NAVER_SECRET);           //api 접근

        response = (HttpWebResponse)request.GetResponse();

        stream = response.GetResponseStream();

        xmlDocument.Load(stream);

        firstNode = xmlDocument.SelectSingleNode("rss");
        secondNode = firstNode.SelectSingleNode("channel");
        xmlNodeList = secondNode.SelectNodes("item");

        totalNode = secondNode.SelectSingleNode("total");

        if (totalNode.InnerText == "0")
        {
            Console.WriteLine("검색 결과가 없습니다.");
        }
        else
        {
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                Console.WriteLine(xmlNode.SelectSingleNode("title").InnerText);  //책 출력.
            }
        }
        
    }
}