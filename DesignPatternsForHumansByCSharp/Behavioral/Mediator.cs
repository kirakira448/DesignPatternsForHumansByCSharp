namespace Behavioral
{
    public class Mediator
    {
        interface IChatRoomMediator 
        {
            void ShowMessage(User user,string message);
        }

        class ChatRoom : IChatRoomMediator
        {
            public void ShowMessage(User user,string message)
            {
                DateTime now = DateTime.Now;
                string sender = user.GetName();
                Console.WriteLine($"{now:yyyy-MM-dd HH:mm:ss} [{sender}]: {message}");
            }
        }
        
        class User
        {
            private string name;
            private IChatRoomMediator mediator;
            public User(string name, IChatRoomMediator mediator)
            {
                this.name = name;
                this.mediator = mediator;
            }

            public string GetName()
            {
                return name;
            }

            public void SendMessage(string message)
            {
                mediator.ShowMessage(this, message);
            }
        }

        public static void DemonstrateMediator()
        {
            ChatRoom chatRoom = new ChatRoom();
            User user1 = new User("John", chatRoom);
            User user2 = new User("Jane", chatRoom);
            user1.SendMessage("Hello, how are you?");
            user2.SendMessage("I'm fine, thank you!");
        }
    }
}
