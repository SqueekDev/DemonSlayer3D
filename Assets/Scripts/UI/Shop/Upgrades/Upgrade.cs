using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class Upgrade : ButtonActivator
{
    [SerializeField] private int _upgradeValue;
    [SerializeField] private int _maxLevel;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _level;
    [SerializeField] private Player _player;

    private int _currentPoints = 0;
    private int _currentLevel = 0;
    private int _pointsToNextLvl = 5;

    public bool MaxLevelAchieved { get; private set; }
    public Player Player => _player;

    private void Start()
    {
        MaxLevelAchieved = false;
        _slider.value = 0;
        ShowLevel();
    }

    public void UpgradeButtonClick()
    {
        _currentPoints++;
        UpgadeAbility(_upgradeValue, Cost);

        if (_currentPoints >= _pointsToNextLvl)
            IncreaceAbilityLevel();

        _slider.value = (float)_currentPoints / _pointsToNextLvl;
    }

    protected abstract void UpgadeAbility(int value, int cost);

    private void IncreaceAbilityLevel()
    {
        _currentLevel++;

        if (_currentLevel < _maxLevel)
        {
            Cost++;
            _currentPoints = 0;
        }
        else
        {
            Button.gameObject.SetActive(false);
            MaxLevelAchieved = true;
        }

        ShowLevel();
    }

    private void ShowLevel()
    {
        if (MaxLevelAchieved == false)
        {
            _level.text = $"Lvl {_currentLevel}";
        }
        else
        {
            string maxLvlText = "Max.";
            _level.text = maxLvlText;
        }
    }
}
