using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform player;

    private void Update()
    {
        // liz's notes?
        // transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed * Time.deltaTime);

        // raises camera a bit
        float cameraYOffset = 2.0f;

        // camera follows player
        transform.position = new Vector3(player.position.x, transform.position.y + cameraYOffset, transform.position.z);
       

    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
