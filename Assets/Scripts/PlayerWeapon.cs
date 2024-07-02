using UnityEngine;

public class PlayerWeapon : Weapon
{
    private void Start()
    {
        hitObjectTag = "Enemy";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(hitObjectTag))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
}
