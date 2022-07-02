using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    static AudioSource audioSource = null;

    private void Awake() {
        if(audioSource != null) {
            Destroy(gameObject);
        } else {
            audioSource = GetComponent<AudioSource>();
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
