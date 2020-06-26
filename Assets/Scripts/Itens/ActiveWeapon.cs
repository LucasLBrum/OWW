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

    public GameObject a;
    Animator anim;
    AnimatorOverrideController overrides;


    private void Start()
    {

        anim = GetComponent<Animator>();
        overrides = anim.runtimeAnimatorController as AnimatorOverrideController;
        /*
        ItemResource exisitingWeapon = GetComponentInChildren<ItemResource>();
        if (exisitingWeapon)
        {
            Equip(exisitingWeapon);
        }
        */
    }

    private void Update()
    {
        if (weapon)
        {

        }
        else
        {
            handIK.weight = 0f;
            anim.SetLayerWeight(1, 0.0f); 
        }
    }

    public void Equip(ItemResource resorceWeapon)
    {
        var weaponPrefab = Instantiate(resorceWeapon.itemPrefab, weaponParent.transform);
        a = GetComponentInChildren<WeaponInScene>().gameObject;
        weapon = weaponPrefab.GetComponent<WeaponInScene>();
        weapon.transform.parent = weaponParent.parent; 
        weapon.gameObject.transform.localPosition = Vector3.zero;
        weapon.gameObject.transform.localRotation = Quaternion.identity;

        handIK.weight = 1.0f;
        anim.SetLayerWeight(1, 1.0f);
        Invoke(nameof(SetAnimationDelayed), 0.001f);

    }

    void SetAnimationDelayed()
    {
        overrides["empty"] = weapon.weaponAnimation;
    }

   
    [ContextMenu("Salvar Posicao da arma/maos")]
    void SaveWeaponPose()
    {
        GameObjectRecorder recorder = new GameObjectRecorder(gameObject);
        recorder.BindComponentsOfType<Transform>(weaponParent.gameObject, false);
        recorder.BindComponentsOfType<Transform>(weaponLeftGrip.gameObject, false);
        recorder.BindComponentsOfType<Transform>(weaponRightGrip.gameObject, false);
        recorder.TakeSnapshot(0.0f);
        recorder.SaveToClip(weapon.weaponAnimation);
        UnityEditor.AssetDatabase.SaveAssets(); 
    }
   
}
