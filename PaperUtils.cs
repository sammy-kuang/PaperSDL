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

        public static Vector2 CenterTextToPoint(Vector2 point, Font font, float fontSize, string text, float spacing = 0f) {
            Vector2 textSize = MeasureTextEx(font, text, fontSize, spacing);
            return new Vector2(point.X - textSize.X/2, point.Y - textSize.Y/2);
        }

        public static Vector2 CenterTextToPoint(Vector2 point, FontData fontData, string text) {
            return CenterTextToPoint(point, fontData.font, fontData.fontSize, text, fontData.spacing);
        }

        public static Vector2 CenterTextureToPoint(Vector2 point, Texture2D texture) {
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

        public static void DrawText(FontData fontData, string text,  Vector2 position, Color color) {
            Raylib.DrawTextEx(fontData.font, text, position, fontData.fontSize, fontData.spacing, color);
        }

        public static void DrawCenteredObject(CenteredObject obj) {
            obj.Draw();
        }

    }

    public class FontData {
        public Font font;
        public float fontSize;
        public float spacing;

        public FontData(Font font, float fontSize, float spacing = 0f) {
            this.font = font;
            this.fontSize = fontSize;
            this.spacing = spacing;
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

    public abstract class CenteredObject {
        public Vector2 literalPosition;
        public Vector2 position;

        public CenteredObject(Vector2 pos) {
            position = pos;
        }

        public abstract void Center();
        public abstract void Draw();
    }

    public class CenteredRectangle : CenteredObject {
        public Rectangle rectangle;
        public Vector2 size;
        public CenteredRectangle(Vector2 pos, Vector2 size) : base(pos){
            this.size = size;
            literalPosition = PaperUtils.CenterRectToPoint(pos, size);

            Center();
        }
        public Rectangle GetRectangle() {
            return rectangle;
        }
        public override void Center() {
            literalPosition = PaperUtils.CenterRectToPoint(position, size);
            rectangle = new Rectangle(literalPosition.X, literalPosition.Y, size.X, size.Y);
        }
        public override void Draw() {
            Raylib.DrawRectangleRec(rectangle, Color.BLACK); // Call this method if you want a custom colour
        }
    }

    public class TextObject : CenteredObject {
        public string text = "";
        public FontData fontData;
        public Color color;

        public TextObject(Vector2 pos, FontData fd, Color color) : base(pos) {
            this.position = pos;
            this.fontData = fd;
            this.color = color;

            Center();
        }

        public TextObject(Vector2 pos, FontData fontData, Color color, string text) : base(pos) {
            this.position = pos;
            this.fontData = fontData;
            this.color = color;
            this.text = text;

            Center();
        }

        public void SetText(string newText) {
            this.text = newText;
            Center();
        }

        public override void Center() {
            literalPosition = position;
        }

        public override void Draw() {
            PaperUtils.DrawText(fontData, text, literalPosition, color);
        }
    }

    public class CenteredText : TextObject {
        public CenteredText(Vector2 pos, FontData fd, Color color) : base(pos, fd, color) {}
        public CenteredText (Vector2 pos, FontData fontData, Color color, string text) : base(pos, fontData, color, text) {}
        public override void Center() {
            literalPosition = PaperUtils.CenterTextToPoint(position, fontData, text);
        }
    }

    public class CenteredTexture : CenteredObject {
        public Texture2D texture;
        public CenteredTexture(Vector2 pos, Texture2D texture) : base(pos) {
            this.texture = texture;
            Center();
        }
        public Texture2D GetTexture() {
            return texture;
        }
        public override void Center() {
            literalPosition = PaperUtils.CenterTextureToPoint(position, texture);
        }
        public override void Draw() {
            Raylib.DrawTexture(texture, (int)literalPosition.X, (int)literalPosition.Y, Color.WHITE);
        }
    }
}
