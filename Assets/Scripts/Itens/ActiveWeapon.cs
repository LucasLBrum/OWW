using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEditor.Animations;

public class ActiveWeapon : MonoBehaviour
{
    public Rig handIK;
    public WeaponInScene weapon;

    public Transform weaponParent;

    public Transform weaponLeftGrip; 
    public Transform weaponRightGrip;

    public GameObject weaponObject;
    public Animator rigController;

    public void Equip(ItemResource resorceWeapon)
    {
        var weaponPrefab = Instantiate(resorceWeapon.itemPrefab, weaponParent.transform);
        weaponObject = GetComponentInChildren<WeaponInScene>().gameObject;
        weapon = weaponPrefab.GetComponent<WeaponInScene>();
        weapon.transform.parent = weaponParent.parent; 
        weapon.gameObject.transform.localPosition = Vector3.zero;
        weapon.gameObject.transform.localRotation = Quaternion.identity;
        handIK.weight = 1;
        rigController.Play("equip_" + weapon.weaponName);

        weapon.GetComponent<BoxCollider>().enabled = false;
    }
}
