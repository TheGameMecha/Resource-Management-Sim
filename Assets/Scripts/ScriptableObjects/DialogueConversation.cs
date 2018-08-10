using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Conversation", menuName = "Game Data/Conversation", order = 1)]
public class DialogueConversation : ScriptableObject
{
    public int conversationID;
    public Dialogue[] dialogues;
}