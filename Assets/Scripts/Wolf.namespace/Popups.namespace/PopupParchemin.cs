using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Wolf.Popups
{
    public class PopupParchemin : Popup
    {
        public TextMeshProUGUI texte_titre;
        public TextMeshProUGUI texte_contenu;
        public void ChangerTexte(string titre, string contenu = "Test contenu.")
        {
            texte_titre.text = titre;
            texte_contenu.text = contenu;
        }
    }
}
