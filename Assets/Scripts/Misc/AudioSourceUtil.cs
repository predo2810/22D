using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceUtil : MonoBehaviour
{
    [SerializeField] private AudioClip[] SoundsToPlay;

    private int LastPlayed = -1;

    public void PlayRandomSound()
    {
        int random = 0;

        while (random == LastPlayed)
            random = Random.Range(0, SoundsToPlay.Length);

        LastPlayed = random;

        GetComponent<AudioSource>().PlayOneShot(SoundsToPlay[random]);
    }
}
