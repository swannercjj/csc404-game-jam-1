using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public HealthBar healthBar1;
    public HealthBar healthBar2;
    
    [Header("Win Announcement")]
    public GameObject winTextObject;
    public TextMeshProUGUI winText;
    
    [Header("Audio")]
    public AudioClip deathSound;
    private AudioSource audioSource;

    private bool gameEnded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        healthBar1.setSliderMax(healthBar1.maxHealth);
        healthBar2.setSliderMax(healthBar2.maxHealth);
        
        // Subscribe to death events
        healthBar1.OnPlayerDeath += () => AnnounceWinner("Player 2");
        healthBar2.OnPlayerDeath += () => AnnounceWinner("Player 1");
        
        // Ensure win text is initially disabled
        if (winTextObject != null)
            winTextObject.SetActive(false);
        
        // Get or add AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameEnd();
    }

    private void CheckGameEnd()
    {
        if (gameEnded) return;

        if (healthBar1.currentHealth <= 0)
        {
            AnnounceWinner("Player 2");
        }
        else if (healthBar2.currentHealth <= 0)
        {
            AnnounceWinner("Player 1");
        }
    }

    private void AnnounceWinner(string winnerName)
    {
        if (gameEnded) return;
        
        gameEnded = true;
        
        // Play death sound
        if (deathSound != null && audioSource != null)
            audioSource.PlayOneShot(deathSound);
        
        if (winTextObject != null)
            winTextObject.SetActive(true);
            
        if (winText != null)
            winText.text = $"{winnerName} Wins!";
    }
}
