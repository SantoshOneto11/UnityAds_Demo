using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SelectableData", menuName = "Scriptable/Playerdata", order = 1)]
public class PlayerData : ScriptableObject
{
    public List<Data> gameData;
}

[Serializable]
public class Data
{
    public Sprite playerImage;
    public string playerName;
    public string speed;
    public string health;
    public string power;
}
