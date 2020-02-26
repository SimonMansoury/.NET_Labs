using System;
using System.Collections.Generic;
using System.Text;

namespace CS_Lab_3
{
	interface IPostable
	{
		void AddSubscriber(ConcreteSubscriber o);
		void RemoveSubscriber(ConcreteSubscriber ob);
		void NotifySubscribers(int NumOfIncomingBooks);
	}

	class ConcretePostOffice : IPostable
	{
		List<ConcreteSubscriber> subscribers;
		
		public ConcretePostOffice()
		{
			subscribers = new List<ConcreteSubscriber>();
		}
		public void AddSubscriber(ConcreteSubscriber ob)
		{
			subscribers.Add(ob);
		}

		public void RemoveSubscriber(ConcreteSubscriber ob)
		{
			subscribers.Remove(ob);
		}

		public void NotifySubscribers(int NumOfIncomingBooks)
		{
			if (subscribers.Count == 0)
				throw new Exception("There`s no subscribers!");

			foreach(var sub in subscribers)
				Console.WriteLine($"Subscriber {sub.SubscriberName} gets a message, that we have {NumOfIncomingBooks} new Books!");
		}

	}

	interface ISubscriber
	{
		public void Update(object o);
	}
	class ConcreteSubscriber : ISubscriber
	{
		public ConcreteSubscriber() : this("No Name") { }
		public ConcreteSubscriber(string Name)
		{
			SubscriberName = Name;
		}
		public string SubscriberName { get; private set; }

		public void Update(object o)
		{

		}
	}
}
