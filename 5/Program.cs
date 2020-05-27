using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Xml;
using System.Xml.Linq;

namespace linq_to_xml
{
    //enum Rang
    //{
    //    VideoFilms,
    //    WideFilms,
    //    StereoSound
    //}
    ////class Cinema
    //{
    //    public int cinemaID { get; set; }
    //    public string CinemaName { get; set; }
    //    public int SeatsNum { get; set; }
    //    public int CinemaYear { get; set; }
    //    public Rang CinemaRang { get; set; }

    //    public Cinema()
    //    {

    //    }

    //    public Cinema(int id, string CinemaName, int SeatsNum, int CinemaYear, Rang rang)
    //    {
    //        cinemaID = id;
    //        this.CinemaName = CinemaName;
    //        this.SeatsNum = SeatsNum;
    //        this.CinemaYear = CinemaYear;
    //        CinemaRang = rang;
    //    }
    //    public override string ToString()
    //    {
    //        return CinemaName + "\tSeats amount: " + SeatsNum + "\tYear of open: " + CinemaYear + "\tClass: " + CinemaRang.ToString();
    //    }
    //}
    class Program
    {
        //7)	Розробити структуру даних для зберігання інформації про кінотеатри міста. 
        //  Для кінотеатру зберігається інформація: найменування кінотеатру,
        //  місткість (кількість місць), рік побудови, ранг кінотеатру 
        // (для перегляду відеофільмів, для перегляду широкоформатних фільмів, наявність стереоформатного обладнання, тощо).
       
        static void Main(string[] args)
        {
            string xmlFileName = "cinemas.xml";
            int cinemaId = 0;

            XDocument doc = new XDocument(
                new XElement("Cinemas",
                    new XElement("Cinema",
                        new XAttribute("id", cinemaId++),
                        new XElement("name", "cinemaOne"),
                        new XElement("seatsNum", 200),
                        new XElement("cinemaRang", "WideFilms"),
                        new XElement("cinemaYear", 2001)),
                    new XElement("Cinema",
                        new XAttribute("id", cinemaId++),
                        new XElement("name", "cinemaTwo"),
                        new XElement("seatsNum", 250),
                        new XElement("cinemaRang", "StereoSound"),
                        new XElement("cinemaYear", 2004)),
                    new XElement("Cinema",
                        new XAttribute("id", cinemaId++),
                        new XElement("name", "cinema SAS"),
                        new XElement("seatsNum", 228),
                        new XElement("cinemaRang", "VideoFilms"),
                        new XElement("cinemaYear", 2007)),
                    new XElement("Cinema",
                        new XAttribute("id", cinemaId++),
                        new XElement("name", "cinema shicuchi"),
                        new XElement("seatsNum", 123),
                        new XElement("cinemaRang", "WideFilms"),
                        new XElement("cinemaYear", 2016)),
                    new XElement("Cinema",
                        new XAttribute("id", cinemaId++),
                        new XElement("name", "invoker cinema"),
                        new XElement("seatsNum", 321),
                        new XElement("cinemaRang", "StereoSound"),
                        new XElement("cinemaYear", 2004)),
                    new XElement("Cinema",
                        new XAttribute("id", cinemaId++),
                        new XElement("name", "valve cinema"),
                        new XElement("seatsNum", 421),
                        new XElement("cinemaRang", "StereoSound"),
                        new XElement("cinemaYear", 2019))
                    ));

            doc.Save(xmlFileName);
            XDocument xmlDocument = XDocument.Load("cinemas.xml");

            Console.WriteLine("Data was completly added into xml file!\nAdd one more 'Cinema'");

            string cinemaName, cinemaRang;
            int seatsNum, cinemaYear;

            Console.Write("Enter cinema name: ");
            cinemaName = Console.ReadLine();

            Console.Write("Enter number of seats: ");
            seatsNum = int.Parse(Console.ReadLine());

            Console.Write("Enter cinema year of construction: ");
            cinemaYear = int.Parse(Console.ReadLine());

            Console.Write("Cinema rang: ");
            cinemaRang = Console.ReadLine();
            Console.WriteLine(new string('-', 40));

            XElement consoleCInema = new XElement("Cinema",
                new XAttribute("id", cinemaId++),
                new XElement("name", cinemaName),
                new XElement("seatsNum", seatsNum),
                new XElement("cinemaRang", cinemaRang),
                new XElement("cinemaYear", cinemaYear));

            xmlDocument.Root.Add(consoleCInema);

            //xmlDocument.Save(xmlFileName);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Id\tCinema name\tNumber of seats\tCinema rang\tYear of construction");

            Console.ResetColor();
            foreach (XElement cinema in xmlDocument.Root.Elements())
            {
                Console.Write($"{cinema.Attribute("id").Value}");
                foreach (XElement element in cinema.Elements())
                {
                    Console.Write($"\t{element.Value}");
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 50));

            ////////////////////////////////////////////////////////////////////////////////////////////1
            int maxId = xmlDocument.Root.Elements("Cinema").Max(t => int.Parse(t.Attribute("id").Value));

            XElement newCinema = new XElement("Cinema",
                new XAttribute("id", ++maxId),
                new XElement("name", "cinemaWithMaxId"),
                new XElement("seatsNum", 210),
                new XElement("cinemaRang", "VideoFilms"),
                new XElement("cinemaYear", 2018));

            xmlDocument.Root.Add(newCinema);
            xmlDocument.Save(xmlFileName);

            IEnumerable<XElement> newCinemaToOutput = xmlDocument.Root.Descendants("Cinema").Where(
                x => x.Element("name").Value == "cinemaWithMaxId");

            foreach(XElement a in newCinemaToOutput)
            {
                Console.WriteLine($"Cinema id: {a.Attribute("id").Value}");

                foreach(XElement element in a.Elements())
                {
                    Console.WriteLine($"\t{element.Name}: {element.Value}");
                }
            }

            Console.WriteLine(new string('-',50));

            ///////////////////////////////////////////////////////////////////////////////////////////2

            IEnumerable<XElement> AllCinemasNameCollection = xmlDocument.Root.Descendants("Cinema").Where(
                x => x.Element("name").Value != null);

            foreach(XElement x in AllCinemasNameCollection)
                Console.WriteLine(x.Element("name").Value);
            Console.WriteLine(new string('-', 50));

            ///////////////////////////////////////////////////////////////////////////////////////////3
           
            IEnumerable<XElement> CinemasWithSeatsNumLessThan150 = xmlDocument.Root.Descendants("Cinema").Where(
            x => int.Parse(x.Element("seatsNum").Value) < 150);

            foreach (XElement x in CinemasWithSeatsNumLessThan150)
                Console.WriteLine($"Cinema name: {x.Element("name").Value}" +
                    $"\nSeats num: {x.Element("seatsNum").Value}");

            Console.WriteLine(new string('-', 50));

            ///////////////////////////////////////////////////////////////////////////////////////////4

            IEnumerable<XElement> CinemasWithYearAfter2005 = xmlDocument.Root.Descendants("Cinema").Where(
                x => int.Parse(x.Element("cinemaYear").Value) > 2005);

            foreach (XElement x in CinemasWithYearAfter2005)
                Console.WriteLine($"Cinema name: {x.Element("name").Value}" +
                    $"\nCinema year: {x.Element("cinemaYear").Value}");
            Console.WriteLine(new string('-', 50));

            ///////////////////////////////////////////////////////////////////////////////////////////5

            IEnumerable<XElement> modernCinemas = xmlDocument.Root.Descendants("Cinema").Where(
                x => int.Parse(x.Element("cinemaYear").Value) > 2005);

            foreach (XElement x in CinemasWithYearAfter2005)
                Console.WriteLine($"Cinema name: {x.Element("name").Value}" +
                    $"\nCinema year: {x.Element("cinemaYear").Value}");
            Console.WriteLine(new string('-', 50));

            ///////////////////////////////////////////////////////////////////////////////////////////6
            
            var sortedCinemas = xmlDocument.Root.Descendants("Cinema").OrderByDescending(
                x => int.Parse(x.Element("seatsNum").Value)).Select(x => new
                {
                    Name = x.Element("name").Value,
                    SeatsNum = x.Element("seatsNum").Value,
                }).Take(4);

            foreach (var x in sortedCinemas)
                Console.WriteLine($"Cinema name: {x.Name}" +
                    $"\nSeats num: {x.SeatsNum}");
            
            Console.WriteLine(new string('-', 50));
            ///////////////////////////////////////////////////////////////////////////////////////////7

            var joinedCollections = from x in xmlDocument.Root.Descendants("Cinema")
                                    join y in sortedCinemas
                                    on x.Element("name").Value equals y.Name
                                    orderby x.Element("seatsNum").Value
                                    select new 
                                    {
                                        name = x.Element("name").Value,
                                        seatsnum = y.SeatsNum
                                    };


            foreach (var a in joinedCollections)
                Console.WriteLine($"{a.name}\nseats num: {a.seatsnum}");

            Console.WriteLine(new string('-', 50));

            ///////////////////////////////////////////////////////////////////////////////////////////8

            var anotherCollection = from x in xmlDocument.Root.Descendants("Cinema")
                                    where x.Element("cinemaRang").Value == "stereoSound" &&
                                    int.Parse(x.Element("cinemaYear").Value) > 2003
                                    select new
                                    {
                                        name = x.Element("name").Value,
                                        cinemaYear = x.Element("cinemaYear").Value,
                                    };

            foreach (var a in anotherCollection)
            {
                Console.WriteLine($"{a.name}\nYear of construction: {a.cinemaYear}");
            }



            Console.ReadLine();
        }
    }
}
