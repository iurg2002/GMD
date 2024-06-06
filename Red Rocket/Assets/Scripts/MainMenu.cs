using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip startSound; 
    public AudioClip quitSound; 

    public void StartMainMenu()
    {
        PlaySound(startSound);
        StartCoroutine(LoadSceneAfterDelay(1, startSound.length)); 
    }

    public void QuitGame()
    {
        PlaySound(quitSound);
        StartCoroutine(QuitGameAfterDelay(quitSound.length)); 
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    private IEnumerator LoadSceneAfterDelay(int sceneIndex, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    private IEnumerator QuitGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Application.Quit();

        
    }
}
