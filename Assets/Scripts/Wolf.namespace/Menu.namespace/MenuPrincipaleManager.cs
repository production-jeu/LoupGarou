using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Wolf.Menu
{
    public class MenuPrincipaleManager : MonoBehaviour
    {
        public void CommencerJeu()
        {
            SceneManager.LoadScene("Jeu");
        }
        public void FermerJeu()
        {
            Application.Quit();
        }
    }
}
