using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf.Interaction.Ramassable
{
    /*
     * Collectible du parchemin
     * @version 2028-10-22
     * @author William Gingras
     */
    public class ParcheminCollectible : ObjetRamassable
    {
        public string id_collectible;     // ID pour le TextManager (sans le suffixe _TITRE ou _CONTENU)
        // Script qui est executé lorsque le joueur intéragit avec cet objet
        public override void Interagir()
        {
            var popupManager = GameManager.inst.popupManager;
            var textManager = GameManager.inst.textManager;

            string titre = textManager.GetTexteById(id_collectible + "_TITRE");
            string contenu = textManager.GetTexteById(id_collectible + "_CONTENU");

            popupManager.AjouterDemandePopup(()=> {
                popupManager.AfficherPopup(popupManager._PopupParchemin);
                popupManager._PopupParchemin.ChangerTexte(titre, contenu);
            });

            Destroy(gameObject);
        }
    }
}
