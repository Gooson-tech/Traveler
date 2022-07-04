using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Int32;
using static System.String;
using static System.StringComparison;
using Component = Nez.Component;

namespace Traveler;

public class Biome : Component
{
    public static readonly IDictionary<string, Biome> Cached =
        new Dictionary<string, Biome>(StringComparer.OrdinalIgnoreCase);

    public string Name { get; set; }
    private ChanceTable Events;
    private ChanceTable Animals;
    private ChanceTable Enemies;
    private ChanceTable Structures;
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


    public Biome(string events, string animals, string enemies, string structures, string climate, string name)
    {
        if (Cached.ContainsKey(name))
            return;

        Name = name;

        //Events = File.ReadAllLines(FileLocations.Events + events);
        //Animals = File.ReadAllLines(FileLocations.Animals + animals);
        //Structures = File.ReadAllLines(FileLocations.Structures + structures);
        //Enemies = File.ReadAllLines(FileLocations.Enemies + enemies);

        Events = new ChanceTable(FileLocations.Events + events);
        Animals = new ChanceTable(FileLocations.Animals + animals);
        Enemies = new ChanceTable(FileLocations.Enemies + enemies);
        Structures = new ChanceTable(FileLocations.Structures + structures);
        Climate = ClimateData.Get(climate);

        Cached.Add(name, this);
    }
}

public class ChanceTable
{
    private readonly List<string> TableElements = new();
    private readonly List<int> DayRollTable = new();
    private readonly List<int> NightRollTable = new();

    private readonly int r= 0;

    public ChanceTable(string path)
    {
        List<string> Text = File.ReadAllLines(path)
            .Select(x => Concat(x.Where(c => !char.IsWhiteSpace(c))))
            .Select(x => x.Replace("\t", Empty, OrdinalIgnoreCase))
            .Where(x => x != Empty 
                           && x.First() != '#' 
                           && !string.Equals(x, "{", OrdinalIgnoreCase) 
                           && !string.Equals(x, "}", OrdinalIgnoreCase)).ToList();
        Setup(Text);
    }

    private int GetElementAt(Climate climate, DateTime date) 
        {
        //rainforest 4-19,
        //
        if (climate.Equals(Climate.Polar))
        {

        }
        if (climate.Equals(Climate.Tundra))
        {

        }
        if (climate.Equals(Climate.Deciduous))
        { 

        }
        if (climate.Equals(Climate.Grassland))
        {

        }

        if (climate.Equals(Climate.Temperate))
        {

        }
        if (climate.Equals(Climate.RainForest))
        {

        }
        if (climate.Equals(Climate.Desert))
        {

        }
        if (climate.Equals(Climate.Savanna))
        {

        }

       


        return 0;
        }
    private int GetDayElement() => DayRollTable[Nez.Random.NextInt(DayRollTable.Count)];
    private int GetNightElement()=> NightRollTable[Nez.Random.NextInt(NightRollTable.Count)];

    private void Setup(IEnumerable<string> text)
    {
        int day = 1, night = 1;
        static string[] CleanSplitLine(string line) => line.Replace("*", Empty, OrdinalIgnoreCase).Split(',');

        foreach (var line in text)
        {
            if (line[0].Equals('*'))
               (day, night) = GetDayAndNight(CleanSplitLine(line)); // *5, *4
                                                                     // sets default Day and Night to what is declared on the line,
                                                                     // (all following declarations in text use this as default)
            else if (line.Contains('*', OrdinalIgnoreCase)) //if the start of the line is not *number than only case left is ex. dog *5, *5 (SpecifiedDeclaration)
                OneSpecifiedDeclaration(CleanSplitLine(line)); // Dog, *5, *5 

            else if (line.Contains(',', OrdinalIgnoreCase) && line.Split(',').Count() > 1)
                MultipleDefaultDeclaration(day, night, line); // Dog, Cat, Hamster (using LAST SET day and night)
            else
                OneDefaultDeclaration(day, night, (line.Trim(',')) );
        }
    }
    public void SetDayAndNightTable(int day, int night, int index)
    {
        for (var i = 0; i < day; i++)
            DayRollTable.Add(index);
        for (var i = 0; i < night; i++)
            NightRollTable.Add(index);
    }

    private int _lastIndex = MinValue;
    private string _lastLine= Empty;
    private void OneDefaultDeclaration(int day, int night, string line)
    {
        if (line.Equals(_lastLine))
            SetDayAndNightTable(day, night, _lastIndex); 

        TableElements.Add(line);
        var animalIndex = TableElements.Count - 1;
        SetDayAndNightTable(day, night, animalIndex);
        _lastLine = line;
        _lastIndex = TableElements.Count - 1;
    }
    private void MultipleDefaultDeclaration(int day, int night, string line) 
    {
        foreach (var element in line.Split(','))
        {
            TableElements.Add(element); 
            SetDayAndNightTable(day, night, TableElements.Count - 1);
        }
    }
    private void OneSpecifiedDeclaration(string[] splitUpLine)
    {
        var name = splitUpLine[0];

        TableElements.Add(name);
        var thisAddedElementsIndex  = TableElements.Count - 1;
        var day = Parse(splitUpLine[1]);

        if (splitUpLine.Count() > 2) // dog *5, *4
        {
            var night = Parse(splitUpLine[2]);
            SetDayAndNightTable(day, night, thisAddedElementsIndex);
        }
        else //dog *5 ==> dog *5, *5
            SetDayAndNightTable(day, day, thisAddedElementsIndex);

    }
    private (int dayIndex, int nightIndex) GetDayAndNight(string[] t) 
    {
        int dayIndex = Parse(t[0]);
        int nightIndex = t.Skip(1).Any() 
            ? Parse(t[1])
            : dayIndex;
        return (dayIndex, nightIndex);
    }
}