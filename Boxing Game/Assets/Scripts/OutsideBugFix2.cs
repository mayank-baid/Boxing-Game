using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideBugFix2 : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform PlayerActual;
    public Transform PlayerWanted;
    public Transform EnemyActual;
    public Transform EnemyWanted;



    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        PlayerActual.position = PlayerWanted.position;
        PlayerActual.rotation = PlayerWanted.rotation;

        EnemyActual.position = EnemyWanted.position;
        EnemyActual.rotation = EnemyWanted.rotation;


    }
}
