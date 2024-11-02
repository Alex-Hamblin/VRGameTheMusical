using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Deagle : MonoBehaviour
{

    [SerializeField] InputActionProperty fireAction;
    [SerializeField] InputActionProperty reloadAction;

    [SerializeField] int bulletsLeft;
    [SerializeField] int bulletsMax;

    [SerializeField] AudioClip fireSFX;
    [SerializeField] AudioClip emptyFireSFX;
    [SerializeField] AudioClip reloadSFX;

    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        bulletsLeft = bulletsMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (fireAction.action.ReadValue<bool>())
        {

            fire();

        }else 
        
        if (reloadAction.action.ReadValue<bool>())
        {
            reload();

        }
    }


    void reload()
    {
        bulletsLeft = bulletsMax;
        PlayAudioClip(reloadSFX);

    }

    void fire()
    {
        if (bulletsLeft > 0)
        {
            bulletsLeft--;
            PlayAudioClip(fireSFX);
        } else
        {
            PlayAudioClip(emptyFireSFX);
        }
    }

    void PlayAudioClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
