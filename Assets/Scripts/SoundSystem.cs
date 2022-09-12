using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour {

    public static SoundSystem soundSystem;

    public AudioClip die; //
    public AudioClip hit; //
    public AudioClip point; //
    public AudioClip swoosh;
    public AudioClip wing; //

    public AudioSource audioSource;

    private void Awake() {
        if (SoundSystem.soundSystem == null) {
            SoundSystem.soundSystem = this;
        }
        else if (SoundSystem.soundSystem != this) {
            Destroy(gameObject);
            Debug.LogWarning("SoundSystem has been instantiated for the second time. This shouldn't happen.");
        }
    }

    private void OnDestroy() {
        if (SoundSystem.soundSystem == this) {
            SoundSystem.soundSystem = null;
        }
    }

    public void PlayAudioClip(AudioClip audioClip) {
        // audioSource.clip = audioClip;
        // audioSource.Play();
        audioSource.PlayOneShot(audioClip, 1f);
    }
}
