using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro
using Wolf.Interaction;
using Wolf.Interaction.Ramassable;

namespace Wolf
{
    /*
     * Manager de l'interface utilisateur
     * @version 2028-10-22
     * @author William Gingras
     */
    public class UIManager : MonoBehaviour
    {
        public Image image_fondNoir;                   // Le fond noir
        public TextMeshProUGUI texte_interaction;      // Le texte au milieu de l'écran
        public bool selectionVisible = true;           // Détermine si la sélection est visible
        public void Initialisation()
        {
            texte_interaction.gameObject.SetActive(false);
        }
        // Rafraichit le texte de sélection qui apparait au milieu de l'écran (Si le paramètre est NULL, alors le texte disparait)
        public void UpdateSelection(ZoneInteraction objetSelectionner)
        {
            if (objetSelectionner != null && selectionVisible)
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
        // Animation Lorsque le joueur dort
        public void Dormir()
        {
            image_fondNoir.gameObject.SetActive(true);
            UpdateSelection(null);
            image_fondNoir.GetComponent<Animator>().Play("anim_nouveauJour", -1, 0);
        }
    }
}
