using System.IO;

namespace DndApp;

public static class FileLocations
{
    private static readonly string Root = Path.GetFullPath(Path.Combine(ContentFolder, @"..\"));
    private static string ContentFolder => Nez.Core.Content.RootDirectory;
    private static string AssetFiles=> ContentFolder + @"Assets\";
    private static string SpriteFiles=> AssetFiles + @"Sprites\";
    private static string MapFiles=> AssetFiles + @"Maps\";
    private static string Images=> AssetFiles + @"Images\";
    public static string LocationImages1 { get; set; }
    public static string QML => Root + @"Work\QML\";
    public static string Map { get; set; }
    public static string Party{ get; set; }
    public static void SetToDefaultFileLocations()
    {
        Map   = MapFiles + "map1.jpg";
        Party = SpriteFiles + "party.png";
        LocationImages1 = Images + "Forrest1.jpg";
    }

}
