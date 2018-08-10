using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

    public string speakerName;
    public Sprite speakerPortrait;
    public string message;

    public Dialogue(string name, Sprite portrait, string text)
    {
        speakerName = name;
        speakerPortrait = portrait;
        message = text;
    }
}