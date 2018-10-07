using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf.Interaction
{
    public class InteractionLit : ZoneInteraction
    {
        public override void Interagir()
        {
            Debug.Log("Interaction avec objet lit!");
            // Dormir
            GameManager.instance.JoueurDormir();
        }
    }
}