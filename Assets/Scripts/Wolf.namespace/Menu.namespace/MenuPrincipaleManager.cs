using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Wolf.Menu
{
    public class MenuPrincipaleManager : MonoBehaviour
    {
        Animator animator;
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        private void Start()
        {
            animator.Play("anim_menu_ouverture", -1, 0);
        }
        public void CommencerJeu()
        {
            StartCoroutine(C_CommencerJeu());
        }
        public void FermerJeu()
        {
            Application.Quit();
        }

        private IEnumerator C_CommencerJeu()
        {
            animator.Play("anim_menu_fermeture", -1, 0);
            yield return new WaitForSeconds(2.5f);
            SceneManager.LoadScene("Jeu");
        }
    }
}
