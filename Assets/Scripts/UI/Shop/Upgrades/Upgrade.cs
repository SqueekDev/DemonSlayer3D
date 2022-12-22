using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class Upgrade : MonoBehaviour
{
    [SerializeField] private int _startCost;
    [SerializeField] private int _upgradeValue;
    [SerializeField] private int _maxLevel;
    [SerializeField] private Button _button;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _level;
    [SerializeField] private Player _player;

    private int _currentPoints = 0;
    private int _currentLevel = 0;
    private int _pointsToNextLvl = 5;

    public int Cost { get; private set; }
    public bool MaxLevelAchieved { get; private set; }
    public Player Player => _player;

    private void Awake()
    {
        MaxLevelAchieved = false;
        Cost = _startCost;
        _slider.value = 0;
        ShowLevel();
    }

    public void ActivateButton()
    {
        _button.interactable = true;
    }

    public void DeactivateButton()
    {
        _button.interactable = false;
    }

    public void UpgradeButtonClick()
    {
        _currentPoints++;
        UpgadeAbility(_upgradeValue, Cost);

        if (_currentPoints >= _pointsToNextLvl)
        {
            IncreaceAbilityLevel();
        }

        _slider.value = (float)_currentPoints / _pointsToNextLvl;
    }

    protected abstract void UpgadeAbility(int value, int cost);

    private void IncreaceAbilityLevel()
    {
        _currentLevel++;

        if (_currentLevel >= _maxLevel)
        {
            _button.gameObject.SetActive(false);
            MaxLevelAchieved = true;
        }
        else
        {
            Cost++;
            _currentPoints = 0;
        }

        ShowLevel();
    }

    private void ShowLevel()
    {
        if (MaxLevelAchieved)
        {
            string maxLvlText = "Max.";
            _level.text = maxLvlText;
        }
        else
        {
            _level.text = $"Lvl {_currentLevel}";
        }
    }
}
