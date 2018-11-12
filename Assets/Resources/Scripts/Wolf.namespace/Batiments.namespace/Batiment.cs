using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wolf.Interaction;

namespace Wolf.Batiments
{
    public class Batiment : MonoBehaviour
    {
        
        public InteractionPorte porte;
        public bool batimentOuvert;
        public virtual void Initialisation()
        {
            porte.OnPorteInteraction.AddListener((porteOuverte) => {
                batimentOuvert = porteOuverte;
            });
        }
    }
}
