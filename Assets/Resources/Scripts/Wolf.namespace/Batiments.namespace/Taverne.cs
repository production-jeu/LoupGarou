using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wolf.Interaction;
using Wolf.Interaction.Zones;

namespace Wolf.Batiments
{
    public class Taverne : BatimentAvecPorte
    {
        public ZoneDetection zoneInterieur2;
        public override void Initialisation()
        {
            zoneInterieur.OnZoneEnter.AddListener(() => {
                FadeSonAmbiance();
            });
            zoneInterieur.OnZoneLeave.AddListener(() => {
                // On regarde si le joueur est dans la zone2 pour que le son d'ambiance reste faible dans les deux zones
                if(zoneInterieur2.joueurEstDansLaZone == false)
                    GameManager.inst.soundManager.VolumeFade(0.8f);
            });
            porte.OnPorteInteraction.AddListener((porteOuverte) => {
                Debug.Log("Porte interaction");
                batimentOuvert = porteOuverte;
                if (zoneInterieur.joueurEstDansLaZone || zoneInterieur2.joueurEstDansLaZone)
                    FadeSonAmbiance();
            });
        }
    }
}
