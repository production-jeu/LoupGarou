using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf.Interaction.Ramassable
{
    public class ParcheminCollectible : ObjetRamassable
    {
        public override void Interagir()
        {
            var popupManager = GameManager.instance.popupManager;
            popupManager.AjouterDemandePopup(popupManager._PopupTest);
            Destroy(gameObject);
        }
    }
}
