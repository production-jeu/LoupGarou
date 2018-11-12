using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf.Dialogues
{
    public class ConteneurDialogues : MonoBehaviour
    {
        // Un dialogue filtrer contient tout simplement un dialogue et un TypePersonnage
        // ainsi on peu accéder au dialogue selon le type de personnage que le dit
        public class DialogueFiltrer
        {
            public DialogueFiltrer(Dialogue dialogue, TypePersonnage typePerso)
            {
                this.typePerso = typePerso;
                this.dialogue = dialogue;
            }
            public TypePersonnage typePerso;
            public Dialogue dialogue;
        }
        // Génère tout les dialogues possibles
        public void Initialisation()
        {
            // Ajout de tout les texte NON_PERTINENT dans la liste 'DialoguesNonPertinents'
            AjouterTousDialogueAvecFiltre("DIALOGUE_NON_PERTINENT", DialoguesNonPertinents);
        }
        // Pour chaque Texte contenant dans son ID le filtre:string, Crée avec la fonction 'CreerDialogueUneReplique'
        //  ajoute le dialogue dans la liste cible
        public void AjouterTousDialogueAvecFiltre(string filtre, List<DialogueFiltrer> listeCible)
        {
            List<Texte> textesFiltrer = TextManager.listeTextes.FindAll(texte => texte.id.Contains(filtre));
            foreach (Texte texte in textesFiltrer)
            {
                listeCible.Add(new DialogueFiltrer(CreerDialogueUneReplique(texte.valeur), GetTypePersoInID(texte.id)));
            }
        }

        // Les listes de dialogues
        public static List<DialogueFiltrer> DialoguesNonPertinents = new List<DialogueFiltrer>();
        // Fin listes de dialogues

        // Retourne le TypePersonnage correspondant a ce qu'une chaine (chaine ID du Texte) contient. Ex: EX_CHAINE_FOU_01 : retour=TypePersonnage.FOU
        public static TypePersonnage GetTypePersoInID(string texte_ID)
        {
            TypePersonnage typePerso;
            if (texte_ID.Contains("FOU"))              typePerso = TypePersonnage.FOU;
            else if (texte_ID.Contains("CHIEN"))       typePerso = TypePersonnage.CHIEN;
            else if (texte_ID.Contains("HERBORISTE"))  typePerso = TypePersonnage.HERBORISTE;
            else if (texte_ID.Contains("PRETRE"))      typePerso = TypePersonnage.PRETRE;
            else if (texte_ID.Contains("CHASSEUR"))    typePerso = TypePersonnage.CHASSEUR;
            else if (texte_ID.Contains("VOLEUSE"))     typePerso = TypePersonnage.VOLEUSE;
            else if (texte_ID.Contains("BARMAN"))      typePerso = TypePersonnage.BARMAN;
            else if (texte_ID.Contains("SORCIERE"))    typePerso = TypePersonnage.SORCIERE;
            else                                       typePerso = TypePersonnage.TOUS;
            return typePerso;
        }
        // Retourne un dialogue aléatoire d'une liste de 'DialogueFiltrer' qui est elle même filtrée par un 'TypePersonnage'
        public static Dialogue GetDialogueAlea(List<DialogueFiltrer> liste, TypePersonnage typePersoFiltre)
        {
            var listeFiltrer = liste.FindAll(texteFiltrer => texteFiltrer.typePerso == typePersoFiltre);
            return listeFiltrer[Random.Range(0, listeFiltrer.Count)].dialogue;
        }
        // Retourne un dialogue contenant une seule réplique:string passée en paramètre.
        public static Dialogue CreerDialogueUneReplique(string replique)
        {
            return new Dialogue(new List<EtapeDialogue>() { new EtapeDialogue("NomPersonnage", replique) });
        }
    }
}
