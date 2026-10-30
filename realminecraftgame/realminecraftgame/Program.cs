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
            Texture2D spinner = Raylib.LoadTexture("assets/torpedo.png");
            villager.Width = 15;
            villager.Height = 15;
            float scale = 0.3f;
            int explosionHeight = explosion.Height;
            int explosionWidth = explosion.Width;


            Vector2 explosionPosition = new Vector2(0, 0);

            bool showExplosion = false;
            bool spinnerActive = false;
            float spinTimer = 0f;

            Texture2D map = Raylib.LoadTexture("assets/map1.png");

            while (!Raylib.WindowShouldClose())
            {
                if (Raylib.IsMouseButtonPressed(MouseButton.Left))
                {
                    showExplosion = false;
                    spinnerActive = true;
                    spinTimer = 0f;
                    explosionPosition = Raylib.GetMousePosition();
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

                if (spinnerActive)
                {
                    spinTimer += Raylib.GetFrameTime();
                     
                    if (spinTimer >= 0.6f)
                    {
                        spinnerActive = false;
                        showExplosion = true;
                    }

                    float size = 500f * (1f - spinTimer / 0.6f);
                    float rotation = spinTimer * 720f;

                    Raylib.DrawTexturePro(
                        spinner,
                        new Rectangle(0, 0, spinner.Width, spinner.Height),
                        new Rectangle(explosionPosition.X, explosionPosition.Y, size, size),
                        new Vector2(size / 2, size / 2),
                        rotation,
                        Color.White
                    );
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
