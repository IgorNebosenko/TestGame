using UnityEngine;
using Core.Enums;

public class ClickColorData
{
    /// <summary>
    /// Type of object
    /// </summary>
    public ETypeObject ObjectType { get; private set; }
    /// <summary>
    /// Minimal clicks count
    /// </summary>
    public int MinClicksCount { get; private set; }
    /// <summary>
    /// Maximum clicks count
    /// </summary>
    public int MaxClicksCount { get; private set; }
    /// <summary>
    /// Color of object
    /// </summary>
    public Color ColorObject { get; private set; }

    public ClickColorData(ETypeObject typeObject, int minClicksCount, int maxClicksCount, Color colorObject)
    {
        ObjectType = typeObject;
        MinClicksCount = minClicksCount;
        MaxClicksCount = maxClicksCount;
        ColorObject = colorObject;
    }
}
