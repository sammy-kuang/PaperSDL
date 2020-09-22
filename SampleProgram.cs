using System;
using System.Numerics;
using Raylib_cs;
using PaperSDL;

public class SampleProgram : PaperApp {
    public SampleProgram() : base(800, 600, "Sup") {}
    Rectangle rect = new Rectangle();
    Color col = Color.GREEN;


    public static void Main() {
        new SampleProgram();
    }

    public override void Start() {
        Console.WriteLine("Started Start Function");
        Vector2 pos = PaperUtils.CenterRectToPoint(new Vector2(100, 100), new Vector2(width/2, height/2));
        rect = new Rectangle(pos.X , pos.Y, 100, 100);

        Console.WriteLine(Raylib.GetScreenWidth());
    }

    public override void Update() {
        if(PaperUtils.RectClicked(rect)) {
            col = (col.Equals(Color.GREEN)) ? Color.RED : Color.GREEN;
            int newWidth = Raylib.GetScreenWidth() == 800 ? 1280 : 800;
            int newHeight = Raylib.GetScreenHeight() == 600 ? 720 : 600;

            Raylib.SetWindowSize(newWidth, newHeight);

            CenterWindow();
        }
    }

    public override void Draw() {
        Raylib.ClearBackground(Color.DARKGRAY);
        Raylib.DrawRectangleRec(rect, col);
    }

    private void CenterWindow() {
        // Raylib.SetWindowPosition(Raylib.GetMonitorWidth(0)/2 - Raylib.GetScreenWidth()/2, Raylib.GetMonitorHeight(0)/2 );

        Raylib.SetWindowPosition(0,0);
        
    }
}