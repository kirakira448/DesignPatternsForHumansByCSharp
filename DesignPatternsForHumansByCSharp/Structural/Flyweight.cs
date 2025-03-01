namespace Structural
{
    class Flyweight
    {
        // 具体享元类：表示一种特定类型的茶
        class KarakTea
        {
            public string TeaType { get; set; }

            public KarakTea(string teaType)
            {
                TeaType = teaType;
            }
        }

        // 享元工厂：负责创建和管理享元对象
        class TeaMaker
        {
            private Dictionary<string, KarakTea> availableTea = new Dictionary<string, KarakTea>();

            public KarakTea Make(string preference)
            {
                if (!availableTea.ContainsKey(preference))
                {
                    availableTea[preference] = new KarakTea(preference);
                }
                return availableTea[preference];
            }

            public int GetTotalTeaMade()
            {
                return availableTea.Count;
            }
        }

        // 上下文：茶店订单
        class TeaShop
        {
            private Dictionary<int, KarakTea> orders = new Dictionary<int, KarakTea>();
            private TeaMaker teaMaker;

            public TeaShop(TeaMaker teaMaker)
            {
                this.teaMaker = teaMaker;
            }

            public void TakeOrder(string teaType, int table)
            {
                orders[table] = teaMaker.Make(teaType);
            }

            public void Serve()
            {
                foreach (var order in orders)
                {
                    Console.WriteLine($"Serving tea {order.Value.TeaType} to table {order.Key}");
                }
            }
        }

        public static void DemonstrateFlyweight()
        {
            TeaMaker teaMaker = new TeaMaker();
            TeaShop shop = new TeaShop(teaMaker);

            shop.TakeOrder("红茶", 1);
            shop.TakeOrder("绿茶", 2);
            shop.TakeOrder("红茶", 3);
            shop.TakeOrder("乌龙茶", 4);
            shop.TakeOrder("绿茶", 5);

            shop.Serve();
            Console.WriteLine($"\n实际创建的茶对象数量: {teaMaker.GetTotalTeaMade()}");
        }
    }
}
