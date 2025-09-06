using UnityEngine;

public class CharacterControllerButLikeWeDontActuallyUseIt : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    public DamageBox damageBox;
    public float damageDuration = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed;

        // Apply movement in FixedUpdate for physics
        MoveCharacter(move);

        // Damage on space press
        if (Input.GetKeyDown(KeyCode.Space) && damageBox != null)
        {
            damageBox.DoDamage(gameObject, damageDuration);
        }
    }

    void MoveCharacter(Vector3 move)
    {
        if (rb != null)
        {
            Vector3 velocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
            rb.linearVelocity = velocity;
        }
    }
}
