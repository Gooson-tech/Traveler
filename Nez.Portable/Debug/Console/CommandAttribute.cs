using System;

namespace Nez.Console
{
    /// <summary>
    /// add this attribute to any static method
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class CommandAttribute : Attribute
    {
        public string Name;
        public string Help;


        public CommandAttribute(string name, string help)
        {
            Name = name;
            Help = help;
        }
    }
}