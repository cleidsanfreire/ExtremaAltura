using UnityEngine;

public class FundoMusical : MonoBehaviour
{

    [SerializeField] private AudioClip[] audioClips;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        int randomClip = Random.Range(0, audioClips.Length);

        audioSource.clip = audioClips[randomClip];
        audioSource.Play();
    }
}
