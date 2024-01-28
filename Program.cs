namespace AsyncAwaitTests
{
    class Program
    {
        public static async Task Main()
        {
            var teaMaker = new TeaMaker1();
            var tea = await teaMaker.MakeTeaAsync();
            await Console.Out.WriteLineAsync(tea + Thread.CurrentThread.ManagedThreadId);

            Console.ReadLine();

            var teaMaker2 = new TeaMaker2();
            var tea2 = await teaMaker2.MakeTeaAsync();
            await Console.Out.WriteLineAsync(tea2 + Thread.CurrentThread.ManagedThreadId);
        }
    }
    class TeaMaker1
    {
        public async Task<string> MakeTeaAsync()
        {
            await Console.Out.WriteLineAsync("A)take the cups out " + Thread.CurrentThread.ManagedThreadId);
            await Console.Out.WriteLineAsync("B)put tea in cups " + Thread.CurrentThread.ManagedThreadId);
            var water = await BoilWaterAsync();
            var tea = $"C)pour {water} in cups ";
            var a = true.ToString();
            return tea;
        }
        public async Task<string> BoilWaterAsync()
        {
            await Console.Out.WriteLineAsync("D)start the kettle " + Thread.CurrentThread.ManagedThreadId);
            await Console.Out.WriteLineAsync("E)waiting for kettle " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(2000);
            await Console.Out.WriteLineAsync("F)kettle finidhed " + Thread.CurrentThread.ManagedThreadId);
            return "WATER";
        }
    }

    class TeaMaker2
    {
        public async Task<string> MakeTeaAsync()
        {
            var boilingWater = BoilWaterAsync();
            await Console.Out.WriteLineAsync("A)take the cups out " + Thread.CurrentThread.ManagedThreadId);
            await Console.Out.WriteLineAsync("B)put tea in cups " + Thread.CurrentThread.ManagedThreadId);
            var water = await boilingWater;
            var tea = $"C)pour {water} in cups ";
            var a = true.ToString();
            return tea;
        }
        public async Task<string> BoilWaterAsync()
        {
            await Console.Out.WriteLineAsync("D)start the kettle " + Thread.CurrentThread.ManagedThreadId);
            await Console.Out.WriteLineAsync("E)waiting for kettle " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(2000);
            await Console.Out.WriteLineAsync("F)kettle finidhed " + Thread.CurrentThread.ManagedThreadId);
            return "WATER";
        }
    }
}
