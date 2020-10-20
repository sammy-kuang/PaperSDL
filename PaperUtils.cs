using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace PaperSDL {
    public static class PaperUtils {
        // centering methods
        public static Vector2 CenterRectToPoint(Vector2 point, Vector2 size) {
            return new Vector2(point.X - size.X/2, point.Y - size.Y/2);
        }

        public static Vector2 CenterTextToPoint(Font font, float fontSize, string text, Vector2 point) {
            Vector2 textSize = MeasureTextEx(font, text, fontSize, 0);
            return new Vector2(point.X - textSize.X/2, point.Y - textSize.Y/2);
        }

        public static Vector2 CenterTextToPoint(FontData fontData, string text, Vector2 point) {
            return CenterTextToPoint(fontData.font, fontData.fontSize, text, point);
        }

        public static Vector2 CenterTextureToPoint(Texture2D texture, Vector2 point) {
            return new Vector2(point.X - texture.width/2, point.Y - texture.height/2);
        }

        // mouse detection methods
        public static bool IsMouseOver(Rectangle rect) {
            return CheckCollisionPointRec(GetMousePosition(), rect);
        }

        public static bool IsMouseOver(Circle circle) {
            return CheckCollisionPointCircle(GetMousePosition(), circle.position, circle.radius);
        }

        public static bool IsMouseOver(Texture2D texture, Vector2 pos) {
            Rectangle rec = new Rectangle(pos.X, pos.Y, texture.width, texture.height);
            return CheckCollisionPointRec(GetMousePosition(), rec);
        }

        public static bool RectClick(Rectangle rect, MouseButton mb = MouseButton.MOUSE_LEFT_BUTTON) {
            return (IsMouseOver(rect) && Raylib.IsMouseButtonDown(mb));
        }

        public static bool CircleClick(Circle circle, MouseButton mb = MouseButton.MOUSE_LEFT_BUTTON) {
            return (IsMouseOver(circle) && Raylib.IsMouseButtonDown(mb));
        }

        public static bool TextureClick(Texture2D texture, Vector2 pos, MouseButton mb = MouseButton.MOUSE_LEFT_BUTTON) {
            return (IsMouseOver(texture, pos) && Raylib.IsMouseButtonDown(mb));
        }
        public static bool RectClicked(Rectangle rect, MouseButton mb = MouseButton.MOUSE_LEFT_BUTTON) {
            return (IsMouseOver(rect) && Raylib.IsMouseButtonPressed(mb));
        }

        public static bool CircleClicked(Circle circle, MouseButton mb = MouseButton.MOUSE_LEFT_BUTTON) {
            return (IsMouseOver(circle) && Raylib.IsMouseButtonPressed(mb));
        }

        public static bool TextureClicked(Texture2D texture, Vector2 pos, MouseButton mb = MouseButton.MOUSE_LEFT_BUTTON) {
            return (IsMouseOver(texture, pos) && Raylib.IsMouseButtonPressed(mb));
        }


        // draw methods
        public static void DrawCircle(Circle circle, Color color) {
            Raylib.DrawCircle((int)circle.position.X, (int)circle.position.Y, circle.radius, color);
        }

        public static void DrawText(FontData fontData, string text,  Vector2 position, Color color, float spacing=0) {
            Raylib.DrawTextEx(fontData.font, text, position, fontData.fontSize, spacing, color);
        }

        public static void DrawCenteredTexture(CenteredTexture texture) {
            Raylib.DrawTexture(texture.GetTexture(), (int)texture.literalPosition.X, (int)texture.literalPosition.Y, Color.WHITE);
        }
        
    }

    public class FontData {
        public Font font;
        public float fontSize;

        public FontData(Font font, float fontSize) {
            this.font = font;
            this.fontSize = fontSize;
        }
    }

    public class Circle {
        public Vector2 position;
        public float radius;

        public Circle(Vector2 position, float radius) {
            this.position = position;
            this.radius = radius;
        }
    }

    public class CenteredRectangle {
        public Rectangle rectangle;
        public Vector2 literalPosition;
        public Vector2 position;

        public CenteredRectangle(Vector2 pos, Vector2 size) {
            position = pos;
            literalPosition = PaperUtils.CenterRectToPoint(pos, size);
            rectangle = new Rectangle(literalPosition.X, literalPosition.Y, size.X, size.Y);
        }

        public Rectangle GetRectangle() {
            return rectangle;
        }
    }

    public class CenteredTexture {
        public Texture2D texture;
        public Vector2 literalPosition;
        public Vector2 position;

        public CenteredTexture(Texture2D texture, Vector2 pos) {
            this.texture = texture;
            position = pos;
            literalPosition = PaperUtils.CenterTextureToPoint(texture, pos);

        }

        public Texture2D GetTexture() {
            return texture;
        }
    }
}