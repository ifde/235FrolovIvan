﻿
namespace Taask01Lib
{
    public class BankAccount
    {
        private object thisLock = new object();

        volatile int accountAmount;

        Random r = new Random();

        public BankAccount(int sum)
        {
            accountAmount = sum;
        }

        int Buy(int sum)
        {
            if (accountAmount == 0)
                throw new InvalidOperationException($"Нулевой баланс...");
            // условие никогда не выполнится, пока вы не закомментируете lock.  
            if (accountAmount < 0)
                throw new InvalidOperationException($"Отрицательный баланс");
            lock (thisLock)
            {
                if (accountAmount >= sum)
                {
                    Console.WriteLine($"Состояние счета: {accountAmount}");
                    Console.WriteLine($" Покупка на сумму: {sum}");
                    accountAmount = accountAmount - sum;
                    Console.WriteLine($" Счет после пок.: {accountAmount}");
                    Console.WriteLine($"Thread: {Thread.CurrentThread.Name}");
                    return sum;
                }
                else
                {
                    return 0; // не хватает денег - отказываем в покупке
                }
            }
        }

        public void DoTransactions()
        {
            try
            {
                while (true)
                {
                    Buy(r.Next(1, 50));
                    Thread.Sleep(r.Next(1, 10));
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Обработано исключение: {ex.Message}. Поток завершает работу...");
            }
        }


    }

}