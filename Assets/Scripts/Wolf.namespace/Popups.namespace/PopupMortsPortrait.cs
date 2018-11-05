using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wolf.NPC;

namespace Wolf.Popups
{
    public class PopupMortsPortrait : MonoBehaviour
    {
        public Image img_personnage;
        public Animator animatorMort;
        public void AfficherVisuel(Personnage personnage)
        {
            
        }
        public void JouerAnimationMort()
        {
            animatorMort.Play("animationMort", -1, 0);
        }
    }
}
