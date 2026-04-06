using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;
    private List<string> keys = new List<string>();

    void Awake() { instance = this; }

    public void AddKey(string keyMansion) { keys.Add(keyMansion); }

    public bool HasKey(string keyMansion) { return keys.Contains(keyMansion); }


    public void AddKeyPurple(string keyPurple) { keys.Add(keyPurple); }

    public bool HasKeyPurple(string keyPurple) { return keys.Contains(keyPurple); }


    public void AddKeyBlue(string keyBlue) { keys.Add(keyBlue); }

    public bool HasKeyBlue(string keyBlue) { return keys.Contains(keyBlue); }


}
