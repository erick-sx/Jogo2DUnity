﻿using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public bool isTalking = false;

    public GameObject player;
    public GameObject QuestionUI;
    public GameObject AnswerUI;



    // Start is called before the first frame update
    void Start()
    {
        QuestionUI.SetActive(false);
    }

    void StartConversation()
    {
        isTalking = true;
        QuestionUI.SetActive(true);

    }

    void EndDialogue()
    {
        isTalking = false;
        QuestionUI.SetActive(false);
        AnswerUI.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        //começa a conversa
        if (Input.GetButtonDown("Interact") && isTalking == false)
        {
            StartConversation();
           
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