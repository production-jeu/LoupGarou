using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace William.Utils
{
    public class GenericSpriteButton : GenericButton
    {

        protected Image img_ref;
        public Sprite[] btn_sprites;

        protected void Awake()
        {
            img_ref = GetComponent<Image>();
        }

        protected override void OnMouseEnter()
        {
            img_ref.sprite = btn_sprites[1];
            _OnMouseEnter.Invoke();
        }

        protected override void OnMouseExit()
        {
            isHoldingMouse = false;
            img_ref.sprite = btn_sprites[0];
            _OnMouseExit.Invoke();
        }

        protected override void OnMouseDown()
        {
            isHoldingMouse = true;
            img_ref.sprite = btn_sprites[2];
        }

        protected override void OnMouseUp()
        {
            if (isHoldingMouse)
            {
                isHoldingMouse = false;
                OnClick.Invoke();
                img_ref.sprite = btn_sprites[1];
            }
        }

    }
}

