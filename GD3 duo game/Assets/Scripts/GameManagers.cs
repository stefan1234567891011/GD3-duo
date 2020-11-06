using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagers : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip restart;
    public AudioClip gameOver;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void EndGame()
    {
        Debug.Log("End Game");
        audioSource.PlayOneShot(gameOver);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Restart()
    {
        audioSource.PlayOneShot(restart);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
