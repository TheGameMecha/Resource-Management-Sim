using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum MessageType { Error, Warning, Message };

public class Message : MonoBehaviour {

    [Header("Colours")]
    [SerializeField]
    public Color errorColor;
    [SerializeField]
    public Color warningColor;
    [SerializeField]
    public Color otherColor;

    [Header("UI Elements")]
    [SerializeField]
    public Text messageText;
    [SerializeField]
    public Image panel;

    void Awake()
    {
        // Make sure the canvas elements exist
        if (messageText == null || panel == null)
        {
            Debug.LogWarning("Message not instantiated: missing UI elements");
            Destroy(gameObject);
        }
    }
    public virtual void CreateMessage(MessageType type, string message)
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