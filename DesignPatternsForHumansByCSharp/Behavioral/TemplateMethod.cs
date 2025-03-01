namespace Behavioral
{
    public class TemplateMethod
    {
        abstract class Builder
        {
            // Template method
            public void Build()
            {
                this.Test();
                this.Lint();
                this.Assemble();
                this.Deploy();
            }

            protected abstract void Test();
            protected abstract void Lint();
            protected abstract void Assemble();
            protected abstract void Deploy();
        }

        class AndroidBuilder : Builder
        {
            protected override void Test()
            {
                Console.WriteLine("Testing Android");
            }

            protected override void Lint()
            {
                Console.WriteLine("Linting Android");
            }

            protected override void Assemble()
            {
                Console.WriteLine("Assembling Android");
            }

            protected override void Deploy()
            {
                Console.WriteLine("Deploying Android");
            }
        }

        class IosBuilder : Builder
        {
            protected override void Test()
            {
                Console.WriteLine("Testing iOS");
            }

            protected override void Lint()
            {
                Console.WriteLine("Linting iOS");
            }

            protected override void Assemble()
            {
                Console.WriteLine("Assembling iOS");
            }

            protected override void Deploy()
            {
                Console.WriteLine("Deploying iOS");
            }
        }   

        public static void DemonstrateTemplateMethod()
        {
            var androidBuilder = new AndroidBuilder();
            androidBuilder.Build();

            var iosBuilder = new IosBuilder();
            iosBuilder.Build();
        }
    }
}
