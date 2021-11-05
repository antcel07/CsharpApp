using System;

namespace exams4
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza1 = new ItalianPizza();
            pizza1 = new TomatoPizza(pizza1); 
            Console.WriteLine("Name: {0}", pizza1.Name);
            Console.WriteLine("Price: {0}", pizza1.GetCost());

            Pizza pizza2 = new ItalianPizza();
            pizza2 = new CheesePizza(pizza2);
            Console.WriteLine("Name: {0}", pizza2.Name);
            Console.WriteLine("Price: {0}", pizza2.GetCost());

            Pizza pizza3 = new MexicoPizza();
            pizza3 = new TomatoPizza(pizza3);
            pizza3 = new CheesePizza(pizza3);
            Console.WriteLine("Name: {0}", pizza3.Name);
            Console.WriteLine("Price: {0}", pizza3.GetCost());


            Pizza pizza4 = new MexicoPizza();
            pizza4 = new SosigesPizza(pizza4);
            Console.WriteLine("Name: {0}", pizza4.Name);
            Console.WriteLine("Price: {0}", pizza4.GetCost());


            Console.ReadLine();
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
            public ItalianPizza() : base("Italian pizza")
            { }
            public override int GetCost()
            {
                return 10;
            }
        }
        class MexicoPizza : Pizza
        {
            public MexicoPizza(): base("Mexico pizza")
            { }
            public override int GetCost()
            {
                return 8;
            }
        }

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
                : base(p.Name + " --> Tomato ", p)
            { }

            public override int GetCost()
            {
                return pizza.GetCost() + 3;
            }
        }

        class CheesePizza : PizzaDecorator
        {
            public CheesePizza(Pizza p)
                : base(p.Name + " --> Cheese", p)
            { }

            public override int GetCost()
            {
                return pizza.GetCost() + 5;
            }
        }
        class SosigesPizza : PizzaDecorator
        {
            public SosigesPizza(Pizza p)
                : base(p.Name + " --> Sosiges", p)
            { }

            public override int GetCost()
            {
                return pizza.GetCost() + 10;
            }
        }
    }
   }

