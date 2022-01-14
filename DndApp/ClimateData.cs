using System;
using System.Collections.Generic;
using System.Linq;
using Nez;

namespace DndApp;

public class Climate
{
    private static readonly string[] lines = StringTest.dec1.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
    private static Dictionary<DateTime, string> Data1 = new();


    public static void WeatherDataFor(/*DateTime date*/)
    {


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

        foreach (var line in lines)
        {
            var splitUpLine = line.Split(',');
            DateTime date = DateTime.Parse(splitUpLine[0]);
            var hour = int.Parse(splitUpLine[0])-1;
            date = date.AddHours(hour);
            Data1.Add(date, splitUpLine[1]+splitUpLine[2]+splitUpLine[3]+splitUpLine[4]+splitUpLine[5]+splitUpLine[6]+splitUpLine[7]+splitUpLine[8]);
        }

        var t = lines[0];




        /*month={
            0-31(24hours)
                0-28/29(24hours)
                    0-31(24hours)
                        0-30(24hours)
                        }*/
       // year = day + 365;
    }

}
