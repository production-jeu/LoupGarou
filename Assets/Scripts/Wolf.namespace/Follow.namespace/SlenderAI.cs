using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf.Follow
{
    public class SlenderAI : MonoBehaviour
    {
        public Renderer rend;
        Rigidbody rg;
        Transform transformJoueur;
        private void Start()
        {
            rg = GetComponent<Rigidbody>();
            transformJoueur = GameManager.instance.joueur.transform;
        }
        void Update()
        {
            if (!rend.isVisible)
            {
                var pos = transform.position;
                var dir = transformJoueur.position - pos;
                dir.Normalize();
                rg.velocity = new Vector3(dir.x, 0, dir.z) * 3;
            }
            else
            {
                rg.velocity = Vector3.zero;
            }
        }
    }
}
