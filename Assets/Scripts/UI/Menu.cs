using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _endGameMenu;
    [SerializeField] private Player _player;

    private Scene _scene;

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }

    private void OnEnable()
    {
        _player.PlayerDied += OnPlayerDied;
    }

    private void OnDisable()
    {
        _player.PlayerDied += OnPlayerDied;        
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        _endGameMenu.SetActive(false);
        SceneManager.LoadScene(_scene.buildIndex);
        Time.timeScale = 1;
    }

    private void OnPlayerDied()
    {
        _endGameMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
