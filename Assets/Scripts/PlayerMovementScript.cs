using System;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovementScript : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public DamageBox damageBox;
    public HealthBar healthBar;
    public AudioClip attackSound;
    private AudioSource audioSource;
    public KeyCode attackKey = KeyCode.Space;
    public KeyCode moveUpKey = KeyCode.W;
    public KeyCode moveDownKey = KeyCode.S;
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode blockKey = KeyCode.E;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetKey(blockKey))
        {
            healthBar.isBlocking = true;
            return;
        }
        else
        {
            healthBar.isBlocking = false;
        }


        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(moveLeftKey)) horizontal -= 1f;
        if (Input.GetKey(moveRightKey)) horizontal += 1f;
        if (Input.GetKey(moveDownKey)) vertical -= 1f;
        if (Input.GetKey(moveUpKey)) vertical += 1f;

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }


        // Attack input
        if (Input.GetKeyDown(attackKey) && damageBox != null)
        {
            damageBox.DoDamage(gameObject, damageBox.damageDuration, transform);
            
            if (attackSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(attackSound);
            }
        }
    }
}

