using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class ActiveWeapon : MonoBehaviour
{
    public UnityEngine.Animations.Rigging.Rig handIK;
    public WeaponRaycast weapon;

    public Transform weaponParent;

    public Transform weaponLeftGrip; 
    public Transform weaponRightGrip;

    Animator anim;
    AnimatorOverrideController overrides;


    private void Start()
    {
        anim = GetComponent<Animator>();
        overrides = anim.runtimeAnimatorController as AnimatorOverrideController; 
        WeaponRaycast exisitingWeapon = GetComponentInChildren<WeaponRaycast>();
        if (exisitingWeapon)
        {
            Equip(exisitingWeapon);
        }
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

    public void Equip(WeaponRaycast newWeapon)
    {
        weapon = newWeapon;

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
