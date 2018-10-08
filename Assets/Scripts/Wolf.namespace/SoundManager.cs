using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolf
{
    public class SoundManager : MonoBehaviour
    {
        private AudioSource audioSource;
        private Coroutine coroutineActuelle;
        public void Initialisation()
        {
            audioSource = GetComponent<AudioSource>();
        }
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
