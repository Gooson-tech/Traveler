using System;
using System.Collections.Generic;
using System.IO;
using Nez;

namespace Traveler;
public class Biome : Component
{
    public static readonly IDictionary<string, Biome> Cached =
        new Dictionary<string, Biome>(StringComparer.OrdinalIgnoreCase);

    public string Name { get; set; }
    private readonly IReadOnlyList<string> Events;
    private readonly IReadOnlyList<string> Animals;
    private readonly IReadOnlyList<string> Enemies;
    private readonly IReadOnlyList<string> Buildings;
    public IReadOnlyList<string> Climate { get; set; }
    public string GetClimateAt(int index)
    {
        //looped around indexing of ClimateData
        var total = Climate.Count;
        var remainder = index switch
        {
            /* get the reverse index */
            < 0 => (total - Math.Abs(index % total)) % total,
            _ => index % total
        };

        return Climate[remainder];
    }  
   
    // NOTE TO SELF, GET ALL EVENT names From Event file and then create Dtable from each
    // new event(string) for each event file
    // Event get total number of lines and randomly choose line from file
    // Print Events in order of declared(so in a list)
    // Random terrain should be semi deterministic=> by default should just be typical biomeTerrain (possibly this is settup in biomeTemplate)
    public Biome(string name, Climate climate)
    {
        Name = name; 
        var eventFile = name    + "_Events.txt";
        var animalsFile = name  + "_Animals.txt";
        var buildingFile = name + "_Buildings.txt";
        var enemyFile = name    + "_Enemies.txt";

        using (var sw = File.AppendText(eventFile))    { sw.Write(""); }
        using (var sw = File.AppendText(animalsFile))  { sw.Write(""); }
        using (var sw = File.AppendText(buildingFile)) { sw.Write(""); }
        using (var sw = File.AppendText(enemyFile))    { sw.Write(""); }

        Events = File.ReadAllLines(eventFile);
        Animals = File.ReadAllLines(animalsFile);
        Buildings = File.ReadAllLines(buildingFile);
        Enemies = File.ReadAllLines(enemyFile);

        Climate = ClimateData.Get(climate);
        Cached.Add(name, this);
    }
  
}