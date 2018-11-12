using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf.Interaction.Ramassable
{
    /*
     * Parent des ObjetRamassable
     * @version 2028-10-22
     * @author William Gingras
     */
    public class ObjetRamassable : ZoneInteraction
    {
        public TypeObjet typeObjet;       // Le type de l'objet
        // Script qui est executé lorsque le joueur interagit avec cet objet
        public override void Interagir()
        {
            base.Interagir();
            GameManager.inst.RamasserObjet(typeObjet);
            Destroy(gameObject);
        }
    }
}
