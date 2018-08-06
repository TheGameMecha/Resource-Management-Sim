using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum MessageType { Error, Warning, Message };

public class Message : MonoBehaviour {

    [Header("UI Elements")]
    [SerializeField]
    private Text messageText;
    [SerializeField]
    private Image panel;

    [Header("Colours")]
    [SerializeField]
    private Color errorColor;
    [SerializeField]
    private Color warningColor;
    [SerializeField]
    private Color otherColor;

    void Awake()
    {
        // Make sure the canvas elements exist
        if (messageText == null || panel == null)
        {
            Debug.LogWarning("Message not instantiated: missing UI elements");
            Destroy(gameObject);
        }
    }
    public void CreateMessage(MessageType type, string message)
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

    public void KillMessage()
    {
        Destroy(gameObject);
    }
}