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

    bool hasPressed;

    // Start is called before the first frame update
    void Start()
    {
        bulletsLeft = bulletsMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (fireAction.action.WasPressedThisFrame())
        {

            fire();
            hasPressed = true;

        }else 
        
        if (reloadAction.action.WasPressedThisFrame())
        {
            reload();
            hasPressed = true;

        } else
        {
            hasPressed = false;
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
