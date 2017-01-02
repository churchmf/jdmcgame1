using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PartListJson
{
    public List<PartJson> parts;
}

[Serializable]
public class PartJson
{
    public string name;
    public string slot;
    public int energy;
    public int defense;
    public int strength;
    public int speed;
    public string color;
}

public class Part
{
    public string Name;
    public SlotEnum Slot;
    public int Energy;
    public int Defense;
    public int Strength;
    public int Speed;
    public Color Color;
}

public class PartsManager {

    #region Singleton
    private static PartsManager m_instance;
    public static PartsManager GetInstance()
    {
        if (m_instance == null)
        {
            m_instance = new PartsManager();
        }
        return m_instance;
    }
    #endregion 

    private const string DefaultPartsResource = "parts";
    private IList<Part> m_PartList;

    private PartsManager()
    {
        m_PartList = new List<Part>();
        LoadParts(DefaultPartsResource);
    }

    private void LoadParts(string resourceFile)
    {
        var targetFile = Resources.Load<TextAsset>(resourceFile);
        var partListJson = JsonUtility.FromJson<PartListJson>(targetFile.text);

        foreach(var part in partListJson.parts)
        {
            m_PartList.Add(new Part()
            {
                Name = part.name,
                Energy = part.energy,
                Defense = part.defense,
                Strength = part.strength,
                Speed = part.speed,
                Slot = (SlotEnum)Enum.Parse(typeof(SlotEnum), part.slot, true),
                Color = ParseColor(part.color)
            });
        }
    }

    private Color ParseColor(string color)
    {
        switch (color)
        {
            case "black":
                return Color.black;
            case "red":
                return Color.red;
        }
        throw new ArgumentOutOfRangeException(String.Format("Unsupported color {0}", color));
    }

    public IEnumerable<Part> GetParts()
    {
        return m_PartList;
    }
}
