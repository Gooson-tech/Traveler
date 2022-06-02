using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace Traveler;
public static class Date
{
    public static int TimeIndex(IReadOnlyList<string> climateData, uint year, uint month, uint day, double hour)
    {
        var startDate = StartDate(climateData);
        var currentDate = new DateTime(
            (int)(year + startDate.Year - 1),
            (int)month + startDate.Month - 1, 
            (int)day + startDate.Month - 1);

        currentDate = currentDate.AddHours(hour);
        return (int)(currentDate - startDate).TotalHours;
    }
    private static DateTime StartDate(IReadOnlyList<string> data)
    {
        var firstString = data[0];
        var startDate = DateTime.Parse(firstString.Split(',')[0], default);
        var firstHour = int.Parse(firstString.Split('-')[2].Split(',')[1].Split(":")[0], NumberStyles.Integer,default);
        startDate = startDate.AddHours(firstHour);
        return startDate;
    }
}
