//using System.Numerics;
//using Raylib_cs;

//// "CLICK ME" button that corrupts the screen into chunky pixels.
//// The button art comes from button.png (the horror sign picture) and is pixelated on load.
//// If button.png is missing it falls back to a plain purple button.
////static class CorruptButton
////{
// //  public static bool Corrupted = false;

//    const int PixelSize = 6;          // chunkiness of the corrupted screen
//    const int ButtonPixelsWide = 100; // resolution of the button art (smaller = chunkier)
//    const int ButtonScale = 3;        // every art pixel becomes 3x3 screen pixels

//    static Rectangle button = new Rectangle(20, 20, 170, 50);
//    static readonly Random rng = new Random();

//    static RenderTexture2D lowRes;
//    static bool lowResReady = false;

//    static RenderTexture2D buttonArt;
//    static bool buttonArtReady = false;
//    static bool loadTried = false;

//    // Loads and pixelates button.png once.
//    static void EnsureLoaded()
//    {
//        if (loadTried) return;
//        loadTried = true;

//        string path = Path.Combine(AppContext.BaseDirectory, "button.png");
//        if (!File.Exists(path)) return;

//        Texture2D img = Raylib.LoadTexture(path);
//        buttonArt = BuildPixelButton(img);
//        Raylib.UnloadTexture(img);
//        buttonArtReady = true;

//        button = new Rectangle(20, 20,
//            buttonArt.Texture.Width * ButtonScale,
//            buttonArt.Texture.Height * ButtonScale);
//    }

//    // Crops the sign out of the picture and shrinks it in steps of 2 (so colors get averaged
//    // nicely instead of skipping pixels). The last step uses hard pixel edges.
//    static RenderTexture2D BuildPixelButton(Texture2D img)
//    {
//        // where the sign is inside the picture, as fractions of its size (works for any image size)
//        var crop = new Rectangle(img.Width * 0.224f, img.Height * 0.26f,
//                                 img.Width * 0.565f, img.Height * 0.452f);

//        int outW = ButtonPixelsWide;
//        int outH = (int)(outW * crop.Height / crop.Width);

//        Texture2D curTex = img;
//        Rectangle src = crop;
//        float cw = crop.Width, ch = crop.Height;
//        var made = new List<RenderTexture2D>();
//        RenderTexture2D result;

//        while (true)
//        {
//            bool last = cw / 2 <= outW;
//            int nw = last ? outW : (int)(cw / 2);
//            int nh = last ? outH : (int)(ch / 2);

//            var rt = Raylib.LoadRenderTexture(nw, nh);
//            Raylib.SetTextureFilter(rt.Texture, last ? TextureFilter.Point : TextureFilter.Bilinear);
//            Raylib.BeginTextureMode(rt);
//            Raylib.DrawTexturePro(curTex, src, new Rectangle(0, 0, nw, nh), Vector2.Zero, 0f, Color.White);
//            Raylib.EndTextureMode();
//            made.Add(rt);

//            if (last) { result = rt; break; }

//            curTex = rt.Texture;
//            src = new Rectangle(0, 0, nw, -nh); // render textures are stored upside down
//            cw = nw; ch = nh;
//        }

//        foreach (var rt in made)
//            if (rt.Id != result.Id) Raylib.UnloadRenderTexture(rt);

//        return result;
//    }

//    // Call once per frame, at the start of your game loop.
//    public static bool Update()
//    {
//        EnsureLoaded();
//        bool hover = Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), button);
//        if (hover && Raylib.IsMouseButtonPressed(MouseButton.Left))
//            Corrupted = !Corrupted;
//        return hover;
//    }

//    // Call once per frame, right before Raylib.EndDrawing().
//    public static void Draw()
//    {
//        EnsureLoaded();

//        if (Corrupted)
//        {
//            int w = Raylib.GetScreenWidth();
//            int h = Raylib.GetScreenHeight();

//            if (!lowResReady)
//            {
//                lowRes = Raylib.LoadRenderTexture(w / PixelSize, h / PixelSize);
//                Raylib.SetTextureFilter(lowRes.Texture, TextureFilter.Point);
//                lowResReady = true;
//            }
//            int lw = lowRes.Texture.Width;
//            int lh = lowRes.Texture.Height;

//            // copy what is on screen, shrink it, stretch it back = pixelated
//            Rlgl.DrawRenderBatchActive();
//            Image shot = Raylib.LoadImageFromScreen();
//            Texture2D tex = Raylib.LoadTextureFromImage(shot);
//            Raylib.UnloadImage(shot);

//            Raylib.BeginTextureMode(lowRes);
//            Raylib.DrawTexturePro(tex,
//                new Rectangle(0, 0, tex.Width, tex.Height),
//                new Rectangle(0, 0, lw, lh),
//                Vector2.Zero, 0f, Color.White);
//            Raylib.EndTextureMode();
//            Raylib.UnloadTexture(tex);

//            Raylib.DrawTexturePro(lowRes.Texture,
//                new Rectangle(0, 0, lw, -lh),
//                new Rectangle(0, 0, w, h),
//                Vector2.Zero, 0f, Color.White);

//            // blood-red tint (change the numbers for another color)
//            Raylib.DrawRectangle(0, 0, w, h, new Color(140, 0, 20, 90));

//            // glitch blocks snapped to the pixel grid
//            for (int i = 0; i < 30; i++)
//            {
//                var c = rng.Next(3) switch
//                {
//                    0 => new Color(255, 30, 0, 150),
//                    1 => new Color(255, 140, 0, 130),
//                    _ => new Color(0, 0, 0, 180)
//                };
//                int bx = rng.Next(w / PixelSize) * PixelSize;
//                int by = rng.Next(h / PixelSize) * PixelSize;
//                Raylib.DrawRectangle(bx, by, rng.Next(2, 14) * PixelSize, rng.Next(1, 3) * PixelSize, c);
//            }
//        }

//        // button always on top
//        bool hover = Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), button);
//        if (buttonArtReady)
//        {
//            Color tint = hover ? Color.White : new Color(210, 210, 210, 255); // lights up on hover
//            Raylib.DrawTexturePro(buttonArt.Texture,
//                new Rectangle(0, 0, buttonArt.Texture.Width, -buttonArt.Texture.Height),
//                button, Vector2.Zero, 0f, tint);
//        }
//        else
//        {
//            Raylib.DrawRectangleRec(button, hover ? Color.Purple : Color.DarkPurple);
//            Raylib.DrawText(Corrupted ? "RESTORE" : "CLICK ME", (int)button.X + 20, (int)button.Y + 14, 24, Color.White);
//        }
//    }
//}

