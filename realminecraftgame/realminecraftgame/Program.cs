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
            Texture2D villager = Raylib.LoadTexture("assets/villagerIcon.png");
            villager.Width = 15;
            villager.Height = 15;
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

                {
                    for (int i = 0; i < spawnSystem.GetVillagers().Count; i++)
                    {
                        Raylib.DrawTexture(
                        villager,
                        (int)spawnSystem.GetVillagers()[i].GetPositionX(),
                        (int)spawnSystem.GetVillagers()[i].GetPositionY(),
                        Color.White
                    );
                    }
                }

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
            Raylib.UnloadTexture(villager);
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
