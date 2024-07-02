using UnityEngine;

public class ToggleWeaponCollider : MonoBehaviour
{
    [SerializeField] private Collider weaponCollider;

    private void Start()
    {
        weaponCollider.enabled = false;
    }

    //Animation Event
    private void TurnOnWeaponCollider()
    {
        weaponCollider.enabled = true;
    }

    //Animation Event
    private void TurnOffWeaponCollider()
    {
        weaponCollider.enabled = false;
    }
}
