using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Wolf.Menu
{
    public class MenuPrincipaleManager : MonoBehaviour
    {
        Animator animator;
        public RectTransform selecteur;
        public Vector2 bond = new Vector2(0, 118);
        public int indexSelecteurMin = 0;
        public int indexSelecteurMax = 2;
        Vector2 posInitialeSelecteur;
        int indexSelecteur = 0;
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        private void Start()
        {
            //animator.Play("anim_menu_ouverture", -1, 0);
            posInitialeSelecteur = selecteur.anchoredPosition;
        }
        private void Update()
        {
            if (Input.GetButtonDown(KeyCode.W) || Input.GetButtonDown(KeyCode.UpArrow) || Input.GetButtonDown(KeyCode.DownArrow)) {
                indexSelecteur += (int)Input.GetAxisRaw("Vertical");
                selecteur.anchoredPosition += new Vector2(0, 118);
            }
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
