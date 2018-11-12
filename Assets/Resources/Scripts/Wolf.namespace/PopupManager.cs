using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wolf.Popups;
using Wolf.Dialogues;
using William.MouseManager;

namespace Wolf
{
    /*
     * Collectible du parchemin
     * @version 2028-10-22
     * @author William Gingras
     */
    public class PopupManager : MonoBehaviour
    {
        [Header("Debugging")]
        public bool debug = false;               // Tests
        [Space(10)]
        public Popup popupActuel = null;         // Le popup qui est actuellement affiché
        public List<Action> listePopups;         // Listes des popups dans l'ordre qu'il faut les afficher
        private GameManager gameManager;         // Ref GameManager

        public PopupTest _PopupTest;             // Ref au popupTest
        public PopupParchemin _PopupParchemin;   // Ref au popupParchemin
        public PopupDialogue _PopupDialogue;     // Ref au popupTest
        public PopupMorts _PopupMorts;           // Ref au popupMorts

        public Dialogue dialogue_test;

        private void Update()
        {
            // Permet de fermer le popup avec certaine touche si un popup est affiché
            if(popupActuel != null)
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
                {
                    ChoixDialogue(-1);
                }
        }
        // initialisation de ce script (appelé par le GameManager)
        public void Initialisation()
        {
            gameManager = GameManager.inst;
            listePopups = new List<Action>();
            if (debug)
            {
                AjouterDemandePopup(_PopupTest);
                AjouterDemandePopup(_PopupParchemin);
            }
        }
        // -1 = aucun choix, 0 = choix1, 1 = choix2
        public void ChoixDialogue(int choix)
        {
            FermerPopupActuel(choix);
        }
        // Affiche un popup cible
        public void AfficherPopup(Popup popup, bool afficherSouris = true)
        {
            popupActuel = popup;
            popup.AfficherPopup();
            gameManager.joueur.controlesPossibles = false;
            if(afficherSouris)
                MouseManager.SetMouse(false);
        }
        // Ajoute une demande à la liste listePopups
        public void AjouterDemandePopup(Popup popup)
        {
            listePopups.Add(()=> { AfficherPopup(popup); });
            if (popupActuel == null)
                AfficherProchainPopup();
        }
        // Ajoute une demande à la liste listePopups, mais permet de personnalisé l'action
        public void AjouterDemandePopup(Action action)
        {
            listePopups.Add(action);
            if (popupActuel == null)
                AfficherProchainPopup();
        }
        // Affiche le prochain popup de listePopups
        public Popup AfficherProchainPopup()
        {
            if (listePopups.Count > 0)
            {
                listePopups[0]();
                listePopups.RemoveAt(0);
            }
            return popupActuel;
        }
        // Ferme le popup actuellement ouvert
        public void FermerPopupActuel(int choix, bool afficherProchainPopup = true)
        {
            popupActuel.FermerPopup(choix);
            popupActuel = null;
            gameManager.joueur.controlesPossibles = true;
            MouseManager.SetMouse(true);
            if (afficherProchainPopup)
                AfficherProchainPopup();
        }
    }
}
