namespace Creational
{
    class Builder
    {
        class Burger
        {
            private int size;
            private bool pepperoni=false;
            private bool cheese=false;
            private bool lettuce=false;
            private bool tomato=false;

            public Burger(BurgerBuilder builder)
            {
                size = builder.size;
                pepperoni = builder.pepperoni;
                cheese = builder.cheese;
                lettuce = builder.lettuce;
                tomato = builder.tomato;
            }

            public override string ToString()
            {
                return $"Burger(size: {size}, pepperoni: {pepperoni}, cheese: {cheese}, lettuce: {lettuce}, tomato: {tomato})";
            }
        }

        class BurgerBuilder
        {
            public int size;
            public bool pepperoni;
            public bool cheese;
            public bool lettuce;
            public bool tomato;

            public BurgerBuilder(int size)
            {
                this.size = size;
            }

            public BurgerBuilder AddPepperoni()
            {
                pepperoni = true;
                return this;
            }

            public BurgerBuilder AddCheese()
            {
                cheese = true;
                return this;
            }

            public BurgerBuilder AddLettuce()
            {
                lettuce = true;
                return this;
            }

            public BurgerBuilder AddTomato()
            {
                tomato = true;
                return this;
            }

            public Burger Build()
            {
                return new Burger(this);
            }

        }
        public static void DemonstrateBuilder()
        {
            var burger = new BurgerBuilder(14).AddPepperoni().AddLettuce().AddTomato().Build();
            Console.WriteLine(burger);
        }

    }
}
