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
            SpawnSystem spawnSystem = new SpawnSystem(1400, 900, 1000);
            Raylib.SetTargetFPS(60);
            Texture2D explosion = Raylib.LoadTexture("assets/newexplo.png");
            float scale = 0.3f;
            int explosionHeight = explosion.Height;
            int explosionWidth = explosion.Width;


            Vector2 explosionPosition = new Vector2(0, 0);

            bool showExplosion = false;
            Texture2D map = Raylib.LoadTexture("assets/map1.png");

            while (!Raylib.WindowShouldClose())
            {
                if (Raylib.IsMouseButtonPressed(MouseButton.Left))
                {
                    showExplosion = true;
                    explosionPosition = Raylib.GetMousePosition();


                }
                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.Black);

                Raylib.DrawTexture(map, 0, 0, Color.White);

                if (showExplosion)
                {
                    Raylib.DrawTextureEx(explosion, new Vector2(
                explosionPosition.X - (explosionWidth * scale) / 2,
                explosionPosition.Y - (explosionHeight * scale) / 2),
                0f,  
                 scale,
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
