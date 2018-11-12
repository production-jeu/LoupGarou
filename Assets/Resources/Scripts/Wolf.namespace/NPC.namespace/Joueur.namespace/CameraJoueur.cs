using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf.JoueurNamespace
{
    public class CameraJoueur : MonoBehaviour
    {
        public Vector3 posInitiale;                   // Position d'origine de la caméra
        private Transform cibleRegard;                // Cible que la caméra doit regarder
        private Coroutine coroutineActuelle = null;   // Cette variable contient un référence à la coroutine qui est actuellement en cours
        private Joueur joueur;                        // Ref du joueur
        public Transform pointTest, pointTestRegard, pointTestRegard2;  // TEST VALUES
        private void Start()
        {
            joueur = GameManager.inst.joueur;
            posInitiale = transform.localPosition;
            StartCoroutine(test());
        }
        // Fait aller la caméra au point voulue avec une transition
        // Il est également possible de demander à la caméra de regarder une cible
        public void AllerAuPoint(Vector3 posCible, float vitesse = 1, Transform cibleRegard = null)
        {
            if (coroutineActuelle != null)
                return;
            if (cibleRegard != null)
            {
                this.cibleRegard = cibleRegard;
            }
            joueur.controlesPossibles = false; // Bloque les controlles du joueur
            joueur.SetJoueurVisible(false);
            Vector3 direction = cibleRegard.position - joueur.transform.position;
            Quaternion rotCible = Quaternion.LookRotation(direction);
            Quaternion rotOrigine = transform.rotation;
            coroutineActuelle = StartCoroutine(C_TransitionEntreDeuxPoint(transform.position, posCible, rotOrigine, rotCible, vitesse));
        }
        // Fait retourner la caméra à son point d'origine
        public void RetourOrigine(float vitesse = 1, Transform cibleRegard = null)
        {
            if (coroutineActuelle != null)
                return;
            cibleRegard = null;
            Quaternion rotCible = joueur.transform.rotation;
            Quaternion rotOrigine = transform.rotation;
            // On prend la 'posInitiale' qui est locale au joueur pour qu'elle soit locale au monde à la place, puisque que l'on change le transform.position dans la coroutine
            coroutineActuelle = StartCoroutine(C_TransitionEntreDeuxPoint(transform.position, joueur.transform.TransformPoint(posInitiale), rotOrigine, rotCible, 1, ()=> {
                joueur.controlesPossibles = true;
                joueur.SetJoueurVisible(true);
            }));
        }
        public IEnumerator C_TransitionEntreDeuxPoint(Vector3 pointOrigine, Vector3 pointCible, Quaternion rotOrigine, Quaternion rotCible, float vitesse, System.Action OnFinTransition = null)
        {
            int nbEtapes = (int)(Mathf.Max(1, 100 / vitesse));
            for (var x = 0; x < nbEtapes; x++)
            {
                if (x > 5000)
                {
                    Debug.LogError("oups!");
                    transform.position = pointCible;
                    yield break;
                }
                // Si on ne regarde pas la cible, on retourne progressivement vers une rotation de zero
                transform.rotation = Quaternion.Lerp(  rotOrigine,    rotCible,   (float)x / nbEtapes  );
                transform.position = Vector3.Lerp(     pointOrigine,  pointCible, (float)x / nbEtapes  );
                yield return null; // Skip un frame
            }

            // Pour être sur que les bonne valeur sont mise, on assigne les valeurs finales
            transform.position = pointCible;
            transform.rotation = rotCible;

            // Fonction exécutée à la fin de la transition
            if (OnFinTransition != null)
                OnFinTransition();
            coroutineActuelle = null;
        }

        public IEnumerator test()
        {
            yield return new WaitForSeconds(4);
            AllerAuPoint(pointTest.position, 1f, pointTestRegard);
            yield return new WaitForSeconds(4);
            RetourOrigine(0.5f, pointTestRegard2);
            yield return new WaitForSeconds(4);
            AllerAuPoint(pointTest.position, 1f, pointTestRegard);
            yield return new WaitForSeconds(4);
            RetourOrigine(1f, pointTestRegard2);
        }

    }
}
