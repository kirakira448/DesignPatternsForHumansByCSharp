namespace Creational
{
    class AbstractFactory
    {
        interface IDoor
        {
            public void GetDescription();
        }

        class WoodenDoor : IDoor
        {
            public void GetDescription()
            {
                Console.WriteLine("I am a wooden door");
            }
        }

        class IronDoor : IDoor
        {
            public void GetDescription()
            {
                Console.WriteLine("I am an iron door");
            }
        }


        interface IDoorFittingExpert
        {
            public void GetDescription();
        }

        class Welder : IDoorFittingExpert
        {
            public void GetDescription()
            {
                Console.WriteLine("I can only fit iron doors");
            }
        }

        class Carpenter : IDoorFittingExpert
        {
            public void GetDescription()
            {
                Console.WriteLine("I can only fit wooden doors");
            }
        }


        abstract class DoorFactory
        {
            public abstract IDoor MakeDoor();
            public abstract IDoorFittingExpert MakeFittingExpert();
        }


        class WoodenDoorFactory : DoorFactory
        {
            public override IDoor MakeDoor()
            {
                return new WoodenDoor();
            }

            public override IDoorFittingExpert MakeFittingExpert()
            {
                return new Carpenter();
            }
        }

        class IronDoorFactory : DoorFactory
        {
            public override IDoor MakeDoor()
            {
                return new IronDoor();
            }

            public override IDoorFittingExpert MakeFittingExpert()
            {
                return new Welder();
            }
        }

        public static void DemonstrateAbstractFactory()
        {
            Console.WriteLine("Abstract Factory Pattern Demonstration:");

            Console.WriteLine("\nCreating Wooden Door Factory:");
            var woodenDoorFactory = new WoodenDoorFactory();
            var woodenDoor = woodenDoorFactory.MakeDoor();
            var woodenExpert = woodenDoorFactory.MakeFittingExpert();

            woodenDoor.GetDescription();
            woodenExpert.GetDescription();

            Console.WriteLine("\nCreating Iron Door Factory:");
            var ironDoorFactory = new IronDoorFactory();
            var ironDoor = ironDoorFactory.MakeDoor();
            var ironExpert = ironDoorFactory.MakeFittingExpert();

            ironDoor.GetDescription();
            ironExpert.GetDescription();
        }
    }
}
