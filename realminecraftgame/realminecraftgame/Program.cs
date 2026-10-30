using Raylib_cs;
//using Raylib_CsLo;

namespace realminecraftgame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            Raylib.InitWindow(1400, 900, "Minecraft Bomber");
            Raylib.SetTargetFPS(60);

            Texture2D map = Raylib.LoadTexture("assets/map1.png");

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.Black);

                Raylib.DrawTexture(map, 0, 0, Color.White);

                Raylib.EndDrawing();
            }

            Raylib.UnloadTexture(map);
            Raylib.CloseWindow();
        }
    }
}
