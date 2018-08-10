using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : Message {

    [SerializeField]
    private Image characterPortrait;
    [SerializeField]
    private Text characterName;

    [HideInInspector]
    public int dialogueId;

    public override void CreateMessage(MessageType type, string message)
    {
        messageText.text = message;

        switch (type)
        {
            case MessageType.Error:
                panel.color = errorColor;
                break;
            case MessageType.Warning:
                panel.color = warningColor;
                break;
            default:
                panel.color = otherColor;
                break;
        }
    }

    public void SetSpeaker(string name, Sprite image)
    {
        characterName.text = name;
        characterPortrait.sprite = image;
    }

    public void NextMessage()
    {
        if (dialogueId >= DialogueManager.Instance.currentConversation.dialogues.Length - 1)
        {
            return;
        }
        DialogueManager.Instance.PlayDialogue(dialogueId + 1);
    }
}