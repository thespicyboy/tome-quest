using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JimboTriggerAnimations : MonoBehaviour
{
    public GameObject weaponHand;
    public GameObject[] weaponPrefabs;

    private Animator animator;
    private GameObject activeWeapon;
    private int activeWeaponIndex;

    void Start()
    {
        animator = GetComponent<Animator>();

        activeWeaponIndex = 0;
        activeWeapon = Instantiate(
            weaponPrefabs[activeWeaponIndex], weaponHand.transform
        );
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            animator.Play("Base Layer.AttackAction", 0, 0);
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            animator.Play("Base Layer.DamagedAction", 0, 0);
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            animator.Play("Base Layer.BlockAction", 0, 0);
        } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            animator.Play("Base Layer.WalkAction", 0, 0);

        } else if (Input.GetKeyDown(KeyCode.Q)) {
            SwitchWeapon(0);
        } else if (Input.GetKeyDown(KeyCode.W)) {
            SwitchWeapon(1);
        } else if (Input.GetKeyDown(KeyCode.E)) {
            SwitchWeapon(2);
        }
    }

    void SwitchWeapon(int weaponIndex)
    {
        if (weaponIndex != activeWeaponIndex)
        {
            Destroy(activeWeapon);
            activeWeapon = Instantiate(
                weaponPrefabs[weaponIndex], weaponHand.transform
            );
            activeWeaponIndex = weaponIndex;
        }
    }
}
