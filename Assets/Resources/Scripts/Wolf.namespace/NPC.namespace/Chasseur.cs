using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wolf.NPC
{
<<<<<<< HEAD:Assets/Resources/Scripts/Wolf.namespace/NPC.namespace/Chasseur.cs
    public class Chasseur : Personnage
=======
    /*
     * Manager des dialogues
     * @version 2028-10-22
     * @author William Gingras
     */
    public class DialogueManager : MonoBehaviour
>>>>>>> 2eedb375508aa01cc4769b5f7e1b72f0326cce8a:Assets/Scripts/Wolf.namespace/DialogueManager.cs
    {
        public GameManager gameManager;
        public bool enDialogue = false;
        // initialisation de ce script (appelé par le GameManager)
        public void Initialisation()
        {
            gameManager = GameManager.inst;
        }
        public void GererDialogue(Dialogue dialogue, UnityAction fonctionFinDialogue = null)
        {
            enDialogue = true;
            dialogue.CommencerDialogue();
            if(fonctionFinDialogue != null)
                dialogue.OnDialogueFin.AddListener(fonctionFinDialogue);
        }
        public void FinDialogue()
        {
            enDialogue = false;
        }
    }
}
