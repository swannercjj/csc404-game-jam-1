using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public int numOptions;
    public List<GameObject> options;

    int currOption;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currOption = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int oldOption = currOption;
        // left
        if (Input.GetKeyDown(KeyCode.A))
        {
            currOption += 1;
            currOption = currOption % numOptions;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            currOption -= 1;
            if (currOption == -1)
            {
                currOption = numOptions - 1;
            }
        }

        // render the player choice
        options[oldOption].SetActive(false);
        options[currOption].SetActive(true);

        if (Input.GetKeyDown(KeyCode.E))
        {
            CharacterImage controller = options[currOption].GetComponent<CharacterImage>();

            StartCoroutine(controller.JumpAnim());

            CharacterSelectManager.Instance.Choose(1, currOption);
        }
    }
}
