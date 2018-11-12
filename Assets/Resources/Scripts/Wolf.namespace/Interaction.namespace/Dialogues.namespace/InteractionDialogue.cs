using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wolf.Dialogues;

namespace Wolf.Interaction.Dialogues
{
    public class InteractionDialogue : ZoneInteraction
    {
        protected DialogueManager dialogueManager;
        protected UIManager uiManager;
        protected Dialogue dialogueActuel;
        protected void Start()
        {
            dialogueManager = GameManager.inst.dialogueManager;
            uiManager = GameManager.inst.uiManager;
            dialogueActuel = new Dialogue(new List<EtapeDialogue>() { new EtapeDialogue("NomPersonnage", "Valeur par défaut.") });
        }
        public override void Interagir()
        {
            base.Interagir();
            // Permet de cacher le texte de 'selection'
            uiManager.selectionVisible = false;
            // Permet de réafficher le texte de 'selection' à la fin du dialogue
            dialogueManager.GererDialogue(dialogueActuel, ()=> { uiManager.selectionVisible = true; });
        }
    }
}
