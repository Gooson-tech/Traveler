using System.IO;

namespace Traveler;

public static class FileLocations
{
    private static string Root => Path.GetFullPath(Path.Combine(ContentFolder, @"..\")) ?? "_ ";
    private static string ContentFolder => Nez.Core.Content==null ? "_ " : Nez.Core.Content.RootDirectory;

    private static readonly string AssetFiles= ContentFolder + @"Assets\";
    private static readonly string SpriteFiles= AssetFiles + @"Sprites\";
    private static readonly string MapFiles= AssetFiles + @"Maps\";
    private static readonly string Images= AssetFiles + @"Images\";
    public static readonly string QML = Root + @"Work\QML\";  
    public static readonly string Biomes = Root + @"\Biomes\";
    public static readonly string Animals = Biomes + @"Animals\";
    public static readonly string Events = Biomes + @"Events\";
    public static readonly string Structures = Biomes + @"Structures\";
    public static readonly string Enemies = Biomes + @"Enemies\";


    public static string LocationImages { get; set; }
    public static string Map { get; private set; }
    public static string Party{ get; private set; }

    public static string UIFiles => AssetFiles + @"UI\";
    public static void SetToDefaultFileLocations()
    {
        Map = MapFiles + "map2.jpg";
        Party = SpriteFiles + "party.png";
        LocationImages = Images + "Forrest1.jpg";
    }

}
