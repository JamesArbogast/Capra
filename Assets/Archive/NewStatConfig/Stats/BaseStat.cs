using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class BaseStat {

    private string name;
    private string description;
    private int baseValue;
    private int modifiedValue;
    private StatTypes statTypes;

    public enum StatTypes
    {
        HEALTHPOINTS,
        ZULIUMPOINTS,
        SPEED,
        PHYSATTACK,
        PHYSDEFENSE,
        DODGE,
        ZULIUMATTACK,
        ZULIUMDEFENSE,
        ZULIUMHEAL,
        RESIST,
        ENERGY,
        INTELLIGENCE,
        LUCK

    }

    public string StatName
    {
        get { return name; }
        set { name = value; }
    }
    public string StatDescription
    {
        get { return description; }
        set { description = value; }
    }
    public int StatBaseValue
    {
        get { return baseValue; }
        set { baseValue = value; }
    }
    public int StatModifiedValue
    {
        get { return modifiedValue; }
        set { modifiedValue = value; }
    }
    public StatTypes StatType
    {
        get { return statTypes; }
        set { statTypes = value; }
    }
   
}
