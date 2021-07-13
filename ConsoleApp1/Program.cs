using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var eggs = await eggsTask;
            Console.WriteLine("eggs are ready");

            var bacon = await baconTask;
            Console.WriteLine("bacon is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");

            var toast = await toastTask;
            Console.WriteLine("toast is ready");

        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring Orange Juice...");
            return new Juice();
        }
        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on toast...");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Apply butter on toast...");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster...");
            }
            Console.WriteLine("Start Toasting");
            await Task.Delay(3000);
            Console.WriteLine("Remove Toast from the Toaster");

            return new Toast();
        }

        private static async Task<Toast> MakeToastWithButterAndJamAsync(int slices)
        {
            var toast = await ToastBreadAsync(slices);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

    }

    class Coffee { }
    class Juice { }
    class Toast { }
    class Bacon { }
    class Egg { }
}
