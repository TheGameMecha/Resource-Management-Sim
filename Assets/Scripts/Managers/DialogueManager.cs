using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    public static DialogueManager Instance { get; private set; }
    [SerializeField]
    private bool dontDestroyOnLoad = true;

    public DialogueConversation currentConversation;
    public GameObject dialogueBoxPrefab;

    // Called on object creation
    void Awake()
    {
        // Singleton pattern
        // Makes sure there is only ever one GameManager object
        // Since we store data in this, we need to make sure it is used in the preload scene ONLY
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Warning: multiple " + this + " in scene!");
            Destroy(gameObject);
        }

        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(gameObject); // Keep the only manager alive across scenes
        }
    }

    public void StartConversation()
    {
        PlayDialogue(0);
    }
    public void PlayDialogue(int index)
    {
        GameObject go = Instantiate(dialogueBoxPrefab);
        DialogueBox db = go.GetComponent<DialogueBox>();
        db.dialogueId = index;
        db.CreateMessage(MessageType.Message, currentConversation.dialogues[index].message);
        db.SetSpeaker(currentConversation.dialogues[index].speakerName, currentConversation.dialogues[index].speakerPortrait);
    }
}