using System;

namespace LAB_2_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza1 = new ItalianPizza();
            Console.WriteLine($"Начальная цена: {pizza1.GetCost()}");
            pizza1 = new TomatoPizza(pizza1); // итальянская пицца с томатами
            Console.WriteLine("Название: {0}", pizza1.Name);
            Console.WriteLine("Цена: {0}", pizza1.GetCost());

            Pizza pizza2 = new ItalianPizza();
            Console.WriteLine($"Начальная цена: {pizza2.GetCost()}");
            pizza2 = new CheesePizza(pizza2);// итальянская пиццы с сыром
            Console.WriteLine("Название: {0}", pizza2.Name);
            Console.WriteLine("Цена: {0}", pizza2.GetCost());

            Pizza pizza3 = new BulgerianPizza();
            Console.WriteLine($"Начальная цена: {pizza3.GetCost()}");
            pizza3 = new TomatoPizza(pizza3);
            pizza3 = new CheesePizza(pizza3);
            pizza3 = new PizzaWithCheesSides(pizza3);// болгарская пиццы с томатами и сыром и бортиками
            Console.WriteLine("Название: {0}", pizza3.Name);
            Console.WriteLine("Цена: {0}", pizza3.GetCost());

            Console.ReadLine();
        }
    }

    abstract class Pizza
    {
        public Pizza(string n)
        {
            this.Name = n;
        }
        public string Name { get; protected set; }
        public abstract int GetCost();
    }

    class ItalianPizza : Pizza
    {
        public ItalianPizza() : base("Итальянская пицца")
        { }
        public override int GetCost()
        {
            return 10;
        }
    }
    class BulgerianPizza : Pizza
    {
        public BulgerianPizza()
            : base("Болгарская пицца")
        { }
        public override int GetCost()
        {
            return 8;
        }
    }
    //Класс декоратора
    abstract class PizzaDecorator : Pizza
    {
        protected Pizza pizza;
        public PizzaDecorator(string n, Pizza pizza) : base(n)
        {
            this.pizza = pizza;
        }
    }

    class TomatoPizza : PizzaDecorator
    {
        public TomatoPizza(Pizza p)
            : base(p.Name + ", с томатами", p)
        { }

        public override int GetCost()
        {
            return pizza.GetCost() + 3;
        }
    }

    class CheesePizza : PizzaDecorator
    {
        public CheesePizza(Pizza p)
            : base(p.Name + ", с сыром", p)
        { }

        public override int GetCost()
        {
            return pizza.GetCost() + 5;
        }
    }
    class PizzaWithCheesSides : PizzaDecorator
    {
        public PizzaWithCheesSides(Pizza p) : base(p.Name + " и сырными бортиками", p)
        { }
        public override int GetCost()
        {
            return pizza.GetCost() + 6;
        }
    }
}