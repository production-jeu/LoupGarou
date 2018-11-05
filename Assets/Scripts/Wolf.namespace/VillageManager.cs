using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wolf.NPC;
using Wolf.Batiments;

namespace Wolf
{
    /*
     * Manager du village
     * @version 2028-10-22
     * @author William Gingras
     */
    public class VillageManager : MonoBehaviour
    {
        public List<Maison> maisons;
        public List<Personnage> personnages;
        /* Initialisation des personnage, apparitions et attribution de leurs maisons */
        public void Initialisation()
        {
            List<Maison> maisonsMelangers = William.Utils.Utils.MelangerListe(maisons);
            personnages = new List<Personnage>();
            for (int x = 0; x < personnages.Count; x++)
            {
                personnages[x].batiment = maisonsMelangers[x];
            }
        }
        /*
	    *Permet d'interompre tout les comportements des villageois
	    * et de les envoyer dans leurs maisons respectives.
	    * Effectue une boucle sélectionnant tout les villageois et 
	    * active leurs fonction allerDormir
        */
        public void AllezTousDormir()
        {
        }
        /*
        *Attribut des comportements aléatoires différents pour 
        * chaque villageois
        */
        public void ChoisirComportements()
        {

        }
    }
}
