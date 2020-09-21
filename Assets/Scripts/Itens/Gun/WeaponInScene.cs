using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInScene : MonoBehaviour
{
    public MunitionType typeWeapon;
    public string weaponName;
    public float damage;
    public int bullets;
    public int bulletsMax;
    public float fireRate;
    public float shootDistance;

    public void GetDetailsWeapon(WeaponInScene thisWeapon, WeaponInScene weapon)
    {
        thisWeapon.damage = weapon.damage;
        thisWeapon.fireRate = weapon.fireRate;
        thisWeapon.bullets = weapon.bullets;
        thisWeapon.typeWeapon = weapon.typeWeapon;
        thisWeapon.bulletsMax = weapon.bulletsMax;
        thisWeapon.weaponName = weapon.weaponName;
    }

    public void AddBullets(int munition)
    {
        this.bullets += munition;
        if (this.bullets > bulletsMax)
        {
            bullets = bulletsMax;
        }
    }
}
public enum MunitionType
{
    Little, Big
}
