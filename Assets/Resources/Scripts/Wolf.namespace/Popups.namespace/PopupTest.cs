using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wolf.Popups;
using TMPro;

public class PopupTest : Popup
{
    public TextMeshProUGUI texte_titre, texte_contenu;
    public override void AfficherPopup()
    {
        base.AfficherPopup();
    }
    public void ChangerTexte(string titre, string contenu = "Test contenu.")
    {
        texte_titre.text = titre;
        texte_contenu.text = contenu;
    }
}
