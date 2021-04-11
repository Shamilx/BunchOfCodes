using System;

namespace programNamespace
{
    class Wallet
    {
        private int _money;

        // coin

        // Send + number
        public void addCoin(int coin) 
        {
            if (coin > 0 && coin <= 100)
            {
                _money = _money + coin;
            }
            else
            {
                Console.WriteLine("Exception!");
            }
        }

        // Send + number
        public void decreaseCoin(int coin)
        {
            if (coin > 0 && coin <= 100)
            {
                _money = _money - coin;
            }
            else
            {
                Console.WriteLine("Exception!");
            }
        }

        // get as coin
        public int getCoin() { return _money; }

        // manat
        public void addManat(int manat)
        {
            if (manat > 0)
            {
                _money = _money + (manat * 100);
            }
            else
            {
                Console.WriteLine("Exception!");                
            }
        }

        public void decreaseManat(int manat)
        {
            if (manat > 0)
            {
                _money = _money - (manat * 100);
            }
            else
            {
                Console.WriteLine("Exception!");
            }
        }

        // get as manat
        public int getManat()
        {
            return (int)(_money / 100);
        }

        // printAsManatAndCoin
        public void printMoney()
        {
            int manat = getManat();
            int coin = _money - (manat * 100);
            Console.WriteLine("Manat : " + manat);
            Console.WriteLine("Coin : " + coin);
        }
    }
    class Program
    {
        static void Main()
        {
            Wallet obj = new Wallet();
            obj.addManat(5);
            obj.addCoin(30);
            obj.decreaseCoin(50);
            obj.printMoney();
        }
    }
    
}
