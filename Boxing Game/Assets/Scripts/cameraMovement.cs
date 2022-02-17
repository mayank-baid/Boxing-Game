using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform player;
    public Transform enemy;
    Camera cam;

    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        targetPos.x = (player.position.x + enemy.position.x) / 2;

        transform.position = Vector3.Lerp(transform.position, targetPos, 0.9f);
    }
}
