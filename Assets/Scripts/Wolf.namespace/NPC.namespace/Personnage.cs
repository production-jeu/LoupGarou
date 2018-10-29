using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wolf.Batiments;
using UnityEngine.AI;

/**
 * @Author Tommy Lizotte
 * @Date 2018-10-29
 * 
*/

namespace Wolf.NPC
{
   
    public class Personnage : MonoBehaviour
    {
        /*Référence de batiment*/
        public Batiment batiment;
        /*Niveau d'importance de l'action en cours*/
        public int importanceAction;
        /*L'objet cible du personnage*/
        public GameObject DestinationCible;
        /*Agent navMesh*/
        public NavMeshAgent agent;
        /*Animator du personnage*/
        public Animator anim;


        public void Start() {
            AllerDormir();
            Time.timeScale = 5;
        }

        public void Update() {
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance) {
                if (batiment.porte != null && DestinationCible.name == "Porte")
                {
                    AllerAuLit();
                }
                else {
                    Interruption(true);
                    GetComponent<CapsuleCollider>().enabled = false;
                    transform.position = ((Maison)batiment).lit.gameObject.transform.position + new Vector3(-0.5f,-0.55f,0f);
                    transform.eulerAngles = new Vector3(8, ((Maison)batiment).lit.gameObject.transform.eulerAngles.y+90, transform.eulerAngles.z);
                    batiment.porte.porteBarrer = true;
                    anim.SetTrigger("dormir");
                }

            }
        }

        /*
        * interompt l'action en cours 
        * 
        * Dirige le personnage vers la porte de sa maison
        * le personnage ouvre et ferme la porte et est 
        * envoyé à son lit pour dormir, il a une animation de 
        * sommeil
       
        */
        public void AllerDormir() {
            if (importanceAction < 5) { 
            importanceAction = 5;
            DestinationCible = batiment.porte.gameObject;
            agent.SetDestination(DestinationCible.transform.position);
        }
        }

        /**
         * Le villagois ouvre la porte de sa maison et la referme
         * pour aller s'étendre dans son lit
         */
        public void AllerAuLit() {
            if (batiment.porte != null) { 
                batiment.porte.TooglePorte();
                Invoke("RefermerPorte", 1.5f);
            }
            DestinationCible = ((Maison)batiment).lit.gameObject;
            agent.SetDestination(DestinationCible.transform.position);
           
        }
        public void RefermerPorte() {
            batiment.porte.TooglePorte();
        }


        public void Interruption(bool force) {
            if (importanceAction < 3 || force) {
                agent.isStopped = true;
        }
        }

        public void Reprise() {
            agent.isStopped = false;
            agent.SetDestination(DestinationCible.transform.position);
        }

    }
}
