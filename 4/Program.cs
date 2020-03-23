using System;
using System.Linq;

namespace _4Lab
{
    class Program
    {
        class Header
        {
            static private int Counter = 0;
            static public void Write(string a)
            {
                Counter++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t{Counter}. " + a + " =>");
                Console.ResetColor();
            }
        }

        static void Main(string[] args)
        {
            Cinema[] Cinemas = { new Cinema("Disneyland", 300, 2010, Rang.StereoSound),
             new Cinema("Butterfly", 200, 2007, Rang.VideoFilms),
             new Cinema("Blokbaster", 100, 2015, Rang.WideFilms),
             new Cinema("Super Cinema", 350, 2019, Rang.StereoSound),
             new Cinema("Ultravibe", 50, 2000, Rang.VideoFilms)};

            Header.Write("Whole cinema list");
            var WholeCinemaList = from x in Cinemas select x;
            foreach (var a in WholeCinemaList)
                Console.WriteLine(a);
            Console.WriteLine(new string('~', 90));

            Header.Write("Reverse list");
            var ReverseList = Cinemas.Reverse();
            foreach (var a in ReverseList)
                Console.WriteLine(a);
            Console.WriteLine(new string('~', 90));

            Header.Write("Alphabetical sort");
            var AlphabeticalSortedList = Cinemas.OrderBy(x => x.CinemaName);
            foreach (var a in AlphabeticalSortedList)
                Console.WriteLine(a);
            Console.WriteLine(new string('~', 90));

            Header.Write("Cinemas with seats amount bigger than or equals 200");
            var CinemasWithSeatsBiggerThan200 = from x in Cinemas where x.SeatsNum >= 200 select x;
            foreach (var a in CinemasWithSeatsBiggerThan200)
                Console.WriteLine(a);
            Console.WriteLine(new string('~', 90));

            Header.Write("Cinemas which name has 2 words");
            var CinemasWhithTwoWordsName = from x in Cinemas where x.CinemaName.Contains(" ") select x;
            foreach (var a in CinemasWhithTwoWordsName)
                Console.WriteLine(a);
            Console.WriteLine(new string('~', 90));

            Header.Write("Cinemas year of building over or equals than 2010");
            var CinemaNewerThan2010 = from x in Cinemas where x.CinemaYear >= 2010 select x;
            foreach (var a in CinemaNewerThan2010)
                Console.WriteLine(a);
            Console.WriteLine(new string('~', 90));

            Header.Write("Only rangs(Typeof Rang) NE RABOTAET");
            var OnlyRangs = from x in Cinemas.OfType<Rang>() select x;
            Console.WriteLine(OnlyRangs.Count());
            foreach (var a in OnlyRangs)
                Console.WriteLine(a.ToString());
            Console.WriteLine(new string('~', 90));

            Header.Write("Minimal seats number");
            var MinSeatsNum = (from x in Cinemas select x.SeatsNum).Min();
            Console.WriteLine(MinSeatsNum);
            Console.WriteLine(new string('~', 90));

            Header.Write("Order by name lenght");
            var CinemaNameLength = Cinemas.OrderBy(s => s.CinemaName.Length);
            foreach (var a in CinemaNameLength)
                Console.WriteLine(a);
            Console.WriteLine(new string('~', 90));

            Header.Write("Order by year");
            var CinemaYear = Cinemas.OrderBy(s => s.CinemaYear);
            foreach (var a in CinemaYear)
                Console.WriteLine(a);
            Console.WriteLine(new string('~', 90));

            Header.Write("Take first 2 cinemas");
            var OnlyTwoFirst = Cinemas.Take(2);
            foreach (var a in OnlyTwoFirst)
                Console.WriteLine(a);
            Console.WriteLine(new string('~', 90));

            Header.Write("Take two Cinemas after three cinemas");
            var TakeTwoAfterThreeCinemas = Cinemas.Skip(2).Take(3);
            foreach (var a in TakeTwoAfterThreeCinemas)
                Console.WriteLine(a);
            Console.WriteLine(new string('~', 90));

            Header.Write("Intersect of two collections");
            var IntersectOfTwoCollections = CinemaNewerThan2010.Intersect(CinemasWithSeatsBiggerThan200);
            foreach (var a in IntersectOfTwoCollections)
                Console.WriteLine(a);
            Console.WriteLine(new string('~', 90));

            Header.Write("Join two collections by name");
            var JoinTwoCollections = from x in IntersectOfTwoCollections
                                     join y in TakeTwoAfterThreeCinemas
                                     on x.CinemaName equals y.CinemaName
                                     select new { Name = x.CinemaName };
            foreach (var a in JoinTwoCollections)
                Console.WriteLine(a.Name);
            Console.WriteLine(new string('~', 90));

            Header.Write("Take cinemas while seats amount less than 300(or equals)");
            var TakeWhileSeatsNumLessThan300 = Cinemas.TakeWhile(x => x.SeatsNum <= 300);
            foreach (var a in TakeWhileSeatsNumLessThan300)
                Console.WriteLine(a);
            Console.WriteLine(new string('~', 90));

            Console.ReadLine();
        }
    }
}
