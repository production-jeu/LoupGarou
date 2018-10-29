using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf
{
    /*
     * Manager du son
     * @version 2028-10-22
     * @author William Gingras
     */
    public class SoundManager : MonoBehaviour
    {
        private AudioSource audioSource;           // Source sur cet objet
        private Coroutine coroutineActuelle;       // La coroutine actuelle est storer dans cet objet
        public void Initialisation()
        {
            audioSource = GetComponent<AudioSource>();
        }
        // Effectue une transition entre le volume actuel et un volume cible
        public void VolumeFade(float targetVolume)
        {
            if (coroutineActuelle == null)
            {
                coroutineActuelle = StartCoroutine(C_VolumeFade(targetVolume, 70));
            }
            else
            {
                StopCoroutine(coroutineActuelle);
                coroutineActuelle = StartCoroutine(C_VolumeFade(targetVolume, 70));
            }
        }
        // Effectue une transition entre le volume actuel et un volume cible (Coroutine)
        private IEnumerator C_VolumeFade(float targetVolume, float transitionTime)
        {
            float initialVolume = audioSource.volume;
            for (int x = 0; x < 100; x++)
            {
                yield return null;
                audioSource.volume = Mathf.Lerp(initialVolume, targetVolume, (float)x/100);
            }
            coroutineActuelle = null;
        }
    }
}
