using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Image healthBar;

    public virtual void UpdateHealthBar(float health, float totalHealth)
    {
        healthBar.fillAmount = health / totalHealth;
    }
}
