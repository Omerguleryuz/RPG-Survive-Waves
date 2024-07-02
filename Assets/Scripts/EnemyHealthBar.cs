using UnityEngine;

public class EnemyHealthBar : HealthBar
{
    public Canvas healthBarCanvas;

    private void Start()
    {
        healthBarCanvas.worldCamera = Camera.main;
    }

    private void Update()
    {
        healthBarCanvas.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }

    public override void UpdateHealthBar(float health, float totalHealth)
    {
        base.UpdateHealthBar(health, totalHealth);
        healthBarCanvas.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Scale");
    }
}