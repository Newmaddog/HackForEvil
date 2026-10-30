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
            Texture2D explosion = Raylib.LoadTexture("assets/newexplo.png");
            Vector2 explosionPosition = new Vector2(0, 0);
            bool showExplosion = false;
            Texture2D map = Raylib.LoadTexture("assets/map1.png");

            while (!Raylib.WindowShouldClose())
            {
                if (Raylib.IsMouseButtonPressed(MouseButton.Left))
                {
                    Vector2 position = Raylib.GetMousePosition();
                    showExplosion = true;
                    explosionPosition = Raylib.GetMousePosition();
                    Console.WriteLine($"Clicked at X: {position.X}, Y: {position.Y}");

                }
                Raylib.BeginDrawing();
                
                Raylib.ClearBackground(Color.Black);

                Raylib.DrawTexture(map, 0, 0, Color.White);

                if (showExplosion)
                {
                    Raylib.DrawTexture(
                        explosion,
                        (int)explosionPosition.X,
                        (int)explosionPosition.Y,
                        Color.White
                    );
                }

                Explosion();

                Raylib.EndDrawing();
            }

            Raylib.UnloadTexture(map);
            Raylib.UnloadTexture(explosion);
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
