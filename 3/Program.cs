using System;

namespace CS_Lab_3
{
    class Program
    {
        /*
           7)	Розробити систему Поштове відділення. 
           З видавництва в поштове відділення надходять газети і журнали. 
           відділення відправляє отримані друковані видання відповідним передплатникам.
         */
        static void Main(string[] args)
        {
            ConcretePostOffice PostOffice = new ConcretePostOffice();

            ConcreteSubscriber subscriber = new ConcreteSubscriber("Anatoliy");
            PostOffice.AddSubscriber(subscriber);

            ConcreteSubscriber subscriber1 = new ConcreteSubscriber("Ivanna");
            PostOffice.AddSubscriber(subscriber1);

            ConcreteSubscriber subscriber2 = new ConcreteSubscriber("Vasiliy");
            PostOffice.AddSubscriber(subscriber2);

            Random rand = new Random();
            try
            {
                PostOffice.NotifySubscribers(rand.Next(1, 100));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
