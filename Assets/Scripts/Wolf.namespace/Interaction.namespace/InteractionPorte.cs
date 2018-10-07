using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wolf.Interaction;

public class InteractionPorte : ZoneInteraction
{
    public Animator anim_porte;
    public bool porteBarrer = false;
    public bool porteOuverte = false;
    public AudioClip sonPorteOuvrir;
    public AudioClip sonPorteFermer;
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public override void Interagir()
    {
        base.Interagir();
        if(!porteBarrer)
            TooglePorte();
    }
    public void TooglePorte()
    {
        StartCoroutine(AttendreFinAnimationPorte(1.2f));
        porteOuverte = !porteOuverte;
        if (porteOuverte)
        {
            // jouer son
            anim_porte.Play("ouvrir_porte", -1, 0);
            audioSource.clip = sonPorteOuvrir;
            if(audioSource.clip != null)
                audioSource.Play();
        }
        else
        {
            // jouer son
            anim_porte.Play("fermer_porte", -1, 0);
            audioSource.clip = sonPorteFermer;
            if (audioSource.clip != null)
                audioSource.Play();
        }
    }
    private IEnumerator AttendreFinAnimationPorte(float temps)
    {
        peutEtreUtiliser = false;
        yield return new WaitForSeconds(temps);
        peutEtreUtiliser = true;
    }
}
