using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational
{
    class SimpleFactory
    {
        interface IDoor
        {
            double GetWidth();
            double GetHeight();
        }

        class WoodenDoor : IDoor
        {
            private double width;
            private double height;
            public WoodenDoor(double width, double height)
            {
                this.width = width;
                this.height = height;
            }
            public double GetWidth()
            {
                return width;
            }
            public double GetHeight()
            {
                return height;
            }
        }

        class DoorFactory
        {
            public static IDoor MakeDoor(double width, double height)
            {
                return new WoodenDoor(width, height);
            }
        }

        public static void DemonstrateSimpleFactory()
        {
            Console.WriteLine("简单工厂模式演示开始：\n");
            Console.WriteLine("创建木门1：DoorFactory.MakeDoor(100, 200)");
            var door = DoorFactory.MakeDoor(100, 200);
            Console.WriteLine($"Width: {door.GetWidth()}");
            Console.WriteLine($"Height: {door.GetHeight()}");

            Console.WriteLine("创建木门2：DoorFactory.MakeDoor(50, 100)");
            var door2 = DoorFactory.MakeDoor(50, 100);
            Console.WriteLine($"Width: {door2.GetWidth()}");
            Console.WriteLine($"Height: {door2.GetHeight()}");
        }
    }
}
