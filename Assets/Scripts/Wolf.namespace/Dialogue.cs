using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Wolf.Popups;

namespace Wolf
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
        public Dialogue()
        {
            popupManager = GameManager.inst.popupManager;
            etapes = new List<EtapeDialogue>();
            OnDialogueFin = new UnityEvent();
        }
        public void CommencerDialogue()
        {
            etapeIndex = 0;
            AfficherEtape(etapes[etapeIndex]);
        }
        public void AfficherEtape(EtapeDialogue etape)
        {
            etapeIndex++;
            Popup popupAfficher = popupManager._PopupDialogue;
            popupManager.AjouterDemandePopup(() => {
                popupManager.AfficherPopup(popupAfficher);
                ((PopupDialogue)popupAfficher).ChangerTexte(etape);
                popupAfficher.OnPopupFermer.AddListener((choix)=> {
                    Debug.Log("Prochaine étape, choix: " + choix);
                    if (choix == 0)
                    {
                        AfficherEtape(etape.choix.dialogueChoix1);
                    }
                    else if (choix == 1)
                    {
                        AfficherEtape(etape.choix.dialogueChoix2);
                    }
                    // Choix devrait être == -1 dans ce cas, donc on affiche simplement la prochaine étape de la conversation
                    else if (etapes.Count > etapeIndex)
                        AfficherEtape(etapes[etapeIndex]);
                    else
                    {
                        OnDialogueFin.Invoke();
                        OnDialogueFin.RemoveAllListeners();
                    }
                });
            });
            //popupManager.AfficherProchainPopup();
        }
    }
}

