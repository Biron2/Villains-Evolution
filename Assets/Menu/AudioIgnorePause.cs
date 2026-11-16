using UnityEngine;
public class AudioIgnorePause : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.ignoreListenerPause = true;
    }
}
