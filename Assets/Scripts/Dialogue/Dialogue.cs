using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RPG.Dialogue 
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue", order = 0)]
    public class Dialogue : ScriptableObject {
        [SerializeField]
        List<DialogueNode> nodes = new List<DialogueNode>();

        Dictionary<string, DialogueNode> nodeLookup = new Dictionary<string, DialogueNode>();


#if UNITY_EDITOR
        private void Awake() {
            if (nodes.Count == 0){
                CreateNode(null);
            }
        }
#endif
        /// OnValidate wont starts when project was exported, 
        // in this case we need to call it manually in Awake()
        private void OnValidate() {
            nodeLookup.Clear();

            foreach (DialogueNode node in GetAllNodes())
            {
                nodeLookup[node.name] = node;
            }
        }

        public IEnumerable<DialogueNode> GetAllNodes(){
            return nodes;
        }

        public DialogueNode GetRootNode(){
            return nodes[0];
        }

        public IEnumerable<DialogueNode> GetAllChildren(DialogueNode parentNode){

            foreach(string childID in parentNode.children){
                if (nodeLookup.ContainsKey(childID)) {
                    yield return nodeLookup[childID];
                }
            }
        }

        public void CreateNode(DialogueNode parent)
        {
            DialogueNode newNode = CreateInstance<DialogueNode>();
            newNode.name = Guid.NewGuid().ToString();
            Undo.RegisterCreatedObjectUndo(newNode, "Created Dialogue Node");
            if (parent != null){
                parent.children.Add(newNode.name);
            }
            nodes.Add(newNode);
            OnValidate();
        }

        public void DeleteNode(DialogueNode nodeToDelete)
        {
            nodes.Remove(nodeToDelete);
            // everytime when we update nodes list we need to 
            // update lookup through OnValidate 
            OnValidate();
            CleanDanglingChildren(nodeToDelete);
            Undo.DestroyObjectImmediate(nodeToDelete);
        }

        private void CleanDanglingChildren(DialogueNode nodeToDelete)
        {
            foreach (DialogueNode node in GetAllNodes())
            {
                node.children.Remove(nodeToDelete.name);
            }
        }
    }
}
