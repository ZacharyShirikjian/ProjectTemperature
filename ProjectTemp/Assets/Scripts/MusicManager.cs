using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    //Ref to this Audio Source
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip titleTrack;
    [SerializeField] private AudioClip gameTrack;

    //Instance of this script, used on DontDestroyOnLoad
    private static MusicManager instance;
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

    public void SwitchSong(string song)
    {
        if (song == "Title")
        {
            source.clip = titleTrack;
            source.Play();
        }

        else if (song == "Gameplay")
        {
            source.clip = gameTrack;
            source.Play();
        }
    }
}
