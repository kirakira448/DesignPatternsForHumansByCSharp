namespace Creational
{
    class Singleton
    {

        public class SingletonDemo
        {
            // 私有静态实例
            private static SingletonDemo? instance;
            // 私有静态锁对象
            private static readonly object lockObject = new object();
            // 私有计数器
            private int counter = 0;
            // 私有构造函数
            private SingletonDemo()
            {
                Console.WriteLine("SingletonDemo 被创建了！");
            }
            // 公共静态实例
            public static SingletonDemo Instance
            {
                get
                {
                    // 如果实例为空，则创建实例
                    if (instance == null)
                    {
                        // 加锁
                        lock (lockObject)
                        {
                            // 如果实例为空，则创建实例
                            if (instance == null)
                            {
                                instance = new SingletonDemo();
                            }
                        }
                    }
                    return instance;
                }
            }
            public void DoSomething()
            {
                counter++;
                Console.WriteLine($"SingletonDemo 执行了 {counter} 次");
            }
        }

        public static void DemonstrateSingleton()
        {
            Console.WriteLine("开始演示单例模式：\n");
            SingletonDemo singleton1 = SingletonDemo.Instance;
            singleton1.DoSomething();

            Console.WriteLine("\n尝试获取第二个实例：");
            SingletonDemo singleton2 = SingletonDemo.Instance;
            singleton2.DoSomething();

            Console.WriteLine("\n尝试获取第三个实例：");
            SingletonDemo singleton3 = SingletonDemo.Instance;
            singleton3.DoSomething();

            // 验证两个实例是否相同
            Console.WriteLine($"\n两个实例是否是同一个对象：{ReferenceEquals(singleton1, singleton2)}");
            
            
        }
    }
}
