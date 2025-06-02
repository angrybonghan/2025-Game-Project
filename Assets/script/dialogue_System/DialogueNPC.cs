using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    public DialogueDataSO myDialogue;

    private DialogueMananger dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueMananger>();

        if (dialogueManager == null)
        {
            Debug.LogError("not Have Dialogue Mananger");
        }
    }
    private void OnMouseDown()
    {
        if (dialogueManager == null) return;
        if ( dialogueManager.IsDialogueActive()) return;
        if (myDialogue == null) return;

        dialogueManager.StartDialogue(myDialogue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
