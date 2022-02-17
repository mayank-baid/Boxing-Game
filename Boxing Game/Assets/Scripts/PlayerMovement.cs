using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;

    public float f_RotSpeed;
    public Transform Enemy;

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;

       transform.rotation = Quaternion.Slerp(transform.rotation
                                                  , Quaternion.LookRotation(new Vector3(0f, Enemy.position.y, Enemy.position.z) - new Vector3(0f, transform.position.y, transform.position.z))
                                                  , f_RotSpeed * Time.deltaTime);
        transform.Translate(playerMovement, Space.Self);
    }
}