using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Nez;


namespace DndApp;

public class Biome
{

    public string Name;
    public string[] Events;
    public string[] Animals;
    public string[] Enemies;
    public string[] Buildings;
    public Climates ClimateType;
    public static List<Biome> BiomeList = new List<Biome>();
   // private static IEnumerable<string> Climate1 = File.ReadLines("ClimateFile1");

    public static void CreateNewBiome(string paintName, Climates climateType) =>
        BiomeList.AddIfNotPresent(new Biome(paintName, climateType));
    
    public Biome(string name, Climates climateType)
    {
        Name = name;
        ClimateType = climateType;
        if (BiomeList.AddIfNotPresent(this))
        {
            var EventFile = name + "_Events.txt";
            var AnimalsFile = name + "_Animals.txt";
            var BuildingFile = name + "_Buildings.txt";
            var EnemyFile = name + "_Enemies.txt";
            using(StreamWriter sw = File.AppendText(EventFile)) { sw.WriteLine(""); }
            using(StreamWriter sw = File.AppendText(AnimalsFile)) { sw.WriteLine(""); }
            using(StreamWriter sw = File.AppendText(BuildingFile)) { sw.WriteLine(""); }
            using(StreamWriter sw = File.AppendText(EnemyFile)) { sw.WriteLine(""); }

            Events = File.ReadAllLines(EventFile);
            Animals = File.ReadAllLines(AnimalsFile);
            Buildings = File.ReadAllLines(BuildingFile);
            Enemies = File.ReadAllLines(EnemyFile);
        }
    }

}


