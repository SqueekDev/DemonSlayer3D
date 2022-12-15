using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void ApplyDamage(int damage)
    {
        Debug.Log($"Take {damage} damage");
    }
}
