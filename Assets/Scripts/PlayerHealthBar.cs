using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : HealthBar
{
    private void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("Player Health Bar").GetComponent<Image>();
    }

    public override void UpdateHealthBar(float health, float totalHealth)
    {
        healthBar.fillAmount = health / totalHealth;
    }
}
