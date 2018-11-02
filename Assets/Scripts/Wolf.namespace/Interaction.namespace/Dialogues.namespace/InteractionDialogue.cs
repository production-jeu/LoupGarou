using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf.Interaction.Dialogues
{
    public class InteractionDialogue : ZoneInteraction
    {
        DialogueManager dialogueManager;
        UIManager uiManager;
        Dialogue dialogue_test;
        private void Start()
        {
            dialogueManager = GameManager.inst.dialogueManager;
            uiManager = GameManager.inst.uiManager;

            // DEBUGGING
            dialogue_test = new Dialogue();


            dialogue_test.etapes.Add(
                // Texte initial
                new EtapeDialogue("Henry - Forgeron", "J'ai entendu des rhumeurs sur la mort d'un jeune fermier.",
                    // réponses possibles 1
                    new ChoixDialogue("Dites-m'en plus.", "Sa ne m'interesse pas.",
                        // Réponse 1 et texte
                        new EtapeDialogue("Henry - Forgeron", "Bien sûr. C'est Cycil, L'herboriste, qui m'a raconté cette histoire. Elle dit avoir trouver son cadavre à la maison de jackob. C'est tout ce que j'ai comme information...", 
                            // réponses possibles 2
                            new ChoixDialogue("Bien, merci.", "Êtes-vous bien sûr?", 
                            // Choix 1 et texte
                            new EtapeDialogue("Henry - Forgeron", "Au revoir."),
                            // Choix 2 et texte
                            new EtapeDialogue("Henry - Forgeron", "Franchement, vous êtes nouveau ici! Ne poussez pas votre chance!"))),
                        // Réponse 2 et texte
                        new EtapeDialogue("Henry - Forgeron", "Dégagez d'ici si vous n'êtez même pas capable d'avoir une conversation civilizée!")
           )));

            // ====
        }
        public override void Interagir()
        {
            base.Interagir();
            // Permet de cacher le texte de 'selection'
            uiManager.selectionVisible = false;
            // Permet de réafficher le texte de 'selection' à la fin du dialogue
            dialogueManager.GererDialogue(dialogue_test, ()=> { uiManager.selectionVisible = true; });
        }
    }
}
