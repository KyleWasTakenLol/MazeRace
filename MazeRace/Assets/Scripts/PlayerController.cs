using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    public override void OnNetworkSpawn()
    {
        rb = GetComponent<Rigidbody2D>();

        if (!IsOwner)
        {
            // Disable physics on non-owned players
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    void Update()
    {
        if (!IsOwner) return;

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        rb.linearVelocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
    }
}