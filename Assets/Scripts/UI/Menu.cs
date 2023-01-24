using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _endGameMenu;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _shopMenu;
    [SerializeField] private Player _player;
    [SerializeField] private AudioMixerGroup _mixer;

    private bool _isPaused = false;
    private readonly string _musicGroupName = "MusicVolume";
    private readonly string _effectsGroupName = "EffectsVolume";
    private Scene _scene;

    public bool IsPaused => _isPaused;

    public event UnityAction<bool> GamePaused;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            _player.ChangeBullet();

        if (Input.GetKeyDown(KeyCode.P))
            OpenPanel(_pauseMenu);

        if (Input.GetKeyDown(KeyCode.M))
            OpenPanel(_shopMenu);
    }

    public void ClosePanel(GameObject panel)
    {
        _isPaused = false;
        GamePaused?.Invoke(_isPaused);
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(_scene.buildIndex);
        ClosePanel(_endGameMenu);
    }

    public void ToggleMusic(bool enabled)
    {
        ToggleSound(enabled, _musicGroupName);
    }

    public void ToggleEffects(bool enabled)
    {
        ToggleSound(enabled, _effectsGroupName);
    }

    private void ToggleSound(bool enabled, string groupName)
    {
        float enabledVolumeLevel = 0;
        float disabledVolumeLevel = -80;

        if (enabled)
            _mixer.audioMixer.SetFloat(groupName, enabledVolumeLevel);
        else
            _mixer.audioMixer.SetFloat(groupName, disabledVolumeLevel);
    }

    private void OpenPanel(GameObject panel)
    {
        _isPaused = true;
        GamePaused?.Invoke(_isPaused);
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnPlayerDied()
    {
        OpenPanel(_endGameMenu);
    }
}
