using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorManager
{
    public static Dictionary<string, Color> PrimaryColorsMap = new Dictionary<string, Color>
    {
        { "Red", Color.red },
        { "Yellow", Color.yellow },
        { "Blue", Color.blue }
    };

    public static Dictionary<string, Color> BlendedColorsMap = new Dictionary<string, Color>
    {
        { "Green", Color.green },
        { "Orange", new Color(1f, 0.5f, 0f, 1f) },
        { "Purple", new Color(1, 0, 1, 1) },
        { "Black", Color.black }
    };

    public static HashSet<Color> PrimaryColorsSet = new HashSet<Color>
    {
        PrimaryColorsMap["Red"],
        PrimaryColorsMap["Yellow"],
        PrimaryColorsMap["Blue"],
    };

    public static HashSet<Color> BlendedColorsSet = new HashSet<Color>
    {
        BlendedColorsMap["Green"],
        BlendedColorsMap["Orange"],
        BlendedColorsMap["Purple"],
        BlendedColorsMap["Black"],
    };

    public static Dictionary<Color, HashSet<Color>> BlendedColorConstitutions = new Dictionary<Color, HashSet<Color>>
    {
        { BlendedColorsMap["Green"], new HashSet<Color> { PrimaryColorsMap["Yellow"], PrimaryColorsMap["Blue"] } },
        { BlendedColorsMap["Orange"], new HashSet<Color> { PrimaryColorsMap["Red"], PrimaryColorsMap["Yellow"] } },
        { BlendedColorsMap["Purple"], new HashSet<Color> { PrimaryColorsMap["Red"], PrimaryColorsMap["Blue"] } },
        { BlendedColorsMap["Black"], new HashSet<Color> { PrimaryColorsMap["Red"], PrimaryColorsMap["Yellow"], PrimaryColorsMap["Blue"] } }
    };

    public static Dictionary<Color, Color> ComplementaryColorMap = new Dictionary<Color, Color>
    {
        { PrimaryColorsMap["Red"], BlendedColorsMap["Green"] },
        { PrimaryColorsMap["Yellow"], BlendedColorsMap["Purple"] },
        { PrimaryColorsMap["Blue"], BlendedColorsMap["Orange"] },
    };

    // Primary Colors List
    public static List<Color> PrimaryColors = new List<Color>
    {
        PrimaryColorsMap["Red"],
        PrimaryColorsMap["Yellow"],
        PrimaryColorsMap["Blue"],
    };

    // Blended Colors List
    public static List<Color> BlendedColors = new List<Color>
    {
        BlendedColorsMap["Green"],
        BlendedColorsMap["Orange"],
        BlendedColorsMap["Purple"],
        BlendedColorsMap["Black"],
    };

    // All Colors List (combining primary and blended colors)
    public static List<Color> AllColors = new List<Color>(PrimaryColors.Count + BlendedColors.Count);

    // Static constructor to populate the AllColors list
    static ColorManager()
    {
        // Add primary and blended colors to the AllColors list
        AllColors.AddRange(PrimaryColors);
        AllColors.AddRange(BlendedColors);
    }
}