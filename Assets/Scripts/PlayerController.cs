using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 8.0f;

    private Vector2 moveDirection;

    private void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * moveDirection, Space.World);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();

        if (moveDirection.magnitude > Mathf.Epsilon)
        {
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
            transform.rotation = lookRotation;
        }
    }
}
