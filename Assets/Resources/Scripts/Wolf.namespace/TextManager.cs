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
        public static List<Texte> listeTextes;
        /*
         Chien = Meat
         Sorcière = Cycil
         Chasseur = George
         Barman = Ernest
         Fou = Bob
         Voleur = Meyer
         */
        public static string[] NomsHomme = new string[]
        {
            "Frederich",
            "George",
            "Edward",
            "Karl",
            "Ludwig"
        };
        public static string[] NomsFemme = new string[]
        {
            "Alice",
            "Karoline",
            "Elisabeth",
            "Teorie",
            "Finna"
        };
        public void Initialisation()
        {
            listeTextes = new List<Texte>();
            // AJOUT DE TEXTES ICI

            // AjouterTexte("FEMME_CONTENTE_01", "Je suis contente!");
            // AjouterTexte("FEMME_CONTENTE_02", "Je suis heureuse!");
            // AjouterTexte("FEMME_CONTENTE_03", "Bonjour! Comment allez-vous?");n
            #region DIALOGUES

            #region TEXTES_NON_PERTINENTS
            AjouterTexte("DIALOGUE_NON_PERTINENT_TOUS_1", "Apparemment, nous les terres du Duc n’ont pas été favorable cette saison. Je pense que cela nous affecte également?");
            AjouterTexte("DIALOGUE_NON_PERTINENT_TOUS_2", "Autrefois, le jardin était ouvert sur les falaises offrant une magnifique vue. La lumière de l’arbre attirait trop de visiteurs.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_TOUS_3", "Bientôt, nous serons confinés au chaud dans les maisons. Encore plus proche du loup-garou.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_TOUS_4", "Cette arbre récolte la soie qui construit le ciel nocturne. Selon une légende, un violon pouvait contrôler cette soie et ses astres.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_TOUS_5", "J’ai appris à ne pas parler aux gens poilus.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_TOUS_6", "J’ai entendu le chasseur parler tout seul avec son chien.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_TOUS_7", "Nous aimons votre service, mais les gens de l’externe ne peuvent pas rentrer dans l’église. ");
            AjouterTexte("DIALOGUE_NON_PERTINENT_TOUS_8", "Je me rappelle de l’époque où l’on avait peur des loups. L’époque a évolué et les loups aussi.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_TOUS_9", "Le chasseur fait également de l’élevage. Cette pratique est nécessaire pour notre village si isolé.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_TOUS_10", "Le chien de la ferme me regarde comme s’il pouvait me parler.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_TOUS_11", "Les dragons et les fées n’existent pas ici. Si vous voulez voir de la magies, faites vous éventrer par des loups humains.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_TOUS_12", "On peut se permettre de parler de dragon et de loup-garou ici. Si vous êtes préposé du roi, je ne sais pas de quoi je parle.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_TOUS_13", "L’hiver arrive bientôt à Winterrest. Heureusement, notre chasseur a fait des réserves de viande.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_TOUS_14", "Personne ne sait qui est le loup-garou et personne veut l’être également.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_TOUS_15", "Vous-êtes venu pour trouver le loup-garou? J’espère qu’on vous a bien choisi.");

            AjouterTexte("DIALOGUE_NON_PERTINENT_FOU_1", "Dieux et déesses, aucuns n’existent sans peur du diable.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_FOU_2", "Je n’ai pas besoins d’amis. Je suis mes amis.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_FOU_3", "La nuit, la peur du loup aspire notre âme avant de la voir.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_PRETRE_1", "La famille royale Widgarde a construit ce village il y a longtemps. Je suis triste d’être le propriétaire de ces ruines.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_PRETRE_2", "Mon fils.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_CHIEN_1", "J’ai vu elfs et des fées, j’ai vu les fleuves s’élever, des guerres de religions, et des siècles de pestes. Maintenant je vois beaucoup, beaucoup de jambes.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_CHIEN_2", "Telramor, grand dragon d’Érazie. Maintenant un meilleur ami.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_BARMAN_1", "Du vin? Une bière? Ou du pepsi?");
            AjouterTexte("DIALOGUE_NON_PERTINENT_BARMAN_2", "Vous voulez oublier le loup garou? Venez boire.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_HERBORISTE_1", "Vous avez l’air malade, venez me voir quand vous aurez le temps.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_HERBORISTE_2", "Vous avez vue les arbres? Ils sont malades, je le sais.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_HERBORISTE_3", "Parfois, le soir, je me sens seule et j’aimerais avoir un compagnon.");
            AjouterTexte("DIALOGUE_NON_PERTINENT_HERBORISTE_4", "Mes herbes soignent tous les maux, pour autant qu’on est l’argent nécessaire…");
            AjouterTexte("DIALOGUE_NON_PERTINENT_HERBORISTE_5", "Humm… Je ne sais pas si vous ferez vraiment l’affaire… Les loup-garou sont de dangereuses créatures…");
            AjouterTexte("DIALOGUE_NON_PERTINENT_HERBORISTE_6", "Je ne m’implique jamais dans les activitées du village, elles sont ennuyantes…");
            #endregion

            #endregion
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
        public static string GetTexteById(string id)
        {
            return listeTextes.Find(x => x.id == id).valeur;
        }
        // Ajoute un texte dans la liste de textes
        public static void AjouterTexte(string id, string valeur)
        {
            listeTextes.Add(new Texte(id, valeur));
        }
        public static string GetNomAlea(Sexe sexe)
        {
            string[] listeNoms = (sexe == Sexe.HOMME) ? NomsHomme : NomsFemme;
            return listeNoms[Random.Range(0, listeNoms.Length)];
        }
    }
}
