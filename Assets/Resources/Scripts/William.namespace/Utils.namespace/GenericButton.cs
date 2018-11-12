using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace William.Utils
{
    public class GenericButton : MonoBehaviour
    {
        protected bool isHoldingMouse = false;
        public UnityEvent OnClick = new UnityEvent();
        public UnityEvent _OnMouseEnter = new UnityEvent();
        public UnityEvent _OnMouseExit = new UnityEvent();
        protected virtual void OnMouseEnter()
        {
            _OnMouseEnter.Invoke();
        }
        protected virtual void OnMouseExit()
        {
            isHoldingMouse = false;
            _OnMouseExit.Invoke();
        }
        protected virtual void OnMouseDown()
        {
            isHoldingMouse = true;
        }
        protected virtual void OnMouseUp()
        {
            if (isHoldingMouse)
            {
                isHoldingMouse = false;
                OnClick.Invoke();
            }
        }
    }
}

