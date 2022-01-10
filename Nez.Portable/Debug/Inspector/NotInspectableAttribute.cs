using System;

namespace Nez
{
    /// <summary>
    /// Attribute that is used to indicate that the field/property should not be present in the inspector
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class NotInspectableAttribute : Attribute
    {
    }
}