using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;
    private List<string> keys = new List<string>();

    void Awake() { instance = this; }

    public void AddKey(string keyMansion) { keys.Add(keyMansion); }

    public bool HasKey(string keyMansion) { return keys.Contains(keyMansion); }
}