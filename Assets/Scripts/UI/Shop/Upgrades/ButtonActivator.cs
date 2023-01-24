using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonActivator : MonoBehaviour
{
    [SerializeField] private int _cost;
    [SerializeField] private Button _button;

    public Button Button => _button;
    
    public int Cost { get; protected set; }

    private void Awake()
    {
        Cost = _cost;
    }

    public void ActivateButton()
    {
        Button.interactable = true;
    }

    public void DeactivateButton()
    {
        Button.interactable = false;
    }
}
