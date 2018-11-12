using UnityEngine;
using Wolf.Interaction.Ramassable;
using Wolf.NPC;
using Wolf.Dialogues;

namespace Wolf
{
    public enum TypePersonnage { TOUS, FOU, PRETRE, CHIEN, HERBORISTE, BARMAN, VOLEUSE, CHASSEUR, SORCIERE };
    public enum Sexe { HOMME, FEMME };
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
        public Personnage loupGarou;                 // Référence au personnage qui est le loup-garou
        public VillageManager village;
        public SoundManager soundManager;
        public TextManager textManager;
        public TimeManager timeManager;
        public PopupManager popupManager;
        public DialogueManager dialogueManager;
        public ConteneurDialogues conteneurDialogues;
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
            joueur.Initialisation();
            textManager.Initialisation();
            dialogueManager.Initialisation();
            conteneurDialogues.Initialisation();
            popupManager.Initialisation();
            village.Initialisation();
            /*Début du jeu*/
            CommencerJour();
        }

        public void RamasserObjet(TypeObjet typeObjet)
        {
            Debug.Log("Joueur a rammassé 1 " + typeObjet.ToString());
        }

        public void JoueurDormir()
        {
            // timeManager.Dormir();
            // uiManager.Dormir();
            // Affiche le popup qui montre les morts avec une animation

            // Le loup-garou tue un personnage ou le joueur
            village.ActionsNuit();
            timeManager.jour++;
            if (joueur.estVivant)
            {
                popupManager.AjouterDemandePopup(() =>
                {
                    popupManager.AfficherPopup(popupManager._PopupMorts, false);
                    popupManager._PopupMorts.MontrerPopupNuit();
                });
            }
            else
            {
                MortJoueur(true);
            }
        }

        public void CommencerJour()
        {
            village.NouveauJour();
            timeManager.CommencerJour();
        }
        // Ce n'est pas ici que les actions sont prises, cette fonction fait simplement mettre le jeu en mode chasse où le LP
        // Tente de tuer le joueur en temps réel.
        public void CommencerNuit()
        {
            
        }
        // Le joueur à été tué! S'occupe d'afficher la fin du jeu et de ramener le joueur au menu.
        public void MortJoueur(bool pendantLaNuit)
        {
            print("Fin jeu! Le loup-garou était: " + loupGarou.nom);
        }
    }
}
