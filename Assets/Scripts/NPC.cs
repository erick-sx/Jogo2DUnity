using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NPC file", menuName = "NPC Files Archive", order = 0)]

public class NPC : ScriptableObject {
    public string name;
    [TextArea(4, 20)]
    public string[] dialogue;
    [TextArea(4,20)]
    public string[] playerDialogue;
}
