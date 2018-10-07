using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace William.Utils
{
    public class GenericButton : MonoBehaviour
    {

        protected Image img_ref;
        public Sprite[] btn_sprites;
        protected bool isHoldingMouse = false;
        public UnityEvent OnClick = new UnityEvent();
        public UnityEvent _OnMouseEnter = new UnityEvent();
        public UnityEvent _OnMouseExit = new UnityEvent();

        protected void Awake()
        {
            img_ref = GetComponent<Image>();
        }

        protected virtual void OnMouseEnter()
        {
            img_ref.sprite = btn_sprites[1];
            _OnMouseEnter.Invoke();
        }

        protected virtual void OnMouseExit()
        {
            isHoldingMouse = false;
            img_ref.sprite = btn_sprites[0];
            _OnMouseExit.Invoke();
        }

        protected virtual void OnMouseDown()
        {
            isHoldingMouse = true;
            img_ref.sprite = btn_sprites[2];
        }

        protected virtual void OnMouseUp()
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

