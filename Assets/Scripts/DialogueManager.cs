﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public NPC npc;

    bool isTalking = false;

    //float distance;
    float curResponseTracker = 0;

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
        curResponseTracker = 0;
        dialogueUI.SetActive(true);
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
         Debug.Log("Detected - Start Dialogue");
        }

        //anda pelas respostas pra frente na lista
        if (Input.GetButtonDown("SelecterPos"))
        {
        curResponseTracker++;
            if (curResponseTracker >= npc.playerDialogue.Length - 1)
            {
                //limita o fim da seleção de resposta
                curResponseTracker = npc.playerDialogue.Length - 1;
            }
        }
        //senão anda pelas respostas pra tras na lista
        else if (Input.GetButtonDown("SelecterNeg"))
        {
            curResponseTracker--;
            if (curResponseTracker < 0)
            {
                //limita para nao diminuir de 0 as respostas
                curResponseTracker = 0;
            }
        }
                     
           
            
            if (curResponseTracker == 0 && npc.playerDialogue.Length >= 0)
            {
            Debug.Log("Entrou no if do primeiro chat");    

            playerResponse.text = npc.playerDialogue[0];
            
            if (Input.GetButtonDown("Interact"))
            {
                Debug.Log("Detectou Interact");
                npcDialogueBox.text = npc.dialogue[1];
            }
            }
            else if (curResponseTracker == 1 && npc.playerDialogue.Length >= 1)
            {
                playerResponse.text = npc.playerDialogue[1];
                if (Input.GetButtonDown("KeyCode.Q"))
                {
                    npcDialogueBox.text = npc.dialogue[2];
                }
            }
            else if (curResponseTracker == 2 && npc.playerDialogue.Length >= 2)
            {
                playerResponse.text = npc.playerDialogue[2];
                if (Input.GetKey("KeyCode.Q"))
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