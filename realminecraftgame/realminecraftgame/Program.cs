using Raylib_cs;
using System.Numerics;
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
                Explosion();
                Raylib.DrawTexture(map, 0, 0, Color.White);

                Raylib.EndDrawing();
            }

            Raylib.UnloadTexture(map);
            Raylib.CloseWindow();
        }




      static public void Explosion()
        {
            if (Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                Vector2 position = Raylib.GetMousePosition();

                Console.WriteLine($"Clicked at X: {position.X}, Y: {position.Y}");


            }
        }

     
    }
}
