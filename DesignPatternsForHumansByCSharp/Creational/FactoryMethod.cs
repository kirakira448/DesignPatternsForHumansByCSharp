namespace Creational
{
    class FactoryMethod
    {
        interface IInterviewer
        {
            void AskQuestions();
        }

        class Developer : IInterviewer
        {
            public void AskQuestions()
            {
                Console.WriteLine("Asking about design patterns!");
            }
        }

        class CommunityExecutive : IInterviewer
        {
            public void AskQuestions()
            {
                Console.WriteLine("Asking about community building!");
            }
        }

        abstract class HiringManager
        {
            abstract protected IInterviewer MakeInterviewer();
            public void TakeInterview()
            {
                var interviewer = MakeInterviewer();
                interviewer.AskQuestions();
            }
        }

        class DevelopmentManager : HiringManager
        {
            protected override IInterviewer MakeInterviewer()
            {
                return new Developer();
            }
        }

        class MarketingManager : HiringManager
        {
            protected override IInterviewer MakeInterviewer()
            {
                return new CommunityExecutive();
            }
        }

        public static void DemonstrateFactoryMethod()
        {
            Console.WriteLine("工厂方法模式演示开始：\n");

            Console.WriteLine("创建开发经理：");
            var devManager = new DevelopmentManager();
            Console.WriteLine("开发经理进行面试：");
            devManager.TakeInterview();

            Console.WriteLine("\n创建市场经理：");
            var marketingManager = new MarketingManager();
            Console.WriteLine("市场经理进行面试：");
            marketingManager.TakeInterview();
        }
    }
}
