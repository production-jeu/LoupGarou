using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf
{
    /*
     * Texte avec un ID 
     * @version 2028-10-22
     * @author William Gingras
     */
    [SerializeField]
    [System.Serializable]
    public class Texte
    {
        public string id;
        public string valeur;
        public Texte(string id, string valeur)
        {
            this.id = id;
            this.valeur = valeur;
        }
    }
    /*
     * Manager des textes
     * @version 2028-10-22
     * @author William Gingras
     */
    public class TextManager : MonoBehaviour
    {
        /*
         #region Singleton
        public static TextManager inst; // instance statique
        private void Awake()
        {
            inst = this;
        }
        #endregion
        */
        public List<Texte> listeTextes;
        public void Initialisation()
        {
            listeTextes = new List<Texte>();
            // AJOUT DE TEXTES ICI

            // AjouterTexte("FEMME_CONTENTE_01", "Je suis contente!");
            // AjouterTexte("FEMME_CONTENTE_02", "Je suis heureuse!");
            // AjouterTexte("FEMME_CONTENTE_03", "Bonjour! Comment allez-vous?");

            #region COLLECTIBLES

            #region EXPLORATEUR
            AjouterTexte("COLLECTIBLE_EXPLORATEUR_01_TITRE", "Dieu d'ardoise");
            AjouterTexte("COLLECTIBLE_EXPLORATEUR_01_CONTENU", "(Schwangau - Allemagne - 20 Novembre 1945)\n"
                                                + "\n"
                                                + "“De temps en temps, le temps nous est favorable,\n"
                                                + "mais cette fois - ci, les siècles ne l’ont pas été.\n"
                                                + "Winterrest, devant nous effacé.\n"
                                                + "Sous la lumière albatrine et les ombres ardoisées,\n"
                                                + "l’immobile sur les tables,\n"
                                                + "une étagère de sentiments peinteurée de rouille terne.\n"
                                                + "\n"
                                                + "Des chandelles séchées sur les chapelles dénoncent l’abandon,\n"
                                                + "des planchers de danse où seule valse la poussière,\n"
                                                + "le mouvement, du lent temps sous l’étrange lumière.\n"
                                                + "\n"
                                                + "Nous sommes immobiles – les statues en praîtresses –\n"
                                                + "les yeux fermés, la tête vide comme la pièce,\n"
                                                + "les plans du château brûlent en avenir de couleurs,\n"
                                                + "lumière albatrine sur les murs de Winterrest.\n"
                                                + "Ici, le passé règne, squelettique, fragile, vide.\n"
                                                + "Le potentiel parfait d’une tombe.”");

            // FAUTES DE FRANCAIS

            /*AjouterTexte("COLLECTIBLE_EXPLORATEUR_02_TITRE", "Ils étaient loups");
            AjouterTexte("COLLECTIBLE_EXPLORATEUR_02_CONTENU", "(Schwangau - Allemagne - 21 Novembre 2014)\n"
                                                + "\n"
                                                + "“Les loups rôdent autour des ruines comme les hommes autour des bars,\n"
                                                + "Une chance offerte aux chiens pour manger tard le soir.\n"
                                                + "\n"
                                                + "Si les loups sont si obscurs, d’où vient l’étincelle qui les fit devenir chiens ?\n"
                                                + "\n"
                                                + "La lumière du soleil brille pour aveugler,\n"
                                                + "Les étoiles guident en valsant dans les prés.\n"
                                                + "Pleine lune si belle, reine de la belle obscurité.\n"
                                                + "\n"
                                                + "Une belle toile doit pourtant traverser l’arc de notre ciel.\n"
                                                + "Loups devenant chiens, humains devenant loups,\n"
                                                + "Une piètre image de l’humain.\n"
                                                + "Menant à une autre aube, autre lumière égarée.”\n");
            AjouterTexte("COLLECTIBLE_EXPLORATEUR_03_TITRE", "D’Autriche en Allemagne");
            AjouterTexte("COLLECTIBLE_EXPLORATEUR_03_CONTENU", "(Klagenfurt - Autriche - 31 Octobre 2014)\n"
                                                + "\n"
                                                + "“Nous partirons en Allemagne pour des les recherche sur les terres du château de papa\n"
                                                + "Je t’écris avec ma plume, entre les jeunes costumés.\n"
                                                + "\n"
                                                + "Les rues d’Autriche sont remplies de monstres de bonheur,\n"
                                                + "La ville est illuminée par tant d’ampoule.\n"
                                                + "Mais entre les ampoules scintillantes, des homme rôde sans nom.\n"
                                                + "Les femmes gardent leurs bouches fermées, connaissant le prix.\n"
                                                + "\n"
                                                + "Certains connaissent le secret de ces montagnes.\n"
                                                + "Un passage vers un royaume, perdue dans le temps.\n"
                                                + "\n"
                                                + "Ces forêts d’Autriche et d’Allemagne\n"
                                                + "cachent des châteaux, des rêves et tant des guerres, tous couteux.\n"
                                                + "Seul mon téléphone et sa lumière brûle le givre.”\n");*/
            
            #endregion

            #endregion
        }
        // Retourne la valeur du texte avec l'ID donné
        public string GetTexteById(string id)
        {
            return listeTextes.Find(x => x.id == id).valeur;
        }
        // Ajoute un texte dans la liste de textes
        public void AjouterTexte(string id, string valeur)
        {
            listeTextes.Add(new Texte(id, valeur));
        }
    }
}
