using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace PaperSDL {
    public static class PaperUtils {
        // centering methods
        public static Vector2 CenterRectToPoint(Vector2 size, Vector2 point) {
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

        // click detection methods
        public static bool RectClicked(Rectangle rect, MouseButton mb = MouseButton.MOUSE_LEFT_BUTTON) {
            return (CheckCollisionPointRec(GetMousePosition(), rect) && IsMouseButtonPressed(mb));
        }

        public static bool TextureClicked(Texture2D texture, Vector2 pos, MouseButton mb = MouseButton.MOUSE_LEFT_BUTTON) {
            Rectangle rec = new Rectangle(pos.X, pos.Y, texture.width, texture.height);

            return (RectClicked(rec, mb));
        }

        public static bool CircleClicked(Vector2 circlePos, float radius, MouseButton mb = MouseButton.MOUSE_LEFT_BUTTON)  {
            return (Raylib.CheckCollisionPointCircle(GetMousePosition(), circlePos, radius) && IsMouseButtonPressed(mb));
        }

        public static bool CircleClicked(Circle circle, MouseButton mb = MouseButton.MOUSE_LEFT_BUTTON) {
            return CircleClicked(circle.position, circle.radius, mb);
        }

        // held click methods

        public static bool RectClick(Rectangle rect, MouseButton mb = MouseButton.MOUSE_LEFT_BUTTON) {
            return (CheckCollisionPointRec(GetMousePosition(), rect) && IsMouseButtonDown(mb));
        }

        public static bool TextureClick(Texture2D texture, Vector2 pos, MouseButton mb = MouseButton.MOUSE_LEFT_BUTTON) {
            Rectangle rec = new Rectangle(pos.X, pos.Y, texture.width, texture.height);

            return (RectClicked(rec, mb));
        }

        public static bool CircleClick(Vector2 circlePos, float radius, MouseButton mb = MouseButton.MOUSE_LEFT_BUTTON)  {
            return (Raylib.CheckCollisionPointCircle(GetMousePosition(), circlePos, radius) && IsMouseButtonDown(mb));
        }

        public static bool CircleClick(Circle circle, MouseButton mb = MouseButton.MOUSE_LEFT_BUTTON) {
            return CircleClicked(circle.position, circle.radius, mb);
        }


        // draw methods
        public static void DrawCircle(Circle circle, Color color) {
            Raylib.DrawCircle((int)circle.position.X, (int)circle.position.Y, circle.radius, color);
        }

        public static void DrawText(FontData fontData, string text,  Vector2 position, Color color, float spacing=0) {
            Raylib.DrawTextEx(fontData.font, text, position, fontData.fontSize, spacing, color);
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
}