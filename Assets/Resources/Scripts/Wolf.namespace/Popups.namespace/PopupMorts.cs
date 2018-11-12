using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Wolf.Popups
{
    public class PopupMorts : Popup
    {
        public TextMeshProUGUI texte, texteNvJour;
        public PopupMortsPortrait[] portraits;
        public void MontrerPopupNuit()
        {
            GetComponent<Animator>().Play("montrerPopupNuit", -1, 0);
        }
        public void CacherPopupNuit()
        {
            GetComponent<Animator>().Play("cacherPopupNuit", -1, 0);
        }
        public void RafraichirTexteNvJour()
        {
            //texteNvJour.text = GameManager.inst.timeManager.GetTempsString();
        }
        public void FermerPopupFinAnimation()
        {
            GameManager.inst.popupManager.FermerPopupActuel(-1);
        }
        public void RafraichirVisuel()
        {
            texteNvJour.text = GameManager.inst.timeManager.GetTempsString();
            foreach (PopupMortsPortrait portrait in portraits)
            {
                if (portrait.mortAfficher == false && portrait.personnage.estVivant == false)
                {
                    portrait.JouerAnimationMort();
                    texte.text = GameManager.inst.village.mortCetteNuit.nom + " à été éventré pendant la nuit!";
                }
            }
        }
    }
}
