using Raylib_cs;
//using Raylib_CsLo;
namespace realminecraftgame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 460, "Village");

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(color: Color.Black);
                Raylib.DrawText("Hello World!!", 12, 12, 20, Color.Red);
                Raylib.EndDrawing();

            }

            Raylib.CloseWindow();
        }
    }
}
