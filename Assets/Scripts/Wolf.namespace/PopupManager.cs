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
                AjouterDemandePopup(() => { AfficherPopup(_PopupTest); _PopupTest.ChangerTexte("1"); });
                AjouterDemandePopup(() => { AfficherPopup(_PopupTest); _PopupTest.ChangerTexte("2"); });
            }
        }
        public void AfficherPopup(Popup popup)
        {
            popupActuel = popup;
            popup.AfficherPopup();
            GameManager.instance.joueur.controlesPossibles = false;
            MouseManager.SetMouse(false);
        }
        public void AjouterDemandePopup(Action fonctionAppelPopup)
        {
            listePopups.Add(fonctionAppelPopup);
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
            GameManager.instance.joueur.controlesPossibles = true;
            MouseManager.SetMouse(true);
            if (afficherProchainPopup)
                AfficherProchainPopup();
        }
    }
}
