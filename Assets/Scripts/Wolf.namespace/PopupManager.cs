using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wolf.Popups;
using William.MouseManager;

namespace Wolf
{
    public class PopupManager : MonoBehaviour
    {
        [Header("Debugging")]
        public bool debug = false;
        [Space(10)]
        public Popup popupActuel = null;
        public List<Action> listePopups;  // Listes des popups dans l'ordre qu'il faut les afficher

        public PopupTest _PopupTest;
        public PopupParchemin _PopupParchemin;
        private void Update()
        {
            if(popupActuel != null)
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    FermerPopupActuel();
                }
        }
        public void Initialisation()
        {
            listePopups = new List<Action>();
            if (debug)
            {
                AjouterDemandePopup(_PopupTest);
                AjouterDemandePopup(_PopupParchemin);
            }
        }
        public void AfficherPopup(Popup popup)
        {
            popupActuel = popup;
            popup.AfficherPopup();
            GameManager.inst.joueur.controlesPossibles = false;
            MouseManager.SetMouse(false);
        }
        public void AjouterDemandePopup(Popup popup)
        {
            listePopups.Add(()=> { AfficherPopup(popup); });
            if (popupActuel == null)
                AfficherProchainPopup();
        }
        public void AjouterDemandePopup(Action action)
        {
            listePopups.Add(action);
            if (popupActuel == null)
                AfficherProchainPopup();
        }
        public void AfficherProchainPopup()
        {
            if (listePopups.Count > 0)
            {
                listePopups[0]();
                listePopups.RemoveAt(0);
            }
        }
        public void FermerPopupActuel(bool afficherProchainPopup = true)
        {
            popupActuel.FermerPopup();
            popupActuel = null;
            GameManager.inst.joueur.controlesPossibles = true;
            MouseManager.SetMouse(true);
            if (afficherProchainPopup)
                AfficherProchainPopup();
        }
    }
}
