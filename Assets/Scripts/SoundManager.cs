using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
        public AudioSource efxSource;                    //Drag a reference to the audio source which will play the sound effects.
        public AudioSource musicSource;                    //Drag a reference to the audio source which will play the music.
        public static SoundManager instance = null;        //Allows other scripts to call functions from SoundManager.                
        public float lowPitchRange = .95f;                //The lowest a sound effect will be randomly pitched.
        public float highPitchRange = 1.05f; 
    // Start is called before the first frame update
    void Awake()
    {
                    //Check if there is already an instance of SoundManager
            if (instance == null)
                //if not, set it to this.
                instance = this;
            //If instance already exists:
            else if (instance != this)
                //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
                Destroy (gameObject);

            //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
            DontDestroyOnLoad (gameObject);
            

    }

    // play one sound with no randomization
    public void PlaySfx(AudioClip sfc) {
        efxSource.clip = sfc;
        efxSource.Play();
    }

        // pass in any number of AudioClips with commas between them
        public void RandomizeSfx (params AudioClip[] clips)
        {

            int randomIndex = Random.Range(0, clips.Length);

            //Choose a random pitch to play back our clip at between our high and low pitch ranges.
            float randomPitch = Random.Range(lowPitchRange, highPitchRange);

            //Set the pitch of the audio source to the randomly chosen pitch.
            efxSource.pitch = randomPitch;

            //Set the clip to the clip at our randomly chosen index.
            efxSource.clip = clips[randomIndex];

            //Play the clip.
            efxSource.Play();
        }
}
