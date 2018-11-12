using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Wolf.Dialogues;

namespace Wolf.Popups
{
    public class PopupDialogue : Popup
    {
        public TextMeshProUGUI texte_nomPersonnage, texte_contenu, texte_choix1, texte_choix2;
        public override void AfficherPopup()
        {
            base.AfficherPopup();
        }
        public void ChangerTexte(EtapeDialogue etapeDialogue)
        {
            texte_contenu.text = etapeDialogue.contenu;
            texte_nomPersonnage.text = etapeDialogue.nomPersonnage;
            if (etapeDialogue.choix == null)
            {
                texte_choix1.gameObject.SetActive(false);
                texte_choix2.gameObject.SetActive(false);
                texte_choix1.text = "";
                texte_choix2.text = "";
            }
            else
            {
                texte_choix1.gameObject.SetActive(true);
                texte_choix2.gameObject.SetActive(true);
                texte_choix1.text = etapeDialogue.choix.texte_choix1;
                texte_choix2.text = etapeDialogue.choix.texte_choix2;
            }
        }
    }
}
