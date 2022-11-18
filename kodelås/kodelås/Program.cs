using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace kodelås
{
    internal class Program
    {
        private static Lock codeLock = new Lock();

        static void Main(string[] args)
        {
            while (codeLock.IsLockd)
            {
                TryLock();
            }
            
        }

        private static void TryLock()
        {
            Console.WriteLine("Enter Code!");
            try
            {
                if (codeLock.Try > 0)
                {
                    
                    var input = Convert.ToInt32(Console.ReadLine());
                    if (codeLock.Code == input)
                    {
                        Console.Clear();
                        Console.WriteLine("You have unlocked the lock");
                        codeLock.IsLockd = false;
                    }
                    else
                    {
                        Console.Clear();
                        codeLock.Try--;
                        Console.WriteLine($"You have {codeLock.Try} left!");
                        Console.WriteLine("Try again");
                        if (codeLock.Try == 0)
                        {
                            Console.WriteLine("You faild!");
                            codeLock.IsLockd = false;
                        }
                    }
                }
            }
            catch
            {
                Console.Clear();
                codeLock.Try--;
                Console.WriteLine("EY! DUMBFUQ. E FAN IKKJE NÅKKA BOKSTAVA HÆR!!!!");
                Console.WriteLine($"You have {codeLock.Try} left!");
            }
            
        }
    }
}