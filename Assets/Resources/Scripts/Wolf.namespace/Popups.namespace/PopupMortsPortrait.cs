using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wolf.NPC;

namespace Wolf.Popups
{
    public class PopupMortsPortrait : MonoBehaviour
    {
        public Personnage personnage;
        public Image img_personnage;
        public Animator animatorMort;
        public bool mortAfficher = false;
        public void AfficherVisuel()
        {
            
        }
        public void JouerAnimationMort()
        {
            animatorMort.Play("animationMort", -1, 0);
            mortAfficher = true;
        }
    }
}
