namespace Behavioral
{
    public class Visitor
    {
        // Visitee
        interface IAnimal
        {
            void Accept(IAnimalOperation operation);
        }

        // Visitor
        interface IAnimalOperation
        {
            void visitMonkey(Monkey monkey);
            void visitLion(Lion lion);
            void visitDolphin(Dolphin dolphin);
        }
        
        class Monkey : IAnimal
        {
            public void Shout()
            {
                Console.WriteLine("Ooh ooh aah aah!");
            }

            public void Accept(IAnimalOperation operation)
            {
                operation.visitMonkey(this);
            }
        }

        class Lion : IAnimal
        {
            public void Shout()
            {
                Console.WriteLine("Roar!");
            }

            public void Accept(IAnimalOperation operation)
            {
                operation.visitLion(this);
            }
        }

        class Dolphin : IAnimal
        {
            public void Shout()
            {
                Console.WriteLine("Tuut tuttu tuutt!");
            }

            public void Accept(IAnimalOperation operation)
            {
                operation.visitDolphin(this);
            }
        }

        class Speak : IAnimalOperation
        {
            public void visitMonkey(Monkey monkey)
            {
                monkey.Shout();
            }

            public void visitLion(Lion lion)
            {
                lion.Shout();
            }

            public void visitDolphin(Dolphin dolphin)
            {
                dolphin.Shout();
            }
        }

        class Jump : IAnimalOperation
        {
            public void visitMonkey(Monkey monkey)
            {
                Console.WriteLine("Jumped 20 feet high! on to the tree!");
            }

            public void visitLion(Lion lion)
            {
                Console.WriteLine("Jumped 7 feet! Back on the ground!");
            }

            public void visitDolphin(Dolphin dolphin)
            {
                Console.WriteLine("Walked on water a little and disappeared");
            }
        }

        public static void DemonstrateVisitor()
        {
            List<IAnimal> animals = new List<IAnimal>
            {
                new Monkey(),
                new Lion(),
                new Dolphin()
            };

            var speak = new Speak();
            foreach (var animal in animals)
            {
                animal.Accept(speak);
            }

            var jump = new Jump();
            foreach (var animal in animals)
            {
                animal.Accept(jump);
            }
        }
    }
}
