﻿using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public NPC npc;

    public bool isTalking = false;

    public int curResponseTracker;

    public GameObject player;
    public GameObject dialogueUI;

    public Text npcName;
    public Text npcDialogueBox;
    public Text playerResponse;


    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
    }

    void StartConversation()
    {
        isTalking = true;
        dialogueUI.SetActive(true);
        curResponseTracker = 0;
        npcName.text = npc.name;
        npcDialogueBox.text = npc.dialogue[0];
    }

    void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        //começa a conversa
        if (Input.GetButtonDown("Interact") && isTalking == false)
        {
            StartConversation();
           
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            EndDialogue();
        }
        //anda pelas respostas pra frente na lista
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            ++curResponseTracker;

            if (curResponseTracker >= npc.playerDialogue.Length - 1)
            {
                
                //limita o fim da seleção de resposta
                curResponseTracker = npc.playerDialogue.Length - 1;
                
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            
            //senão anda pelas respostas pra tras na lista
            --curResponseTracker;
            if (curResponseTracker < 0)
            {
                
                //limita para nao diminuir de 0 as respostas
                curResponseTracker = 0;
                
            }
        }


        if (curResponseTracker == 0 && npc.playerDialogue.Length >= 0)
        {
            playerResponse.text = npc.playerDialogue[0];
            if (Input.GetButtonDown("Submit"))
            {
               
                npcDialogueBox.text = npc.dialogue[1];
            }
        }
        else if (curResponseTracker == 1 && npc.playerDialogue.Length >= 1)
        {
            playerResponse.text = npc.playerDialogue[1];
            if (Input.GetButtonDown("Submit"))
            {
             
                npcDialogueBox.text = npc.dialogue[2];
            }
        }
        else if (curResponseTracker == 2 && npc.playerDialogue.Length >= 2)
        {
            playerResponse.text = npc.playerDialogue[2];
            if (Input.GetButtonDown("Submit"))
            {
            
                npcDialogueBox.text = npc.dialogue[3];
            }
        }

    }


    void OnTriggerExit2D(Collider2D collision)
    {
      EndDialogue();
    }

   
   /* void OnMouseOver()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if(distance <= 2.5f)
        {
            if(Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                curResponseTracker++;
                if (curResponseTracker >= npc.playerDialogue.Length - 1)
                {
                    curResponseTracker = npc.playerDialogue.Length - 1;
                }
            }
            else if(Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                curResponseTracker--;
                if(curResponseTracker < 0)
                {
                    curResponseTracker = 0;
                }
            }
            //trigger dialogue
            if(Input.GetKeyDown(KeyCode.E) && isTalking==false)
            {
                StartConversation();
            }
            else if(Input.GetKeyDown(KeyCode.E) && isTalking == true)
            {
                EndDialogue();
            }

            if(curResponseTracker == 0 && npc.playerDialogue.Length >= 0)
            {
                playerResponse.text = npc.playerDialogue[0];
                if(Input.GetKeyDown(KeyCode.Q))
                {
                    npcDialogueBox.text = npc.dialogue[1];
                }
            }
            else if(curResponseTracker == 1 && npc.playerDialogue.Length >= 1)
            {
                playerResponse.text = npc.playerDialogue[1];
                if(Input.GetKeyDown(KeyCode.Q))
                {
                    npcDialogueBox.text = npc.dialogue[2];
                }
            }
            else if (curResponseTracker == 2 && npc.playerDialogue.Length >= 2)
            {
                playerResponse.text = npc.playerDialogue[2];
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    npcDialogueBox.text = npc.dialogue[3];
                }
            }

        }
    }*/
}