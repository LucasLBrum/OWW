using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRange : MonoBehaviour
{
    public List<EnemyMovement> enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CarterScene>())
        {
            for (int i = 0; i < enemy.Count; i++)
            {
                if(enemy[i].inBattle == false)
                StartCoroutine(enemy[i].Chase());
            }
        }
    }
}
