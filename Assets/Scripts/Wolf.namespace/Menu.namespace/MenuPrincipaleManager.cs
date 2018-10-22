using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Wolf.Menu
{
    public class MenuPrincipaleManager : MonoBehaviour
    {
        Animator animator;
        public Button[] bouttonsMenu;
        public GameObject[] particules;
        public bool controllesPossible = true;
        public RectTransform selecteur;
        public Vector2 bond = new Vector2(0, 118);
        int indexSelecteurMin = 0;
        public int indexSelecteurMax = 3;
        Vector2 posInitialeSelecteur;
        int indexSelecteur = 0;
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        private void Start()
        {
            animator.Play("anim_menu_ouverture", -1, 0);
            posInitialeSelecteur = selecteur.anchoredPosition;
            bouttonsMenu[indexSelecteur].Select();
        }
        private void Update()
        {
            if (!controllesPossible)
                return;
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                int increment = (int)Input.GetAxisRaw("Vertical");
                if (indexSelecteur - increment >= indexSelecteurMin && indexSelecteur - increment <= indexSelecteurMax) {
                    indexSelecteur -= increment;
                    selecteur.anchoredPosition = posInitialeSelecteur + new Vector2(0, -118 * indexSelecteur);
                    bouttonsMenu[indexSelecteur].Select();
                }
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                // Si on appuie sur 'jouer'
                if (indexSelecteur == 0)
                    controllesPossible = false;
                bouttonsMenu[indexSelecteur].onClick.Invoke();
            }
        }
        public void CommencerJeu()
        {
            StartCoroutine(C_CommencerJeu());
        }
        public void ChargerPartie()
        {

        }
        public void OuvrirFicheAide()
        {

        }
        public void FermerJeu()
        {
            Application.Quit();
        }
        public void FinAnimationOuverture()
        {
            foreach (GameObject particule in particules)
            {
                particule.SetActive(true);
            }
        }

        private IEnumerator C_CommencerJeu()
        {
            animator.Play("anim_menu_fermeture", -1, 0);
            yield return new WaitForSeconds(2.5f);
            SceneManager.LoadScene("Jeu");
        }
    }
}
