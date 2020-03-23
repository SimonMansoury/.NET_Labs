using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Lab
{
    enum Rang
    {
       VideoFilms,
       WideFilms,
       StereoSound
    }

    class Cinema
    {
        /*7)	Розробити структуру даних для зберігання інформації про кінотеатри міста.
             * Для кінотеатру зберігається інформація: найменування кінотеатру, місткість (кількість місць),
             * рік побудови, ранг кінотеатру (для перегляду відеофільмів, для перегляду широкоформатних фільмів,
             * наявність стереоформатного обладнання, тощо).
        */
        public string CinemaName { get; set; }
        public int SeatsNum { get; set; }
        public int CinemaYear { get; set; }
        public Rang CinemaRang { get; set; }

        public Cinema()
        { }

        public Cinema(string CinemaName, int SeatsNum, int CinemaYear, Rang rang)
        {
            this.CinemaName = CinemaName;
            this.SeatsNum = SeatsNum;
            this.CinemaYear = CinemaYear;
            CinemaRang = rang;
        }
        public override string ToString()
        {
            return CinemaName + "\tSeats amount: " + SeatsNum + "\tYear of open: " + CinemaYear + "\tClass: " + CinemaRang.ToString();
        }
    }
}
