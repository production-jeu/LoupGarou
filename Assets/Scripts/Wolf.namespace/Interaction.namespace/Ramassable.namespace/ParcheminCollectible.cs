using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf.Interaction.Ramassable
{
    public class ParcheminCollectible : ObjetRamassable
    {
        public string id_collectible_titre;
        public override void Interagir()
        {
            var popupManager = GameManager.inst.popupManager;
            var textManager = GameManager.inst.textManager;

            string titre = textManager.GetTexteById(id_collectible_titre + "_TITRE");
            string contenu = textManager.GetTexteById(id_collectible_titre + "_CONTENU");

            popupManager.AjouterDemandePopup(()=> {
                popupManager.AfficherPopup(popupManager._PopupParchemin);
                popupManager._PopupParchemin.ChangerTexte(titre, contenu);
            });

            Destroy(gameObject);
        }
    }
}
