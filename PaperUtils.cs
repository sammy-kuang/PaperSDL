using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace PaperSDL {
    public static class PaperUtils {
        public static Vector2 CenterRectPoint(Vector2 size, Vector2 point) {
            return new Vector2(point.X - size.X/2, point.Y - size.Y/2);
        }

        public static Vector2 CenterTextPoint(Font font, float fontSize, string text, Vector2 point) {
            Vector2 textSize = MeasureTextEx(font, text, fontSize, 0);
            return new Vector2(point.X - textSize.X/2, point.Y - textSize.Y/2);
        }

        public static Vector2 CenterTextPoint(FontData fontData, string text, Vector2 point) {
            return CenterTextPoint(fontData.font, fontData.fontSize, text, point);
        }

        public static bool RectClicked(Rectangle rect, MouseButton mb = MouseButton.MOUSE_LEFT_BUTTON) {
            return (CheckCollisionPointRec(GetMousePosition(), rect) && IsMouseButtonPressed(mb));
        }

        public static bool CircleClicked(Vector2 circlePos, float radius, MouseButton mb = MouseButton.MOUSE_LEFT_BUTTON)  {
            return (Raylib.CheckCollisionPointCircle(GetMousePosition(), circlePos, radius) && IsMouseButtonPressed(mb));
        }
    }

    public class FontData {
        public Font font;
        public float fontSize;
    }
}