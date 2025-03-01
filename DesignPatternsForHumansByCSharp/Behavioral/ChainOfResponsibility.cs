namespace Behavioral
{
    public class ChainOfResponsibility
    {
        abstract class Account
        {
            protected Account? successor;
            protected double balance;

            public void SetNext(Account successor)
            {
                this.successor = successor;
            }

            public void Pay(double amountToPay)
            {
                if (CanPay(amountToPay))
                {
                    Console.WriteLine($"Paid {amountToPay} using {GetType().Name}");
                }
                else if (successor != null)
                {
                    Console.WriteLine($"Cannot pay using {GetType().Name}. Proceeding...");
                    successor.Pay(amountToPay);
                }
                else
                {
                    Console.WriteLine("None of the accounts have enough balance");
                }   
            }

            public virtual bool CanPay(double amount)
            {
                return balance >= amount;
            }
        }

        class Bank : Account
        {
            public Bank(double balance)
            {
                this.balance = balance;
            }
        }

        class Paypal : Account
        {
            public Paypal(double balance)
            {
                this.balance = balance;
            }
        }

        class Bitcoin : Account
        {
            public Bitcoin(double balance)
            {
                this.balance = balance;
            }
        }

        public static void DemonstrateChainOfResponsibility()
        {
            // 准备一些账户
            var bank = new Bank(100);      // 银行账户有100元
            var paypal = new Paypal(200);  // PayPal账户有200元
            var bitcoin = new Bitcoin(300); // 比特币账户有300元

            // 设置责任链
            bank.SetNext(paypal);
            paypal.SetNext(bitcoin);

            // 开始支付测试
            bank.Pay(250); // 将尝试支付250元
        }
    }
}
