using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Wolf.Popups;

namespace Wolf.Dialogues
{
    public class ChoixDialogue
    {
        public ChoixDialogue(string tChoix1, string tChoix2, EtapeDialogue etape1, EtapeDialogue etape2)
        {
            texte_choix1 = tChoix1;
            texte_choix2 = tChoix2;
            dialogueChoix1 = etape1;
            dialogueChoix2 = etape2;
        }
        public string texte_choix1;
        public string texte_choix2;
        public EtapeDialogue dialogueChoix1;
        public EtapeDialogue dialogueChoix2;
    }
    public class EtapeDialogue
    {
        public EtapeDialogue(string nom, string contenu, ChoixDialogue choix = null)
        {
            nomPersonnage = nom;
            this.contenu = contenu;
            this.choix = choix;
        }
        // Sera afficher
        public string nomPersonnage;
        public string contenu;
        // Null = aucun choix
        public ChoixDialogue choix = null;
    }
    public class Dialogue
    {
        PopupManager popupManager;
        public List<EtapeDialogue> etapes;
        public int etapeIndex = 0;
        public UnityEvent OnDialogueFin;
        public Dialogue(List<EtapeDialogue> listeEtapes = null)
        {
            popupManager = GameManager.inst.popupManager;
            etapes = (listeEtapes == null) ? new List<EtapeDialogue>() : listeEtapes;
            OnDialogueFin = new UnityEvent();
        }
        public void CommencerDialogue()
        {
            etapeIndex = 0;
            AfficherEtape(etapes[etapeIndex]);
        }
        public void AfficherEtape(EtapeDialogue etape, bool etapeSecondaire = false)
        {
            if(etapeSecondaire == false)
                etapeIndex++;
            Popup popupAfficher = popupManager._PopupDialogue;
            popupManager.AjouterDemandePopup(() => {
                popupManager.AfficherPopup(popupAfficher);
                ((PopupDialogue)popupAfficher).ChangerTexte(etape);
                popupAfficher.OnPopupFermer.AddListener((choix)=> {
                    Debug.Log("Prochaine étape, choix: " + choix);
                    if (choix == -1 || etape.choix == null)
                    {
                        if (etapeIndex < etapes.Count)
                            AfficherEtape(etapes[etapeIndex]);
                        else // Fin dialogue, car plus aucunes étapes restantes
                        {
                            OnDialogueFin.Invoke();
                            OnDialogueFin.RemoveAllListeners();
                        }
                    }
                    else if (choix == 0)
                    {
                        AfficherEtape(etape.choix.dialogueChoix1, true);
                    }
                    else if (choix == 1)
                    {
                        AfficherEtape(etape.choix.dialogueChoix2, true);
                    }
                });
            });
            //popupManager.AfficherProchainPopup();
        }
    }
}

