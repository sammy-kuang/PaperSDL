using System;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;

namespace PaperSDL
{
    public class PaperApp {

        public int width;
        public int height;
        public string title;

        public PaperApp(int width, int height, string title = "PaperSDL Project") {
            this.width = width;
            this.height = height;
            this.title = title;
            PaperStart();
        }

        private void PaperStart() {
            Awake();
            InitWindow(width, height, title);
            Start();
            
            while(!WindowShouldClose()) {
                Update();
                PaperDraw();
            }

            Close();
            CloseWindow();
        }

        private void PaperDraw() {
            BeginDrawing();
            Draw();
            EndDrawing();
        }

        public virtual void Update() {}
        public virtual void Draw() {
            ClearBackground(WHITE);
        }

        public virtual void Start() {}
        public virtual void Awake() {}
        public virtual void Close() {}
    }
}
