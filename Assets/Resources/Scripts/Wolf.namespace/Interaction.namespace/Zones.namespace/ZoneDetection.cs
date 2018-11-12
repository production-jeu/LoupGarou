using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wolf.Interaction.Zones
{
    public class ZoneDetection : MonoBehaviour
    {
        public bool joueurEstDansLaZone = false;
        public UnityEvent OnZoneEnter;
        public UnityEvent OnZoneLeave;
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "joueur")
            {
                joueurEstDansLaZone = true;
                OnZoneEnter.Invoke();
                //Debug.Log("Joueur enter zone");
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "joueur")
            {
                joueurEstDansLaZone = false;
                OnZoneLeave.Invoke();
                //Debug.Log("Joueur leave zone");
            }
        }
    }
}
