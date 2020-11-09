using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagers : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip restart;
    public AudioClip gameOver;
    public float restartVolume;
    public float gameOverVolume;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void EndGame()
    {
        Debug.Log("End Game");
        audioSource.PlayOneShot(gameOver, gameOverVolume);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Restart()
    {
        audioSource.PlayOneShot(restart, restartVolume);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
