namespace Structural
{
    class Facade
    {
        class Computer
        {
            public void getElectricShock()
            {
                Console.WriteLine("Ouch!");
            }

            public void makeSound()
            {
                Console.WriteLine("Beep beep!");
            }

            public void showLoadingScreen()
            {
                Console.WriteLine("Loading...");
            }

            public void bam()
            {
                Console.WriteLine("Ready to be used!");
            }

            public void closeEverything()
            {
                Console.WriteLine("Bup bup bup buzzzz!");
            }

            public void sooth()
            {
                Console.WriteLine("Zzzzz");
            }

            public void pullCurrent()
            {
                Console.WriteLine("Haaah!");
            }
            
        }

        class ComputerFacade
        {
            private Computer computer;

            public ComputerFacade(Computer computer)
            {
                this.computer = computer;
            }

            public void turnOn()
            {
                computer.getElectricShock();
                computer.makeSound();
                computer.showLoadingScreen();
                computer.bam();
            }

            public void turnOff()
            {
                computer.closeEverything();
                computer.pullCurrent();
                computer.sooth();
            }
        }

        public static void DemonstrateFacade()
        {
            Computer computer = new Computer();
            ComputerFacade computerFacade = new ComputerFacade(computer);
            Console.WriteLine("Start computer...");
            computerFacade.turnOn();
            Console.WriteLine("... and now, off.");
            computerFacade.turnOff();
        }
        
    }
}
