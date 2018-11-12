using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf.Interaction
{
    /*
     * ZoneInteraction qui permet l'interaction avec le joueur
     * @version 2028-10-22
     * @author William Gingras
     */
    public class ZoneInteraction : MonoBehaviour
    {
        public bool peutEtreUtiliser = true;      // Définie si cet Zone d'interaction peut présentement avoir une interaction du joueur
        // Script qui est executé lorsque le joueur interagit avec cet objet
        public virtual void Interagir()
        {
            GameManager.inst.uiManager.UpdateSelection(null);
        }
    }
}
