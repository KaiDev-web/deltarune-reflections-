using UnityEngine;

public class MusicManager : MonoBehaviour
{
   
    public static MusicManager Instance { get; private set; }
    private AudioSource audioSource;

    private void Awake()
    {
       
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
      
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    
    public void StopMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}