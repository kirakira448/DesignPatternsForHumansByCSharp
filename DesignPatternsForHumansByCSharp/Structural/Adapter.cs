namespace Structural
{
    class Adapter
    {
        public interface ILion
        {
            void Roar();
        }

        public class AfricanLion : ILion
        {
            public void Roar()
            {
                Console.WriteLine("AfricanLion Roar");
            }
        }

        public class AsianLion : ILion
        {
            public void Roar()
            {
                Console.WriteLine("AsianLion Roar");
            }
        }


        public class Hunter
        {
            public void Hunt(ILion lion)
            {
                lion.Roar();
            }
        }


        public class WildDog
        {
            public void Bark()
            {
                Console.WriteLine("WildDog Bark");
            }
        }

        public class WildDogAdapter : ILion
        {
            private WildDog _wildDog;
            public WildDogAdapter(WildDog wildDog)
            {
                _wildDog = wildDog;
            }
            public void Roar()
            {
                _wildDog.Bark();
            }
        }


        public static void DemonstrateAdapter()
        {
            Console.WriteLine("开始演示适配器模式：\n");
            Hunter hunter = new Hunter();
            // 猎人猎杀非洲狮
            Console.WriteLine("猎人猎杀非洲狮：");
            ILion lion = new AfricanLion();
            hunter.Hunt(lion);

            // 猎人猎杀亚洲狮
            Console.WriteLine("猎人猎杀亚洲狮：");
            ILion asianLion = new AsianLion();
            hunter.Hunt(asianLion);

            // 猎人猎杀野狗
            Console.WriteLine("猎人猎杀野狗：");
            ILion wildDog = new WildDogAdapter(new WildDog());
            hunter.Hunt(wildDog);

        }
        
    }
}
