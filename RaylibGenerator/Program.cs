using CppSharp;

namespace RaylibGenerator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var lib = new Library();
            ConsoleDriver.Run(lib);
        }
    }
}