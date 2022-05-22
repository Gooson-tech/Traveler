using System;
using System.Collections.Generic;

namespace DndApp;



public static class ClimateData
{
    private static readonly IReadOnlyList<string> DeciduousData = StringTest.dec1.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

    //TEMP CURRENTLY DUPLICATES OF dec1 
    private static readonly IReadOnlyList<string> GrasslandData = StringTest.dec1.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    private static readonly IReadOnlyList<string> DesertData = StringTest.dec1.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    private static readonly IReadOnlyList<string> TundraData = StringTest.dec1.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    private static readonly IReadOnlyList<string> TemperateData = StringTest.dec1.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    private static readonly IReadOnlyList<string> RainForestData = StringTest.dec1.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    public static IReadOnlyList<string> Get(Climate climate)
    {
        return climate switch
        {
            Climate.Deciduous => DeciduousData,
            Climate.Grassland => GrasslandData,
            Climate.Desert => DesertData,
            Climate.Tundra => TundraData,
            Climate.Temperate => TemperateData,
            Climate.RainForest => RainForestData,
            _ => null
        };
    }
}