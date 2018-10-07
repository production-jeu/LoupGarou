using UnityEngine;

namespace William.MouseManager
{

    public class MouseManager : MonoBehaviour
    {

        public enum MouseState { LOCKED, UNLOCKED }

        public static void SetMouse(bool locked)
        {

            if (locked == true)
            {

                var lockMode = CursorLockMode.Locked;
                Cursor.lockState = lockMode;
                Cursor.visible = false;

            }
            else if (locked == false)
            {

                var lockMode = CursorLockMode.None;
                Cursor.lockState = lockMode;
                Cursor.visible = true;

            }

        }

    }

}