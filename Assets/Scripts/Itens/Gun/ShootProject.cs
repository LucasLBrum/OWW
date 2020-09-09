using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProject : MonoBehaviour
{
    public GameObject firePoint;//ponto de disparo
    public Animator rigController;//animator dos rig
    public ShootRaycast shootRaycast;//componente que controla os raycasts

    public AudioClip shootAF;
    public AudioClip reloadAF;


    public AudioSource source;

    public GameObject muzzlePrefab;//prefab do muzzle flash

    WeaponInScene weaponScene;

    PlayerMovement pMovement;

    Inventory inventory;

    float timeTofire = 0;//tempo entre um disparo a outro

    private void Start()
    {
        source = GetComponent<AudioSource>();
        weaponScene = GetComponent<WeaponInScene>();
        shootRaycast = Camera.main.GetComponent<ShootRaycast>();//componente que controla os raycasts
        pMovement = Player.singleton.carterScene.GetComponent<PlayerMovement>();
        inventory = Player.singleton.carterScene.inventoryInScene;
    }

    public void Shoot()
    {
        if (Input.GetMouseButton(0) && Time.time >= timeTofire)//se apertar o botão esquerdo do mouse e o tempo for maior ou igual à tempo de disparo.
        {
            if (pMovement.slotWeaponUse != null)//se haver algum slot de arma em uso.
            {
                if (GetComponent<ItemScene>().thisItem == pMovement.slotWeaponUse.item)//se esse item for o que estiver em uso.
                {
                    if (pMovement.activeWeapon.rigController.GetBool("Take") != true)
                    {
                        if (weaponScene.bullets > 0)
                        {
                            weaponScene.bullets -= 1;
                            inventory.UpdateMunitionText();
                            rigController.Play("weapon_recoil_" + weaponScene.weaponName, 1, 0.0f);//fazer a animação de disparo da arma.
                            source.PlayOneShot(shootAF);
                            SpawnMuzzle();//intanciar o efeito de explosão
                            timeTofire = Time.time + 1 / weaponScene.fireRate;//verificar a taxa de disparo da arma atual e colocar no tempo de disparo.
                            if (shootRaycast.ShootR() != null)//se haver algum inimigo no caminho do disparo.
                            {
                                var enemy = shootRaycast.ShootR();//variavel vaia brigar esse inimigo.
                                if (enemy != null)
                                {
                                    enemy.enemy.TakeLife(enemy.enemy, weaponScene.damage, 1);//vai diminuir a vida do inimigo dependendo da arma que o jogador estiver utilizando.);
                                }
                            }
                        }
                    }

                }
            }
        }
    }

    public void Reaload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (pMovement.slotWeaponUse != null)//se haver algum slot de arma em uso.
            {
                if (GetComponent<ItemScene>().thisItem == pMovement.slotWeaponUse.item)//se esse item for o que estiver em uso.
                {
                    if (rigController.GetBool("Take") == false)
                    {
                        if (weaponScene.bullets != weaponScene.bulletsMax)
                        {
                            if (weaponScene.typeWeapon == MunitionType.Little)
                            {
                                if (inventory.munitionL.boxMunition > 0)
                                {
                                    Player.singleton.carterScene.inventoryInScene.munitionL.RemoveMuniton(1);
                                    weaponScene.bullets = weaponScene.bulletsMax;
                                    rigController.SetTrigger("Reload");
                                    source.PlayOneShot(reloadAF);
                                }
                            }
                            else if (weaponScene.typeWeapon == MunitionType.Big)
                            {
                                if (Player.singleton.carterScene.inventoryInScene.munitionB.boxMunition > 0)
                                {
                                    inventory.munitionB.RemoveMuniton(1);
                                    weaponScene.bullets = weaponScene.bulletsMax;
                                    rigController.SetTrigger("Reload");
                                    source.PlayOneShot(reloadAF);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    void SpawnMuzzle()
    {
        if (muzzlePrefab != null)
        {
            var muzzleVFX = Instantiate(muzzlePrefab, firePoint.transform.position, Quaternion.identity);
            muzzleVFX.transform.forward = firePoint.transform.forward;
            muzzleVFX.transform.parent = null;
            var psMuzzle = muzzleVFX.GetComponent<ParticleSystem>();
            if (psMuzzle != null)
            {
                Destroy(muzzleVFX, psMuzzle.main.duration);
            }
            else
            {
                var psChild = muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(muzzleVFX, psChild.main.duration);
            }
        }
    }
}
