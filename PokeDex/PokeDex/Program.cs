namespace PokeDex
{
    internal class Program
    {
        private static PokeDexController pokeDexController = new PokeDexController();
        static void Main(string[] args)
        {
            pokeDexController.MenuInfo();
        }
    }
}