using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wolf.Popups;
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
        private void Update()
        {
            // Permet de fermer le popup avec certaine touche si un popup est affiché
            if(popupActuel != null)
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButton(0))
                {
                    FermerPopupActuel();
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
        // Affiche un popup cible
        public void AfficherPopup(Popup popup)
        {
            popupActuel = popup;
            popup.AfficherPopup();
            gameManager.joueur.controlesPossibles = false;
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
        public void AfficherProchainPopup()
        {
            if (listePopups.Count > 0)
            {
                listePopups[0]();
                listePopups.RemoveAt(0);
            }
        }
        // Ferme le popup actuellement ouvert
        public void FermerPopupActuel(bool afficherProchainPopup = true)
        {
            popupActuel.FermerPopup();
            popupActuel = null;
            gameManager.joueur.controlesPossibles = true;
            MouseManager.SetMouse(true);
            if (afficherProchainPopup)
                AfficherProchainPopup();
        }
    }
}
