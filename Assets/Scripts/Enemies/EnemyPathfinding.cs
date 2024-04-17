using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 moveDir;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
        // fix z rotation to 0
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void MoveTo(Vector2 targetPosition) {
        moveDir = targetPosition;
    }
}
