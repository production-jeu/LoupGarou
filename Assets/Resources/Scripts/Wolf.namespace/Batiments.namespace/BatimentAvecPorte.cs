using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wolf.Interaction;
using Wolf.Interaction.Zones;

namespace Wolf.Batiments
{
    // Cette classe est commune à tout les batiments ayant une porte
    // Elle permet une transition sonore de l'ambiance en douceur.
    public class BatimentAvecPorte : Batiment
    {
        public ZoneDetection zoneInterieur;
        private void Start()
        {
            Initialisation();
        }
        public override void Initialisation()
        {
            zoneInterieur.OnZoneEnter.AddListener(()=> {
                FadeSonAmbiance();
            });
            zoneInterieur.OnZoneLeave.AddListener(() => {
                GameManager.inst.soundManager.VolumeFade(0.8f);
            });
            porte.OnPorteInteraction.AddListener((porteOuverte)=> {
                Debug.Log("Porte interaction");
                batimentOuvert = porteOuverte;
                if(zoneInterieur.joueurEstDansLaZone)
                    FadeSonAmbiance();
            });
        }
        public void FadeSonAmbiance()
        {
            //Debug.Log("start fade in Maison.cs");
            if (batimentOuvert)
            {
                //Debug.Log("0.5f");
                GameManager.inst.soundManager.VolumeFade(0.43f);
            }
            else
            {
                //Debug.Log("0.2f");
                GameManager.inst.soundManager.VolumeFade(0.2f);
            }
        }
    }
}
