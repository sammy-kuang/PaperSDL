using System;
using System.Numerics;
using Raylib_cs;
using PaperSDL;

public class SampleProgram : PaperApp {
    public SampleProgram() : base(800, 600, "Sup") {}
    Color col = Color.GREEN;
    CenteredRectangle rect;
    // Texture2D texture;
    FontData defaultFont;
    TextObject centeredText;

    public static void Main() {
        new SampleProgram();
    }

    public override void Start() {
        defaultFont = new FontData(Raylib.GetFontDefault(), 16);
        rect = new CenteredRectangle(new Vector2(width/2, height/2), new Vector2(100, 100));

        // CenteredText Showcase
        centeredText = new CenteredText(new Vector2(width/2, height/2), new FontData(Raylib.GetFontDefault(), 16f), Color.WHITE, "PaperSDL");
    }

    public override void Update() {
        if(PaperUtils.RectClicked(rect.GetRectangle(), MouseButton.MOUSE_LEFT_BUTTON)) {
            col = (col.Equals(Color.GREEN)) ? Color.RED : Color.GREEN;
            centeredText.SetText(centeredText.text.Equals("PaperSDL") ? "Built on Raylib" : "PaperSDL");
        }
    }

    public override void Draw() {
        Raylib.ClearBackground(Color.DARKGRAY);
        Raylib.DrawRectangleRec(rect.GetRectangle(), col);
        centeredText.Draw();
    }
}