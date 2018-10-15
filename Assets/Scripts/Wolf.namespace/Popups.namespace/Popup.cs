using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf.Popups
{
    public abstract class Popup : MonoBehaviour
    {
        public virtual void AfficherPopup()
        {
            gameObject.SetActive(true);
        }
        public virtual void FermerPopup()
        {
            gameObject.SetActive(false);
        }
        //public abstract void UpdateValeurs();
    }
}
