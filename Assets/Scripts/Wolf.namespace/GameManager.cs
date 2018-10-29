using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using William.MouseManager;
using William.Utils;
using Wolf.NPC;
using Wolf.Batiments;
using Wolf.Quetes;
using Wolf.Interaction.Ramassable;

namespace Wolf
{
    public class GameManager : MonoBehaviour
    {

        #region Singleton
        public static GameManager inst; // Instance statique
        private void Awake()
        {
            inst = this;
        }
        #endregion

        public Joueur joueur;
        public VillageManager village;
        public SoundManager soundManager;
        public TextManager textManager;
        public TimeManager timeManager;
        public PopupManager popupManager;
        public DialogueManager dialogueManager;
        public UIManager uiManager;

        private void Start()
        {
            Initialisation();
        }

        public void Initialisation()
        {
            uiManager.Initialisation();
            soundManager.Initialisation();
            timeManager.Initialisation();
            popupManager.Initialisation();
            textManager.Initialisation();
            // Fade onStart
            // uiManager.image_fondNoir.gameObject.SetActive(true); uiManager.image_fondNoir.GetComponent<Animator>().Play("anim_nouveauJour", -1, 0);
        }

        public void RamasserObjet(TypeObjet typeObjet)
        {
            Debug.Log("Joueur a rammassé 1 " + typeObjet.ToString());
        }

        public void JoueurDormir()
        {
            //timeManager.Dormir();
            uiManager.Dormir();
        }

    }
}
