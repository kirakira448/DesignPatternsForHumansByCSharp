namespace Creational
{
    class Prototype
    {
        class Sheep : ICloneable
        {
            public string name { get; set; }
            public string category { get; set; }

            public Sheep(string name, string category = "Mountain Sheep")
            {
                this.name = name;
                this.category = category;
            }

            // 实现浅拷贝
            public object Clone()
            {
                return MemberwiseClone();
            }

            // 实现深拷贝
            public Sheep DeepCopy()
            {
                return new Sheep(name, category);
            }
        }

        public static void DemonstratePrototype()
        {
            Sheep original = new Sheep("Jolly");
            Console.WriteLine($"Original - Name: {original.name}, Category: {original.category}");

            // 使用深拷贝
            Sheep cloned = original.DeepCopy();
            cloned.name = "Dolly"; // 修改克隆对象的属性
            Console.WriteLine($"Cloned - Name: {cloned.name}, Category: {cloned.category}");
            Console.WriteLine($"Original after clone - Name: {original.name}, Category: {original.category}");
        }
    }
}
