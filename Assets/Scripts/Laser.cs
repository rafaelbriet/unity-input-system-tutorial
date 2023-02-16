using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 20.0f;

    private Vector2 moveDirection;

    private void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * moveDirection, Space.World);
    }

    public void Fire(Vector2 direction)
    {
        moveDirection = direction;

        if (moveDirection.magnitude > Mathf.Epsilon)
        {
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
            transform.rotation = lookRotation;
        }
    }
}
