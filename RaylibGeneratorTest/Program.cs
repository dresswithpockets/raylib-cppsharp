using Raylib;
using rl = Raylib.Raylib;

namespace RaylibGeneratorTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            rl.InitWindow(640, 480, "Hello World");

            while (!rl.WindowShouldClose())
            {
                rl.BeginDrawing();

                rl.ClearBackground(new Color { R = 255, G = 30, B = 255, A = 255 });
                rl.DrawText("Hello, world!", 12, 12, 20, new Color { R = 0, G = 0, B = 0, A = 255 });

                rl.EndDrawing();
            }

            rl.CloseWindow();
        }
    }
}