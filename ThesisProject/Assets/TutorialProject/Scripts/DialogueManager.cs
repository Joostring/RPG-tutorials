using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance {  get; private set; }

    private bool inDialogue;
    private bool isCharacterTyping;
    private Queue<SO_Dialogue.Info> dialogueQueue;
    private string completeString;
    [SerializeField] private float textDelay = 0.1f;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] GameObject dialogueBox;

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        dialogueQueue = new Queue<SO_Dialogue.Info>();
    }

   
    private void OnInteract() { if (inDialogue) { DequeueDialogue(); } }

    public void QueueDialogue(SO_Dialogue dialogue) 
    {
        if(inDialogue) { return; }

        GameObject.FindWithTag("Champion").GetComponent<PlayerInput>().enabled = false;
        inDialogue = true;
        dialogueBox.SetActive(true);

        

        dialogueQueue.Clear();
        foreach(SO_Dialogue.Info line in dialogue.dialogueInfo)
        {
            dialogueQueue.Enqueue(line);
        }

        DequeueDialogue();
    }

    private void DequeueDialogue() 
    {
        if(isCharacterTyping) 
        {
            CompleteText();
            StopAllCoroutines();
            isCharacterTyping = false;
            return; 
        }
        if (dialogueQueue.Count == 0) 
        {
            EndDialogue();
            return;
        }
        SO_Dialogue.Info info = dialogueQueue.Dequeue();
        completeString = info.dialogue;
        dialogueText.text = "";
        StartCoroutine(TypeText(info));
    
    }

    private void EndDialogue()
    {
        dialogueBox.SetActive(false);
        inDialogue = false;
        GameObject.FindWithTag("Champion").GetComponent<PlayerInput>().enabled = true;
    }
    private void CompleteText()
    {
        dialogueText.text = completeString;
    }


    IEnumerator TypeText(SO_Dialogue.Info info)
    {
        isCharacterTyping = true;
        foreach(char c in info.dialogue.ToCharArray())
        {
            yield return new WaitForSeconds(textDelay);
            dialogueText.text += c;
        }
        isCharacterTyping = false;
    }
   

}
