# PaperSDL
## Small software library, designed to make using Raylib-CS simpler and more concise. https://github.com/ChrisDill/Raylib-cs

### Example Usage:

First create a new dotnet console project: ```dotnet new console```

Clone this repository: ```git clone https://github.com/thyliverman/PaperSDL.git```

Then inside the **project directory**, add this repo as a reference: ```dotnet add reference path/to/this/repo```

```
using System;
using PaperSDL;
using Raylib_cs;

class Program : PaperApp
{
    public static int windowWidth = 1280;
    public static int windowHeight = 720;

    public Program() : base(windowWidth, windowHeight, "Title") {}

    static void Main(string[] args)
    {
        new Program();
    }

    public override void Start() {
        Raylib.SetTargetFPS(60);
    }

    public override void Draw()
    {
        Raylib.ClearBackground(Color.WHITE);
    }
}
```
