using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf.JoueurNamespace
{
    /**
     * L'objet qui possède ce script peut emprunter les escaliers sans être bloqué
     * @author William Gingras
     * @version 2018-25-04
     */
    public class DetectionEscaliers : MonoBehaviour
    {
        /**
         * Envoie des Raycasts pour ensuite placer cet objet dessus l'escalier si celui-ci est trouvé
         * @param void
         * @return void
         */
        void Update()
        {
            RaycastHit[] hits;                                           // Les RaycastHit du raycast
            Ray downRay = new Ray(transform.position, transform.up);     // Le Ray en dessous de l'objet
            Ray upRay = new Ray(transform.position, transform.up * -1);  // Le Ray au dessus de l'objet
            float positionCible;                                         // La position de la cible (le hit.point)
            hits = Physics.RaycastAll(downRay, 10f);  // Fait le Raycast
            // Pour chaque impact, on regarde si l'objet est bien un escalier
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                if (hit.collider.tag == "escaliers")
                {
                    positionCible = hit.collider.transform.position.y;
                    transform.position = new Vector3(transform.position.x, hit.point.y + GetComponent<CapsuleCollider>().bounds.size.y - 0.4f, transform.position.z);
                    break;
                }
                else
                {
                    positionCible = transform.position.y;
                }
            }
            hits = Physics.RaycastAll(upRay, 10f);
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                if (hit.collider.tag == "escaliers")
                {
                    positionCible = hit.collider.transform.position.y;
                    transform.position = new Vector3(transform.position.x, hit.point.y + GetComponent<CapsuleCollider>().bounds.size.y - 0.4f, transform.position.z);
                    break;
                }
                else
                {
                    positionCible = transform.position.y;
                }
            }
        }// Fin Update
    }
}