using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wolf.Events;

namespace Wolf.Popups
{
    public class Popup : MonoBehaviour
    {
        public IntEvent OnPopupFermer;
        private void Awake()
        {
            OnPopupFermer = new IntEvent();
        }
        public virtual void AfficherPopup()
        {
            gameObject.SetActive(true);
        }
        public virtual void FermerPopup(int choix = -1)
        {
            // SI choix == -1, alors il n'y avait pas de choix
            OnPopupFermer.Invoke(choix);
            // Permet d'enlever les potentiel listener de 'OnPopupFermer'
            OnPopupFermer.RemoveAllListeners();
            gameObject.SetActive(false);
        }
    }
}
