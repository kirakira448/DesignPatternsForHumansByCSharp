namespace Structural
{
    class Proxy
    {
        interface IDoor
        {
            void Open();
            void Close();
        }

        class LabDoor : IDoor
        {
            public void Open()
            {
                Console.WriteLine("Opening LabDoor");
            }

            public void Close()
            {
                Console.WriteLine("Closing LabDoor");
            }
        }

        class SecuredDoor : IDoor
        {
            private IDoor door;

            public SecuredDoor (IDoor door)
            {
                this.door = door;
            }

            public bool Authenticate(string password)
            {
                Console.WriteLine("Authenticating...");
                return password == "secret";
            }

            public void Open()
            {
                Console.WriteLine("Access Denied! Need password.");
            }

            public void Open(string password)
            {
                if (Authenticate(password))
                {
                    door.Open();
                }
                else
                {
                    Console.WriteLine("Access Denied!");
                }
            }

            public void Close()
            {
                door.Close();
            }
        }

        public static void DemonstrateProxy()
        {
            SecuredDoor door = new SecuredDoor(new LabDoor());
            door.Open();
            door.Open("secret");
            door.Close();
        }
    }
}