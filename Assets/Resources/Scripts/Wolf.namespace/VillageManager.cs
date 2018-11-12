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
        GameManager gameManager;                     // Référence au GameManager
        public List<Maison> maisons;                 // Devrait toujours contenir 5 maisons
        public List<Personnage> personnages;         // Devrait toujours contenir 10 Personnages
        public Personnage loupGarou;                 // Référence au personnage qui est le loup-garou
        public Personnage mortCetteNuit = null;      // Référence au Personnage qui est mort cette nuit
        /* 
         * Initialisation des personnage, apparitions et attribution de leurs maisons 
         */
        public void Initialisation()
        {
            gameManager = GameManager.inst;
            List<Maison> maisonsMelangers = William.Utils.Utils.MelangerListe(maisons);
            int indexMaison = 0;
            // Donne une maison à deux personnage à la fois
            for (int x = 0; x < 10; x+=2)
            {
                personnages[x].batiment = maisonsMelangers[indexMaison];
                personnages[x+1].batiment = maisonsMelangers[indexMaison];
                personnages[x].Initialisation();
                personnages[x+1].Initialisation();
                indexMaison++;
            }
            // Choisir le loup-garou
            loupGarou = personnages[Random.Range(0, 10)];
            loupGarou.estLoupGarou = true;
            gameManager.loupGarou = loupGarou;
        }
        /*
         * Fait apparaite tout les personnages au point d'apparition de leur maison et 
         *  choisit les comportements des personnages pour la journée
         */
        public void NouveauJour()
        {
            for (int x = 0; x < personnages.Count; x++)
            {
                personnages[x].PlacerDansPointApparitionMaison();
            }
            ChoisirComportements();
        }
        /*
         * Gère les évènements qui se produiront cette nuit
         *  le loup-garou choisit une victime aléatoire (incluant joueur).
         */
        public void ActionsNuit()
        {
            List<Personnage> personnagesVivants = personnages.FindAll(perso => perso.estVivant == true);
            int choixAlea = Random.Range(0, personnagesVivants.Count + 1);
            foreach (Personnage perso in personnagesVivants)
            { print(perso.name); }
            if (choixAlea == personnagesVivants.Count)
            {
                // victime = joueur
                print("Victime = joueur");
                gameManager.joueur.estVivant = false;
            }
            else
            {
                // victime = NPC
                print("Victime = NPC");
                mortCetteNuit = personnagesVivants[choixAlea];
                mortCetteNuit.estVivant = false;
                mortCetteNuit.gameObject.SetActive(false);
            }
        }
        /*
	     * Permet d'interompre tout les comportements des villageois
	     *  et de les envoyer dans leurs maisons respectives.
	     *  Effectue une boucle sélectionnant tout les villageois et 
	     *  active leurs fonction allerDormir
         */
        public void AllezTousDormir()
        {
            for (int x = 0; x < personnages.Count; x++)
            {
                personnages[x].AllerDormir();
            }
        }
        /*
         * Attribut des comportements aléatoires différents pour 
         *  chaque villageois
         */
        public void ChoisirComportements()
        {

        }
    }
}
