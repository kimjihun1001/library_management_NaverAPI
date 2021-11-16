using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

class NaverAPI
{
    public void NaverSearchBook()
    {
        const string NAVER_DISPLAY_STRING = "&display=";
        const string NAVER_ID = "xQKhYDcaW4DZ5JNHdmXJ";
        const string NAVER_SECRET = "869iq_F6ep";
        const string NAVER_URL = "https://openapi.naver.com/v1/search/book_adv.xml?d_titl=";

        WebRequest request;
        WebResponse response;
        Stream stream;
        XmlNode firstNode;
        XmlNode secondNode;
        XmlDocument xmlDocument = new XmlDocument();
        XmlNodeList xmlNodeList;

        string url = NAVER_URL + "지식" + NAVER_DISPLAY_STRING + "10" + "&start=6";
        request = (HttpWebRequest) WebRequest.Create(url);

        request.Headers.Add("X-Naver-Client-Id", NAVER_ID);
        request.Headers.Add("X-Naver-Client-Secret", NAVER_SECRET);           //api 접근

        response = request.GetResponse();
        stream = response.GetResponseStream();

        xmlDocument.Load(stream);

        firstNode = xmlDocument.SelectSingleNode("rss");
        secondNode = firstNode.SelectSingleNode("channel");

        xmlNodeList = secondNode.SelectNodes("item");

        foreach (XmlNode xmlNode in xmlNodeList)
        {
            Console.WriteLine(xmlNode.SelectSingleNode("title").InnerText);  //책 출력.
        }
    }
}