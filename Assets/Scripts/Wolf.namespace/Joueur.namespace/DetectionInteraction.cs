using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Wolf.Interaction;
using Wolf.Events;

namespace Wolf.JoueurNamespace
{
    public class DetectionInteraction : MonoBehaviour
    {
        public Camera cameraJoueur;
        public ZoneInteraction objetSelectionner;              // L'objet qui est sélectionné en ce moment. null = aucun objet
        public ZoneInteractionEvent OnSelectionChange;         // Appelé lors d'un changement de sélection
        public float distanceInteraction = 1f;
        public bool canInteractWithRaycast = true;
        private void Awake()
        {
            OnSelectionChange = new ZoneInteractionEvent();
        }
        private void Update()
        {
            if (canInteractWithRaycast)
            {
                int layerMask = 1 << 9;
                layerMask = ~layerMask;
                Ray ray = cameraJoueur.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;
                if (Physics.Raycast(ray.origin, ray.direction, out hit, distanceInteraction, layerMask))
                {
                    objetSelectionner = hit.transform.GetComponent<ZoneInteraction>();
                    // Détermine si l'interaction est possible
                    OnSelectionChange.Invoke(objetSelectionner);
                }
                else
                {
                    if (objetSelectionner != null)
                    {
                        objetSelectionner = null;
                        OnSelectionChange.Invoke(null);
                    }
                }
            }
        }
        #region OBSOLETE
        [System.Obsolete]
        private bool canInteractWithCollider = false;
        [System.Obsolete]
        private bool searchForOtherObject = false;
        [System.Obsolete]
        private void OnTriggerStay(Collider objCollision)
        {
            if(canInteractWithCollider)
                if (objCollision.tag == "interactif" && searchForOtherObject)
                {
                    searchForOtherObject = false;
                    objetSelectionner = objCollision.GetComponent<ZoneInteraction>();
                    OnSelectionChange.Invoke(objetSelectionner);
                    Debug.Log("nv obj interactif trouver");
                }
        }
        [System.Obsolete]
        private void OnTriggerEnter(Collider objCollision)
        {
            if (canInteractWithCollider)
                if (objCollision.tag == "interactif")
                {
                    objetSelectionner = objCollision.GetComponent<ZoneInteraction>();
                    OnSelectionChange.Invoke(objetSelectionner);
                    Debug.Log("nv obj interactif");
                }
        }
        [System.Obsolete]
        private void OnTriggerExit(Collider objCollision)
        {
            if(canInteractWithCollider)
                if (objCollision.tag == "interactif")
                {
                    objetSelectionner = null;
                    OnSelectionChange.Invoke(objetSelectionner);
                }
        }
        #endregion
    }
}

