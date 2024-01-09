using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;

    //Camera will follow the player
    void Update()
    {
        transform.position = new Vector3(playerPosition.position.x, playerPosition.position.y, transform.position.z);
    }
}
