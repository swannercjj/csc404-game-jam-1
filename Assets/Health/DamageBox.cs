using UnityEngine;
using System.Collections.Generic;

public class DamageBox : MonoBehaviour
{
    public GameObject owner;
    public float damageDuration = 0.2f;
    private float timer = 0f;
    private HashSet<GameObject> damaged = new HashSet<GameObject>();
    private bool active = false;
    private Renderer rend;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
            rend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            timer += Time.deltaTime;
            if (timer >= damageDuration)
            {
                active = false;
                damaged.Clear();
                timer = 0f;
                if (rend != null)
                    rend.enabled = false;
            }
        }
    }

    public void DoDamage(GameObject owner, float duration)
    {
        this.owner = owner;
        this.damageDuration = duration;
        this.timer = 0f;
        this.active = true;
        damaged.Clear();
        if (rend != null)
            rend.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        TryDamage(other.gameObject);
    }

    void OnTriggerStay(Collider other)
    {
        TryDamage(other.gameObject);
    }

    private void TryDamage(GameObject obj)
    {
        if (!active) return;
        if (obj == owner) return;
        if (damaged.Contains(obj)) return;

        // Simulate damage by printing object name
        Debug.Log("Damaged: " + obj.name);

        damaged.Add(obj);
    }
}
