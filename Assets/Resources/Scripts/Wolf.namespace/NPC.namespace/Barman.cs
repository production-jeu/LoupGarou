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
<<<<<<< HEAD:Assets/Resources/Scripts/Wolf.namespace/NPC.namespace/Barman.cs
    public class Barman : Personnage
=======

    public class Personnage : MonoBehaviour
>>>>>>> 2eedb375508aa01cc4769b5f7e1b72f0326cce8a:Assets/Scripts/Wolf.namespace/NPC.namespace/Personnage.cs
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
        /*Nom du type d'action ("dormir","promenade")*/
        public string typeAction;

        public void Start()
        {
            //FlanerBatiment(batiment.gameObject, false);
            //Time.timeScale = 5;
            attendrePosition(DestinationCible, false);
        }

        public void Update()
        {

            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                /*Si le batiment a une porte et il va vers elle*/

            //print(pointAleatoireNavMesh(DestinationCible, 5f));
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {

                if (batiment.porte != null && DestinationCible.name == "Porte")
                {
                    if (typeAction == "dormir")
                    {
                        AllerAuLit();
                    }


                    if (typeAction == "promenade")
                    {
                        batiment.porte.TooglePorte();
                        Invoke("RefermerPorte", 1.5f);
                        print(batiment.gameObject.name);
                        DestinationCible = batiment.gameObject;
                        FlanerBatiment(DestinationCible, false);
                    }

                }
                else /*Si il ne va pas vers une porte action pour l'intérieur*/
                {

                    switch (typeAction) {
                        case "dormir": 
                        Interruption(true);
                        GetComponent<CapsuleCollider>().enabled = false;
                        transform.position = ((Maison)batiment).lit.gameObject.transform.position + new Vector3(0.2f, -0.55f, 0.55f);
                        transform.eulerAngles = new Vector3(8, ((Maison)batiment).lit.gameObject.transform.eulerAngles.y + 90, transform.eulerAngles.z);
                        batiment.porte.porteBarrer = true;
                        anim.SetTrigger("dormir");
                        break;


                        case "promenade":
                        DestinationCible = batiment.gameObject;
                        FlanerBatiment(DestinationCible, false);
                        break;

                        case "attendre":
                            Interruption(true);
                            anim.SetTrigger("attendre");
                            break;

                            
                            default: break;
                  
                    }
                }





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
        public void AllerDormir()
        {
            if (importanceAction < 5)
            {
                typeAction = "dormir";
                importanceAction = 5;
                DestinationCible = batiment.porte.gameObject;
                agent.SetDestination(DestinationCible.transform.position);
            }
        }

        /**
         * Le villagois ouvre la porte de sa maison et la referme
         * pour aller s'étendre dans son lit
         */
        public void AllerAuLit()
        {



            if (batiment.porte != null)
            {
                batiment.porte.TooglePorte();
                Invoke("RefermerPorte", 1.5f);
            }
            DestinationCible = ((Maison)batiment).lit.gameObject;
            agent.SetDestination(DestinationCible.transform.position);

        }

        /*
         Referme une porte précédemment ouverte par le personnage
             */
        public void RefermerPorte()
        {
            batiment.porte.TooglePorte();
        }

        /*
        Stoppe l'agent navMesh
        @bool force  //Peut contraindre le personnage à s'arretêr
        */

        public void Interruption(bool force)
        {
            if (importanceAction < 3 || force)
            {
                agent.isStopped = true;
            }
        }


        /*
        Remet en route le personnage en résumant le trajet du nav mesh agent
        */
        public void Reprise()
        {
            agent.isStopped = false;
            agent.SetDestination(DestinationCible.transform.position);
        }


        /*
        Désigne un batîment où le personnage ira se promener 
        le personnage reste dans une zone restreinte autour de ce batîment;
        @batiment //Le batîment cible
        @bool force  //Peut contraindre le personnage à se rendre au point ciblé
        */
        public void FlanerBatiment(GameObject batimentCible, bool force)
        {
            if (batimentCible.GetComponent<Batiment>() != null)
            {
                if (importanceAction < 3 || force)
                {
                    typeAction = "promenade";


                    if (DestinationCible != batimentCible && batimentCible.GetComponent<Batiment>().porte != null)

                    if (batimentCible.GetComponent<Batiment>().porte != null)

                    {
                        DestinationCible = batimentCible.GetComponent<Batiment>().porte.gameObject;
                        agent.SetDestination(DestinationCible.transform.position);
                    }
                    else
                    {
                        DestinationCible = batimentCible.gameObject;

                        agent.SetDestination(pointAleatoireNavMesh(DestinationCible, 10));

                        agent.SetDestination(pointAleatoireNavMesh(DestinationCible, 5f));


                    }


                }
            }
        }


        /*
        Désigne un point où le personnage ira se promener 
        le personnage reste dans une zone restreinte autour de ce batîment;
        @batiment //La position
        @bool force  //Peut contraindre le personnage à se rendre au point ciblé
        */
        public void attendrePosition(GameObject positionCible, bool force)
        {
            if (importanceAction < 3 || force)
            {
                typeAction = "attendre";
                agent.SetDestination(positionCible.transform.position);
            }
        }




        public Vector3 pointAleatoireNavMesh(GameObject batimentPromenade, float rayon)
        {
            NavMeshHit hit;
            Vector3 aleatoire = new Vector3(Random.Range(-rayon, rayon), 0, Random.Range(-rayon, rayon));
            NavMesh.FindClosestEdge(batimentPromenade.transform.position, out hit, NavMesh.AllAreas);

            return hit.position;
        }



    }
}