using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public string nextLevelName;
    public AudioSource audioSource; 
    public AudioClip winSound; 
    public static bool isLevelTransitioning;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player touched the transition object");
            isLevelTransitioning = true; 
            PlayWinSoundAndLoadNextLevel(); 
        }
    }

    void PlayWinSoundAndLoadNextLevel() 
    {
        if (audioSource != null && winSound != null)
        {
            audioSource.PlayOneShot(winSound);
        }

        Invoke(nameof(LoadNextLevel), winSound.length);
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}
