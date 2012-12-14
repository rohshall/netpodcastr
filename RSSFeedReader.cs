using System;
using System.IO;
using System.Collections;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Net;

namespace RSSFeedParser
{
    class Podcast
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }

        public void Download()
        {
            System.Console.WriteLine("Downloading " + Title);
            string filename = Link.Substring(Link.LastIndexOf('/') + 1);
            using(WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(Link, filename);
            }
        }
    }

    class Program
    {
        static void ParseFeed(string feedUrl)
        {
            XDocument doc = XDocument.Load(feedUrl);

            var feeds = from feed in doc.Descendants("item")
                select new Podcast()
                {
                    Title = (string)feed.Element("title"),
                    Link = (string)feed.Element("link"),
                    Date = (string)feed.Element("pubdate"),
                    Description = (string)feed.Element("description")
                };
            foreach(var feed in feeds)
            {
                feed.Download();
            }
        }
        static void Main(string[] args)
        {
            string line;
            using(StreamReader reader = new StreamReader("feeds.txt"))
            {
                line = reader.ReadLine();
                ParseFeed(line);
            }
        }
    }
}
