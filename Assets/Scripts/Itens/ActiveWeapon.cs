using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;


public class ActiveWeapon : MonoBehaviour
{
    public Rig handIK; //layer que contra o ik das mãos do personagem
    public WeaponInScene weapon;//atual arma equipada do jogador

    public Transform weaponParent;//pai da arma

    public Transform weaponLeftGrip; //refêrencia das mãos do jogador para o ik
    public Transform weaponRightGrip;

    public GameObject weaponObject;//objeto da atual arma
    public Animator rigController; //animator do rig


    public void Equip(ItemResource resorceWeapon, WeaponInScene weaponScene)
    {
        var weaponPrefab = Instantiate(resorceWeapon.itemPrefab, weaponParent.transform);
        weaponObject = weaponPrefab;
        weapon = weaponPrefab.GetComponent<WeaponInScene>();
        weapon.GetDetailsWeapon(weapon, weaponScene);
        weapon.transform.parent = weaponParent; 
        weapon.gameObject.transform.localPosition = Vector3.zero;
        weapon.gameObject.transform.localRotation = Quaternion.identity;
        handIK.weight = 1;
        rigController.Play("equip_" + weapon.weaponName);
        weapon.GetComponent<ShootProject>().rigController = rigController;
        weapon.GetComponent<BoxCollider>().enabled = false;
        weapon.gameObject.GetComponent<Rigidbody>().useGravity = false;
        weapon.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
