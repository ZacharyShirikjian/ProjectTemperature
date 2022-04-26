using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    public AudioClip switchFire;
    public AudioClip switchIce;
    public AudioClip FireSpell;
    public AudioClip levelComplete;
    //Instance of this script, used on DontDestroyOnLoad
    private static SFXManager instance;
    private void Awake()
    {
        //If there is already an instance of this script in the current scene, then delete this duplicated instance 
        if (instance != null)
        {
            Destroy(gameObject);
        }

        //Otherwise, if there is no other instances of this script in the current scene, then make sure that it doesn't get deleted with DontDestroyOnLoad()
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject); //DontDestroyOnLoad is applied to the current gameObject with the AudioManager script on it 
        }
    }
}
