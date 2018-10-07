using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf.Interaction
{
    public class ZoneInteraction : MonoBehaviour
    {
        public bool peutEtreUtiliser = true;      // Définit si cet Zone d'interaction peut présentement avoir une interaction du joueur
        public virtual void Interagir()
        {
            GameManager.instance.uiManager.UpdateSelection(null);
        }
    }
}
