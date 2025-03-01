namespace Behavioral
{
    public class Command
    {
        class Bulb
        {
            public void TurnOn()
            {
                Console.WriteLine("Bulb has been lit");
            }

            public void TurnOff()
            {
                Console.WriteLine("Bulb has been turned off");
            }
        }

        interface ICommand
        {
            void Execute();
            void Undo();
            void Redo();
        }

        // Command 
        class TurnOn : ICommand
        {
            private Bulb bulb;

            public TurnOn(Bulb bulb)
            {
                this.bulb = bulb;
            }

            public void Execute()
            {
                bulb.TurnOn();
            }

            public void Undo()
            {
                bulb.TurnOff();
            }

            public void Redo()
            {
                Execute();
            }
        }

        class TurnOff : ICommand
        {
            private Bulb bulb;

            public TurnOff(Bulb bulb)
            {
                this.bulb = bulb;
            }

            public void Execute()
            {
                bulb.TurnOff();
            }

            public void Undo()
            {
                bulb.TurnOn();
            }

            public void Redo()  
            {
                Execute();
            }
        }

        // Invoker
        class RemoteControl
        {
            public void Submit(ICommand command)
            {
                command.Execute();
            }
        }

        public static void DemonstrateCommand()
        {
            var bulb = new Bulb();
            ICommand turnOn = new TurnOn(bulb);
            ICommand turnOff = new TurnOff(bulb);

            var remoteControl = new RemoteControl();
            Console.WriteLine("Turning on the bulb");
            remoteControl.Submit(turnOn);
            Console.WriteLine("Turning off the bulb");
            remoteControl.Submit(turnOff);
        }
        
        
    }
}
