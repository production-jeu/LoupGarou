using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf.Interaction.Dialogues
{
    public class InteractionDialogue : ZoneInteraction
    {
        DialogueManager dialogueManager;
        Dialogue dialogue_test;
        private void Start()
        {
            dialogueManager = GameManager.inst.dialogueManager;

            // DEBUGGING
            dialogue_test = new Dialogue();
            dialogue_test.etapes.Add(new EtapeDialogue("Sandrine De Montigny", "Je ne suis pas sur que j'aime cette personne...",
                new ChoixDialogue("Moi je l'aime.", "Moi non plus.",
                    new EtapeDialogue("Sandrine De Montigny", "Vous devriez avoir honte!"),
                    new EtapeDialogue("Boby Lehman", "Je suis d'accord avec vous :P, accouplons nous!! #fantasmes")
                )));
            // ====
        }
        public override void Interagir()
        {
            peutEtreUtiliser = false;
            base.Interagir();
            dialogueManager.GererDialogue(dialogue_test, ()=> { peutEtreUtiliser = true; });
        }
    }
}
