using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wolf.NPC;
using Wolf.Dialogues;

namespace Wolf.Interaction.Dialogues
{
    public class InteractionDialogueNPC : InteractionDialogue
    {
        public Personnage personnage;       // Personnage sur lequel est attaché ce script
        private void Awake()
        {
            personnage = GetComponent<Personnage>();
        }
        public override void Interagir()
        {
            dialogueActuel = ConteneurDialogues.GetDialogueAlea(ConteneurDialogues.DialoguesNonPertinents, TypePersonnage.TOUS);
            foreach (EtapeDialogue etape in dialogueActuel.etapes)
            {
                etape.nomPersonnage = personnage.nom;
            }
            personnage.DebutDialogue();
            dialogueActuel.OnDialogueFin.AddListener(personnage.FinDialogue);
            base.Interagir();
        }
    }
}
