using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using William.MouseManager;
using William.Utils;
using Wolf.Interaction;

namespace Wolf
{

    /**
      * Classe Joueur qui s'occupe de tout la logique relative au joueur
      * @author William Gingras
      * @version 2018-09-03
      */
    public class Joueur : MonoBehaviour
    {

        #region Singleton
        public static Joueur instance;
        #endregion

        public float vitesseMarche;                            // Vitesse du personnage en marchant
        public float vitesseCourse;                            // Vitesse du personnage en courant
        public float sensibiliterSouris = 1;                   // Mouvement de rotation plus grande du personnage selon cette sensibilité
        public bool controlesPossibles = true;                 // Si false, empêche le joueur d'être contrôlé
        public bool bloquerSouris = true;

        public Animator animBras;                              // Animator des bras
        public Camera cameraJoueur;                            // Référence à la Camera du joueur
        private Transform cameraTransform;                     // Pour changer la position de la caméra ( la tête du joueur )
        private bool enCourse = false;                         // Détermine si le joueur est en train de courir
        private Rigidbody joueurRg;                            // Référence au Rigidbody du joueur

        [Header("Interaction")]
        public InteractionJoueur zoneInteraction;              // Référence au script d'interaction du joueur
        public ZoneInteraction objetSelectionner;              // L'objet qui est sélectionné en ce moment. null = aucun objet

        /**
         * Initialisation des valeurs
         * @param void
         * @return void
        **/
        void Awake()
        {
            instance = this;
            joueurRg = GetComponent<Rigidbody>();
            cameraTransform = transform.Find("CameraParent").transform.Find("Camera");
            MouseManager.SetMouse(true);
            bloquerSouris = true;
        }

        private void Start()
        {
            zoneInteraction.cameraJoueur = cameraJoueur;
            // Quand un objet est sélectionné avec le sélecteur, le joueur reçoit une référence de cet objet
            zoneInteraction.OnSelectionChange.AddListener((t_objSelectionner) => {
                if (t_objSelectionner != null)
                {
                    if (t_objSelectionner.peutEtreUtiliser)
                    {
                        objetSelectionner = t_objSelectionner;
                        GameManager.instance.uiManager.UpdateSelection(objetSelectionner);
                    }
                }
                else
                {
                    GameManager.instance.uiManager.UpdateSelection(t_objSelectionner);
                }
            });
        }

        /**
         * Initialisation des valeurs
         * @param void
         * @return void
        **/
        public void Initialize()
        {
        }

        /**
         * Tout les contrôles du joueur incluants la marche, la caméra et plus ( voir les commentaires de ces 3 fonctions
         * @param void
         * @return void
        **/
        void Update()
        {
            // Si les controlles sont possibles
            if (!controlesPossibles)
                return;
            if (bloquerSouris)
            {
                MouvementJoueur();
                BougerCamera();
                Controlles();
            }
        }

        /** 
         * S'occupe de tout les contrôles sauf de la caméra et du mouvement du joueur, appelé dans Update à chaque frame
         * @param void
         * @return void
         *
        **/
        private void Controlles()
        {
            // Recentrer la souris lors d'un clic
            if (Input.GetMouseButtonDown(0))
            {
                if (bloquerSouris)
                {
                    MouseManager.SetMouse(true);
                    bloquerSouris = true;
                }
            }

            // Touche: E
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Interaction avec objet sélectionné
                if (objetSelectionner != null)
                {
                    objetSelectionner.Interagir();
                    objetSelectionner = null;
                    zoneInteraction.objetSelectionner = null;
                }
            }

            //if (Input.GetKey(KeyCode.Mouse1))
            //    animBras.SetTrigger("regarderMontre");
            // Animation course
            if (Input.GetKey(KeyCode.LeftShift) && !enCourse)
                ToogleCourse();
            else if (Input.GetKeyUp(KeyCode.LeftShift) && enCourse)
                ToogleCourse();
        }

        /**
         * Fonction qui s'occupe du mouvement du joueur en entier, appelée dans Update à chaque frame
         * @param void
         * @return void
        **/
        private void MouvementJoueur()
        {
            float horiz = Input.GetAxisRaw("Horizontal");
            float vert = Input.GetAxisRaw("Vertical");

            Vector3 mouvementDeCoter;
            Vector3 mouvementAvant;

            float vitesse = (enCourse) ? vitesseCourse : vitesseMarche;
            bool deuxDirectionEnMemeTemps = (Mathf.Abs(horiz) == 1 && Mathf.Abs(vert) == 1) ? true : false;

            if (Mathf.Abs(horiz) > 0 || Mathf.Abs(vert) > 0)
                if (vitesse == vitesseMarche)
                {

                    animBras.SetBool("marche", true);
                    animBras.SetBool("course", false);

                }
                else
                {

                    animBras.SetBool("marche", false);
                    animBras.SetBool("course", true);

                }
            else
            {

                animBras.SetBool("marche", false);
                animBras.SetBool("course", false);

            }
            mouvementDeCoter = transform.right * horiz * vitesse / ((deuxDirectionEnMemeTemps) ? 1.5f : 1);
            mouvementAvant = transform.forward * vert * vitesse / ((deuxDirectionEnMemeTemps) ? 1.5f : 1);
            // GetComponent<Rigidbody>().velocity = (mouvementAvant + mouvementDeCoter);//Le dernier vecteur ajoute de la force vers le sol et empêche ainsi le joueur de flotter
            GetComponent<Rigidbody>().velocity = (mouvementAvant + mouvementDeCoter + new Vector3(0, -3, 0));
        }

        /**
         * Fonction qui s'occupe du mouvement de la caméra du joueur
         * @param void
         * @return void
        **/
        private void BougerCamera()
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            float mouseY = Input.GetAxisRaw("Mouse Y");

            float rotAmountX = mouseX * sensibiliterSouris;// Puisque l'axe horizontale est en Y, rotAmountX = rotation en y
            float rotAmountY = mouseY * sensibiliterSouris;// Puisque l'axe verticale est en X, rotAmountY = rotation en x

            Vector3 rotationCamera = cameraTransform.localRotation.eulerAngles;
            Vector3 rotationCorps = transform.rotation.eulerAngles;

            rotationCamera.x -= rotAmountY;// le - exprime l'inversion de la rotation
            rotationCamera.z = 0;// Empêche la rotation en Z
            rotationCorps.y += rotAmountX;// Rotation en Y

            //limite l'angle de la caméra en Verticale
            rotationCamera.x = Utils.LimiteAngle(rotationCamera.x, -90, 90);// Voir la fonction LimiteAngle dans le dossier Resources/SCRIPTS/Extensions/Ext, car le Mathf.Clamp ne suffit pas

            //Rotation de la caméra du joueur
            cameraTransform.localRotation = Quaternion.Euler(rotationCamera);

            //Rotation du corps du joueur
            transform.rotation = Quaternion.Euler(rotationCorps);
        }

        private void ToogleCourse()
        {
            enCourse = !enCourse;
        }

    }

}