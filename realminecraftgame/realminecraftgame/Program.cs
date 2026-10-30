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
            SpawnSystem spawnSystem = new SpawnSystem(1200, 850, 1000);
            Raylib.SetTargetFPS(60);
            Texture2D explosion = Raylib.LoadTexture("assets/newexplo.png");
            Texture2D villager = Raylib.LoadTexture("assets/villagerIcon.png");
            villager.Width = 12;
            villager.Height = 12;
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

                {
                    for (int i = 0; i < spawnSystem.GetVillagers().Count; i++)
                    {
                        if (spawnSystem.GetVillagers()[i].GetIsAlive())
                        {
                            Raylib.DrawTexture(
                        villager,
                        (int)spawnSystem.GetVillagers()[i].GetIStHIS1(),
                        (int)spawnSystem.GetVillagers()[i].GetIStHIS2(),
                        Color.White);
                        }
                        else
                        {
                            Raylib.DrawTexture(
                        villager,
                        (int)spawnSystem.GetVillagers()[i].GetIStHIS1() - villager.Width / 2,
                        (int)spawnSystem.GetVillagers()[i].GetIStHIS2() - villager.Height / 2,
                        Color.Red);
                        }
                    }
                }

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
