using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public ActiveWeapon activeWeapon;
    public Text ChangeWeaponText;

    private bool Carrying = false;

    private void Awake()
    {
        activeWeapon = GetComponentInParent<ActiveWeapon>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Weapon")
        {
            if (Carrying)
            {
                ChangeWeaponText.gameObject.SetActive(true);
                ChangeWeaponText.text = "Aperte E para trocar de arma.";

                if (Input.GetKey(KeyCode.E))
                {
                    activeWeapon.weapon.transform.parent = null;
                    Carrying = true;
                    ChangeWeaponText.gameObject.SetActive(false);
                    activeWeapon.Equip(other.gameObject.GetComponent<WeaponRaycast>());
                }
            }
            else
            {
                ChangeWeaponText.gameObject.SetActive(true);
                ChangeWeaponText.text = "Aperte E para equipar a arma.";
                if (Input.GetKey(KeyCode.E))
                {
                    Carrying = true;
                    ChangeWeaponText.gameObject.SetActive(false);
                    activeWeapon.Equip(other.gameObject.GetComponent<WeaponRaycast>());
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ChangeWeaponText.gameObject.SetActive(false);
    }


}
