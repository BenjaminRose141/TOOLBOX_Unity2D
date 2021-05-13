using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 25f;
    [SerializeField] float moveSpeed = 5f;

    private Vector2 direction;

    private void Update()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if((cursorPos - (Vector2)transform.position).magnitude > 0.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, cursorPos, moveSpeed * Time.deltaTime);
        }
    }
}
