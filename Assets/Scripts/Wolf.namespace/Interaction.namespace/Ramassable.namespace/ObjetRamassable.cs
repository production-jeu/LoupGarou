using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf.Interaction.Ramassable
{
    public class ObjetRamassable : ZoneInteraction
    {
        public TypeObjet typeObjet;
        public override void Interagir()
        {
            base.Interagir();
            GameManager.inst.RamasserObjet(typeObjet);
            Destroy(gameObject);
        }
    }
}
