using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
using PaperSDL;

public static class PaperUtils
{
    // centering methods
    public static Vector2 CenterRectToPoint(Vector2 point, Vector2 size)
    {
        return new Vector2(point.X - size.X / 2, point.Y - size.Y / 2);
    }

    public static Vector2 CenterTextToPoint(Vector2 point, Font font, float fontSize, string text, float spacing = 0f)
    {
        Vector2 textSize = MeasureTextEx(font, text, fontSize, spacing);
        return new Vector2(point.X - textSize.X / 2, point.Y - textSize.Y / 2);
    }

    public static Vector2 CenterTextToPoint(Vector2 point, FontData fontData, string text)
    {
        return CenterTextToPoint(point, fontData.font, fontData.fontSize, text, fontData.spacing);
    }

    public static Vector2 CenterTextureToPoint(Vector2 point, Texture2D texture)
    {
        return new Vector2(point.X - texture.width / 2, point.Y - texture.height / 2);
    }

    // mouse detection methods
    public static bool IsMouseOver(Rectangle rect)
    {
        return CheckCollisionPointRec(GetMousePosition(), rect);
    }

    public static bool IsMouseOver(Circle circle)
    {
        return CheckCollisionPointCircle(GetMousePosition(), circle.position, circle.radius);
    }

    public static bool IsMouseOver(Texture2D texture, Vector2 pos)
    {
        Rectangle rec = new Rectangle(pos.X, pos.Y, texture.width, texture.height);
        return CheckCollisionPointRec(GetMousePosition(), rec);
    }

    public static bool RectClick(Rectangle rect, MouseButton mb = MouseButton.MOUSE_LEFT_BUTTON)
    {
        return (IsMouseOver(rect) && Raylib.IsMouseButtonDown(mb));
    }

    public static bool CircleClick(Circle circle, MouseButton mb = MouseButton.MOUSE_LEFT_BUTTON)
    {
        return (IsMouseOver(circle) && Raylib.IsMouseButtonDown(mb));
    }

    public static bool TextureClick(Texture2D texture, Vector2 pos, MouseButton mb = MouseButton.MOUSE_LEFT_BUTTON)
    {
        return (IsMouseOver(texture, pos) && Raylib.IsMouseButtonDown(mb));
    }
    public static bool RectClicked(Rectangle rect, MouseButton mb = MouseButton.MOUSE_LEFT_BUTTON)
    {
        return (IsMouseOver(rect) && Raylib.IsMouseButtonPressed(mb));
    }

    public static bool CircleClicked(Circle circle, MouseButton mb = MouseButton.MOUSE_LEFT_BUTTON)
    {
        return (IsMouseOver(circle) && Raylib.IsMouseButtonPressed(mb));
    }

    public static bool TextureClicked(Texture2D texture, Vector2 pos, MouseButton mb = MouseButton.MOUSE_LEFT_BUTTON)
    {
        return (IsMouseOver(texture, pos) && Raylib.IsMouseButtonPressed(mb));
    }

    // draw methods
    public static void DrawCircle(Circle circle, Color color)
    {
        Raylib.DrawCircle((int)circle.position.X, (int)circle.position.Y, circle.radius, color);
    }

    public static void DrawText(FontData fontData, string text, Vector2 position, Color color)
    {
        Raylib.DrawTextEx(fontData.font, text, position, fontData.fontSize, fontData.spacing, color);
    }

    public static void DrawCenteredObject(CenteredObject obj)
    {
        obj.Draw();
    }

}


