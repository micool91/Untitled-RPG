using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RPG.Dialogue
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] string action;
        [SerializeField] UnityEvent onTrigger;

        public void Trigger(string actionToTrigger)
        {
            //Debug.Log($"{name} is testing trigger {actionToTrigger}.  This trigger = {action}.");
            if (actionToTrigger == action)
            {
                //Debug.Log($"{actionToTrigger}=={action}.   Condition matches");
                onTrigger.Invoke();
                Debug.Log(action);
            }
        }
    }

}