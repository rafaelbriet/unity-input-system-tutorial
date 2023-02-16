using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 8.0f;
    [SerializeField]
    private GameObject laserPrefab;

    private Vector2 moveDirection;
    private Vector2 firingDirection = Vector2.up;

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

        if (context.phase == InputActionPhase.Performed)
        {
            firingDirection = moveDirection;
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Laser laser = Instantiate(laserPrefab, transform.position, Quaternion.identity).GetComponent<Laser>();
            laser.Fire(firingDirection); 
        }
    }
}
