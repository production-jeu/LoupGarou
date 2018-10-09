using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf
{
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
    public class TextManager : MonoBehaviour
    {
        private List<Texte> listeDialogues;
        public void Initialisation()
        {
            // AJOUT DE TEXTES ICI

            AjouterTexte("FEMME_CONTENTE_01", "Je suis contente!");
            AjouterTexte("FEMME_CONTENTE_02", "Je suis heureuse!");
            AjouterTexte("FEMME_CONTENTE_03", "Bonjour! Comment allez-vous?");

            GetTexteById("FEMME_CONTENTE_0" + Random.Range(1, 3));

            // FIN AJOUT TEXTES
        }
        public string GetTexteById(string id)
        {
            return listeDialogues.Find(x => x.id == id).valeur;
        }
        public void AjouterTexte(string id, string valeur)
        {
            listeDialogues.Add(new Texte(id, valeur));
        }
    }
}
