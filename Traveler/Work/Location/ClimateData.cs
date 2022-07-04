using System;
using System.Collections.Generic;

namespace Traveler;



public static class ClimateData
{
    private static readonly IReadOnlyList<string> DeciduousData = StringTest.dec1.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

    //TEMP CURRENTLY DUPLICATES OF dec1 
    private static readonly IReadOnlyList<string> GrasslandData = StringTest.dec1.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    private static readonly IReadOnlyList<string> DesertData = StringTest.dec1.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    private static readonly IReadOnlyList<string> TundraData = StringTest.dec1.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    private static readonly IReadOnlyList<string> TemperateData = StringTest.dec1.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    private static readonly IReadOnlyList<string> RainForestData = StringTest.dec1.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    private static readonly IReadOnlyList<string> SavannaForestData = StringTest.dec1.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    private static readonly IReadOnlyList<string> PolarForestData = StringTest.dec1.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

    public static IReadOnlyList<string> Get(string climate)
    {
        return climate switch
        {
            "Deciduous" => DeciduousData,
            "Grassland"=> GrasslandData,
            "Desert"=> DesertData,
            "Tundra"=> TundraData,
            "Temperate"=> TemperateData,
            "RainForest"=> RainForestData,
            "Savanna"=> SavannaForestData,
            "Polar"=> PolarForestData,
            _ => null
        };
    }

}