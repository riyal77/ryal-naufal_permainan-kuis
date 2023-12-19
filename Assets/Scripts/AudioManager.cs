using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Singleton
    public static AudioManager instance = null;

    [SerializeField]
    private AudioSource bgmPrefab = null;

    [SerializeField]
    private AudioSource sfxPrefab = null;

    [SerializeField]
    private AudioClip[] bgmClips = new AudioClip[0];

    private AudioSource bgmAja = null;

    private AudioSource sfxAja = null;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Objeck \"Audio Manager\" sudah ada.\n" + "Hapus objek serupa.", instance);
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        bgmAja = Instantiate(bgmPrefab);
        DontDestroyOnLoad(bgmAja);

        sfxAja = Instantiate(sfxPrefab);
        DontDestroyOnLoad(sfxAja);
    }

    void OnDestroy()
    {
        if (this.Equals(instance))
        {
            instance = null;

            if (bgmAja != null)
            {
                Destroy(bgmAja.gameObject);
            }

            if (sfxAja != null)
            {
                Destroy(sfxAja.gameObject);
            }
        }
    }

    public void PlayBGM(int index)
    {
        if (bgmAja.clip == bgmClips[index])
        {
            return;
        }

        bgmAja.clip = bgmClips[index];
        bgmAja.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxAja.PlayOneShot(clip);
    }
}
