using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    public float speed;

    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z), speed * Time.deltaTime);
    }
}
