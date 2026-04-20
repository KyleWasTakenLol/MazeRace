using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private bool canMove = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // In solo mode allow movement immediately
        if (GameManager.Instance.CurrentMode == GameMode.Solo)
        {
            canMove = true;
        }
    }

    public override void OnNetworkSpawn()
    {
        // In multiplayer only allow movement for owner
        if (IsOwner)
        {
            canMove = true;
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    void Update()
    {
        if (!canMove) return;

        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W)) moveY = 1f;
        if (Input.GetKey(KeyCode.S)) moveY = -1f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;

        rb.linearVelocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
    }
}