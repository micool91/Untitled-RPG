using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Dialogue
{
    public class AIConversant : MonoBehaviour
    {
        private bool canActiavate;

        [SerializeField] Dialogue dialogue = null;
        [SerializeField] string conversantName;

        public string GetName()
        {
            return conversantName;
        }

        void Update()
        {
            if (dialogue == null)
            {
                // return falmse
            }
            else
            {
                if(canActiavate && Input.GetButtonDown("Fire1"))
                {
                    //DialogManager.instance.ShowDialog(lines, isPerson);
                    //DialogManager.instance.ShouldActivateQuestAtEnd(questToMark, markComplete);
                    //Debug.Log("It speaks...");
                    canActiavate = false;
                    var pc = GameObject.
                        FindGameObjectWithTag("Player").
                        GetComponent<PlayerConversant>();
                    pc.StartDialogue(this, dialogue);
                }
            }
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "Player")
            {
                canActiavate = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.tag == "Player")
            {
                canActiavate = false;
            }
        }

        // there are no reycast interface at the moment
        // public bool HandleRaycast(PlayerController callingController)
        // {
        //     if (Input.GetMouseButtonDown(0))
        //     {
        //         Debug.Log("Conversation Started!");
        //     }

        //     return true;
        // }

    }
}
