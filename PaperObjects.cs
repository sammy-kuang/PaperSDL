using System;
using System.Numerics;
using Raylib_cs;

public class Circle
{
    public Vector2 position;
    public float radius;

    public Circle(Vector2 position, float radius)
    {
        this.position = position;
        this.radius = radius;
    }
}

public abstract class CenteredObject
{
    public Vector2 literalPosition;
    public Vector2 position;

    public CenteredObject(Vector2 pos)
    {
        position = pos;
    }

    public abstract void Center();
    public abstract void Draw();
}

public class CenteredRectangle : CenteredObject
{
    public Rectangle rectangle;
    public Vector2 size;
    public CenteredRectangle(Vector2 pos, Vector2 size) : base(pos)
    {
        this.size = size;
        literalPosition = PaperUtils.CenterRectToPoint(pos, size);

        Center();
    }
    public Rectangle GetRectangle()
    {
        return rectangle;
    }
    public override void Center()
    {
        literalPosition = PaperUtils.CenterRectToPoint(position, size);
        rectangle = new Rectangle(literalPosition.X, literalPosition.Y, size.X, size.Y);
    }
    public override void Draw()
    {
        Raylib.DrawRectangleRec(rectangle, Color.BLACK); // Call this method if you want a custom colour
    }

    public void Draw(Color color)
    {
        Raylib.DrawRectangleRec(rectangle, color);
    }
}

public class TextObject : CenteredObject
{
    public string text = "";
    public FontData fontData;
    public Color color;

    public TextObject(Vector2 pos, FontData fd, Color color) : base(pos)
    {
        this.position = pos;
        this.fontData = fd;
        this.color = color;

        Center();
    }

    public TextObject(Vector2 pos, FontData fontData, Color color, string text) : base(pos)
    {
        this.position = pos;
        this.fontData = fontData;
        this.color = color;
        this.text = text;

        Center();
    }

    public void SetText(string newText)
    {
        this.text = newText;
        Center();
    }

    public override void Center()
    {
        literalPosition = position;
    }

    public override void Draw()
    {
        PaperUtils.DrawText(fontData, text, literalPosition, color);
    }
}

public class CenteredText : TextObject
{
    public CenteredText(Vector2 pos, FontData fd, Color color) : base(pos, fd, color) { }
    public CenteredText(Vector2 pos, FontData fontData, Color color, string text) : base(pos, fontData, color, text) { }
    public override void Center()
    {
        literalPosition = PaperUtils.CenterTextToPoint(position, fontData, text);
    }
}

public class CenteredTexture : CenteredObject
{
    public Texture2D texture;
    public CenteredTexture(Vector2 pos, Texture2D texture) : base(pos)
    {
        this.texture = texture;
        Center();
    }
    public Texture2D GetTexture()
    {
        return texture;
    }
    public override void Center()
    {
        literalPosition = PaperUtils.CenterTextureToPoint(position, texture);
    }
    public override void Draw()
    {
        Raylib.DrawTexture(texture, (int)literalPosition.X, (int)literalPosition.Y, Color.WHITE);
    }
}

public class FontData
{
    public Font font;
    public float fontSize;
    public float spacing;

    public FontData(Font font, float fontSize, float spacing = 0f)
    {
        this.font = font;
        this.fontSize = fontSize;
        this.spacing = spacing;
    }
}