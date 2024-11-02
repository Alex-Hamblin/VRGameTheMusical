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
    [SerializeField] GameObject muzzle;
    [SerializeField] GameObject muzzleflash;

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
           

        }
        else

        if (reloadAction.action.WasPressedThisFrame())
        {
            reload();
            hasPressed = true;

        }
        else
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
            muzzleflash.GetComponent<ParticleSystem>().Play();
            RaycastHit hit;
            if (Physics.Raycast(muzzle.transform.position, transform.forward, out hit, 500f))
            {
                Debug.DrawRay(muzzle.transform.position, transform.forward * 500f, Color.red);
                //IF hit is enemy deal damage

            }


        }
        else
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

