using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace DndApp;
 
/*int hour = date.Hour;
int day = date.Day;
int month = date.Month;
int year = date.Year;
//day=hour+24hours;

var x = System.DateTime.DaysInMonth(1,1);
var c = new DateTime(10, 1, 1, 1, 0, 0);
c = c.Add(new TimeSpan(1,0,0));
var test = c.Date;
c.Add(new TimeSpan(1, 0, 0));*/
/*month={
    0-31(24hours)
        0-28/29(24hours)
            0-31(24hours)
                0-30(24hours)
                }*/
// year = day + 365;
public static class Climate
{
    private static readonly string[] lines = StringTest.dec1.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
    public static readonly Dictionary<DateTime, string> Data1 = new();
    static Climate(/*DateTime date*/)
    {
        foreach (var line in lines)
        { 
            if (line.Length < 5) { continue; }
            var splitUpLine = line.Split(',');
            DateTime date = DateTime.Parse(splitUpLine[0]); 
            date = date.AddHours(int.Parse(splitUpLine[1])); 
            Data1.Add(key: date, value: $"{splitUpLine[1]} {splitUpLine[2]} {splitUpLine[3]} {splitUpLine[4]} {splitUpLine[5]} {splitUpLine[6]} {splitUpLine[7]} {splitUpLine[8]}");
        }
    }

}