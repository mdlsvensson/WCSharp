# WCSharp

**WCSharp** is a collection of libraries for C# development of custom maps and mods for Warcraft III. With these libraries you can **write map logic in C#** and transpile it into Lua code that the game engine can understand.

**Advantages of WCSharp over Lua (or Jass):**
* **Better Code:** C# is natively object-oriented, enabling cleaner, more maintainable code.
* **Type Safety:** Static typing prevents bugs during development, without the need for EmmyLua annotations.
* **IDE:** Write Warcraft III map logic in Visual Studio.
* **Built in Systems:** WCSharp has several [built in features for common systems](https://github.com/Orden4/WCSharp/wiki).

## Getting Started

### Requirements

* **C# development environment** (like **Visual Studio**):
	* When installing Visual Studio, make sure you select **Desktop & Mobile > .NET Desktop Development**.
	* If you've installed Visual Studio previously you can launch the **Visual Studio Installer** and **Modify** your installation instead.
	* WCSharp is built for .NET 6 and requires **Visual Studio 17.0 or higher**.

### Installation

1. Download the [WCSharp template](https://github.com/Orden4/WCSharp/wiki/WCSharp-template).
2. Open `WCSharpTemplate.sln` with Visual Studio and right click the `Launcher` project and select `Set as Startup Project`.
3. Right click the `Launcher` project and click `Manage NuGet Packages`. Update all NuGet packages.
4. Set the path to your Warcraft III executable in `Launcher/app.config`.
5. Set the `BASE_MAP_PATH` in `Launcher/Program.cs` to the path of your saved map-folder.
6. Move the included `Blizzard.j` and `common.j` files to `C:\Users\[Username]\My Documents\Warcraft III\JassHelper`.
7. Run the `Launcher` project in Visual Studio.

### Map Setup

1. Drag-and-drop the source.w3x folder onto an open World Editor window to open the template map.
2. Go to the Object Editor and copy the Dummy unit.
3. Create a new map (or open an existing map) and paste the Dummy unit into the Object Editor.
4. Go to **Scenario > Map Options** and set the Script Language to Lua.
5. Save your map as **Warcraft III Scenario Folder - Expansion**.

## WCSharp.API

**WCSharp** features a [dedicated API](https://github.com/Orden4/WCSharp/wiki/WCSharp.Api), serving as a replacement for War3Api. It provides an intuitive way of interacting with Warcraft III handles.

```cs
// War3Api
var unit = CreateUnit("hfoo", Player(0), 0, 0, 270); // Create a unit
SetUnitState(unit, UNIT_STATE_MANA, GetUnitState(unit, UNIT_STATE_MANA) + 50); // Increase its mana by 50
KillUnit(unit); // Kill the unit

// WCSharp.Api
var unit = unit.Create("hfoo", Player(0), 0, 0, 270); // constructor support will be added in the future, there's a bug with CSharpLua for the time being
unit.Mana += 50;
unit.Kill();
```

## Documentation

Each individual system is documented in the [wiki](https://github.com/Orden4/WCSharp/wiki). The code includes Visual Studio XML documentation comments, allowing quick access by hovering code elements in your IDE.

## Contribute

We welcome contributions from the community to help improve WCSharp. If you encounter any bugs, have suggestions for new features, or want to help improve the code, feel free to open a [new issue](https://github.com/Orden4/WCSharp/issues) or submit a pull request.
