using System;
using System.Numerics;
using Raylib_cs;
using PaperSDL;

public class SampleProgram : PaperApp {
    public SampleProgram() : base(100, 100, "Sup") {}

    Rectangle rect = new Rectangle();
    Color col = Color.GREEN;

    public static void Main() {
        new SampleProgram();
    }

    public override void Start() {
        Vector2 pos = PaperUtils.CenterRectPoint(new Vector2(10, 10), new Vector2(50, 50));
        rect = new Rectangle(pos.X , pos.Y, 10, 10);
    }

    public override void Update() {
        if(PaperUtils.RectClicked(rect)) {
            col = (col.Equals(Color.GREEN)) ? Color.RED : Color.GREEN;
        }
    }

    public override void Draw() {
        Raylib.ClearBackground(Color.DARKGRAY);
        Raylib.DrawRectangleRec(rect, col);
    }
}