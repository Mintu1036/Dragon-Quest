using UnityEngine;

public class MenuSoundManager : MonoBehaviour
{
    public static MenuSoundManager instance;

    private AudioSource source;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}