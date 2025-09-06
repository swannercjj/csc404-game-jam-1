using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectManager : MonoBehaviour
{
    public static CharacterSelectManager Instance;
    public int player1;
    public int player2;

    public GameObject playerPrefab;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object between scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }
    void Start()
    {
        player1 = -1;
        player2 = -1;
    }
    public void Choose(int player, int selection)
    {
        if (player == 1)
        {
            player1 = selection;
        }
        else
        {
            player2 = selection;
        }
    }

    void Update()
    {
        if (player1 != -1 && player2 != -1)
        {
            GameStart();
        }
    }

    void GameStart()
    {
        // load next scene
        SceneManager.LoadScene("SampleScene");

        GameObject player1Prefab = Instantiate(playerPrefab);
        GameObject player2Prefab = Instantiate(playerPrefab);
    }
}
