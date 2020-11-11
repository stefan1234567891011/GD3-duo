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
        ReloadScene();
    }

    public void Restart()
    {
        audioSource.PlayOneShot(restart);
        ReloadScene();
    }

    private void ReloadScene()
    {
        Destroy(gameObject, 1);
    }

    private void OnDestroy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
