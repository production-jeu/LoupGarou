using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro
using Wolf.Interaction;

namespace Wolf
{
    public class UIManager : MonoBehaviour
    {
        public Image image_fondNoir;
        public TextMeshProUGUI texte_interaction;
        public void Initialisation()
        {
            texte_interaction.gameObject.SetActive(false);
        }
        public void UpdateSelection(ZoneInteraction objetSelectionner)
        {
            if (objetSelectionner != null)
            {
                texte_interaction.gameObject.SetActive(true);

                if (objetSelectionner.GetType() == typeof(InteractionPorte))
                {
                    InteractionPorte objet = objetSelectionner as InteractionPorte;
                    if (objet.porteBarrer)
                    {
                        texte_interaction.text = "La porte est barrée...";
                    }
                    else
                    {
                        if(objet.porteOuverte)
                            texte_interaction.text = "'E' pour fermer la porte.";
                        else
                            texte_interaction.text = "'E' pour ouvrir la porte.";
                    }
                }
                else
                {
                    // Type générique
                    texte_interaction.text = "'E' pour interagir avec [" + objetSelectionner.name + "]";
                }
            }
            else
            {
                texte_interaction.gameObject.SetActive(false);
                texte_interaction.text = "";
            }
        }
        public void Dormir()
        {
            image_fondNoir.gameObject.SetActive(true);
            UpdateSelection(null);
            image_fondNoir.GetComponent<Animator>().Play("anim_nouveauJour", -1, 0);
        }
    }
}
