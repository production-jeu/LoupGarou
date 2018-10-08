using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf.Popups
{
    public class Popup : MonoBehaviour
    {
        public virtual void AfficherPopup()
        {
            gameObject.SetActive(true);
        }
        public virtual void FermerPopup()
        {
            gameObject.SetActive(false);
        }
    }
}
