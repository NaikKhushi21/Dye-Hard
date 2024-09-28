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
        { "Brown", new Color(0.65f, 0.16f, 0.16f, 1f) }
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
        BlendedColorsMap["Brown"],
    };

    // Primary Colors List
    public static List<Color> PrimaryColors = new List<Color>
    {
        Color.red,
        Color.yellow,
        Color.blue
    };

    // Blended Colors List
    public static List<Color> BlendedColors = new List<Color>
    {
        Color.green,
        new Color(1f, 0.5f, 0f, 1f), // Orange
        new Color(1f, 0f, 1f, 1f),   // Purple
        new Color(0.65f, 0.16f, 0.16f, 1f) // Brown
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