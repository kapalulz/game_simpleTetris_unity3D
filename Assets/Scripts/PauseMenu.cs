using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject deadMenuUI;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            Pause();

        if (pauseMenuUI.gameObject.activeSelf || deadMenuUI.gameObject.activeSelf )
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
    } 
    
    public void Dead()
    {
        deadMenuUI.SetActive(true);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
    }
    
    public void Restart()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}