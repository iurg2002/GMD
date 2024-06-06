using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public string nextLevelName;
    public AudioSource audioSource; 
    public AudioClip winSound; 
    public static bool isLevelTransitioning;

    private Animator playerAnimator; // Reference to the player's animator
    private bool hasDied = false; // To ensure the dying process happens only once

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasDied)
        {
            Debug.Log("Player touched the transition object");
            isLevelTransitioning = true; 
            hasDied = true;
            
            playerAnimator = collision.GetComponent<Animator>(); // Get the player's animator component
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger("Die"); // Trigger the dying animation
            }

            PlayWinSoundAndLoadNextLevel(); 
        }
    }

    void PlayWinSoundAndLoadNextLevel() 
    {
        if (audioSource != null && winSound != null)
        {
            audioSource.PlayOneShot(winSound);
        }

        float delay = winSound != null ? winSound.length : 0f;
        delay = Mathf.Max(delay, GetAnimationLength("Die", playerAnimator)); // Get the longer delay

        Invoke(nameof(LoadNextLevel), delay);
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }

    float GetAnimationLength(string animationName, Animator animator)
    {
        if (animator == null) return 0f;

        RuntimeAnimatorController ac = animator.runtimeAnimatorController;    
        for (int i = 0; i < ac.animationClips.Length; i++)
        {
            if (ac.animationClips[i].name == animationName)
            {
                return ac.animationClips[i].length;
            }
        }
        return 0f;
    }
}
