using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf.NPC
{
    public class NpcUI : MonoBehaviour
    {
        public bool regarderPoint = true;
        public Transform pointRegarder;
        private void Update()
        {
            if (pointRegarder != null && regarderPoint)
            {
                Vector3 pointRegarderSansY = new Vector3(pointRegarder.transform.position.x, transform.position.y, pointRegarder.transform.position.z);
                transform.LookAt(pointRegarderSansY);
            }
        }
    }
}
