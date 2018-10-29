using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf
{
    /*
     * Manager des dialogues
     * @version 2028-10-22
     * @author William Gingras
     */
    public class DialogueManager : MonoBehaviour
    {
        public GameManager gameManager;
        public bool enDialogue = false;
        // initialisation de ce script (appelé par le GameManager)
        public void Initialisation()
        {
            gameManager = GameManager.inst;
        }
        public void GererDialogue(Dialogue dialogue, System.Action fonctionFinDialogue = null)
        {
            enDialogue = true;
            dialogue.CommencerDialogue();
            if(fonctionFinDialogue != null)
                dialogue.OnDialogueFin.AddListener(()=> { fonctionFinDialogue(); });
        }
        public void FinDialogue()
        {
            enDialogue = false;
        }
    }
}
