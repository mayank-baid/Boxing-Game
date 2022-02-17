using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideGameFix : MonoBehaviour
{
    public Transform CenterPos;
    public GameObject Player;
    public GameObject Enemy;

    private void OnTriggerStay(Collider other)
    {

        /* PlayerActual.position = PlayerWanted.position;
         PlayerActual.rotation = PlayerWanted.rotation;

         EnemyActual.position = EnemyWanted.position;
         EnemyActual.rotation = EnemyWanted.rotation;*/

        Enemy.transform.position = CenterPos.position;
        Player.transform.position = CenterPos.position;


    }
}
