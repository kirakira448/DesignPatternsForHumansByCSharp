namespace Structural
{
    class Decorator
    {
        interface ICoffee
        {
            string GetDescription();
            double GetCost();   
        }

        class SimpleCoffee : ICoffee
        {
            public string GetDescription()
            {
                return "Simple Coffee";
            }

            public double GetCost()
            {
                return 5.0;
            }
        }

        class MilkCoffee : ICoffee
        {
            private ICoffee coffee;

            public MilkCoffee(ICoffee coffee)
            {
                this.coffee = coffee;
            }

            public string GetDescription()
            {
                return coffee.GetDescription() + ", Milk";
            }

            public double GetCost()
            {
                return coffee.GetCost() + 1.0;
            }
        }

        class SugarCoffee : ICoffee
        {
            private ICoffee coffee;

            public SugarCoffee(ICoffee coffee)
            {
                this.coffee = coffee;
            }

            public string GetDescription()
            {
                return coffee.GetDescription() + ", Sugar";
            }

            public double GetCost() 
            {
                return coffee.GetCost() + 0.5;
            }
        }

        public static void DemonstrateDecorator()
        {
            ICoffee coffee = new SimpleCoffee();
            Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost()}");

            coffee = new MilkCoffee(coffee);
            Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost()}");

            coffee = new SugarCoffee(coffee);
            Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost()}");
        }
        
    }
}
