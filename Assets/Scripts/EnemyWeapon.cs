using UnityEngine;

public class EnemyWeapon : Weapon
{
    private void Start()
    {
        hitObjectTag = "Player";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(hitObjectTag))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
