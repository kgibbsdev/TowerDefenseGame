using UnityEngine;
using UnityEngine.UI;

public class PlayerLivesManager : MonoBehaviour
{
    [SerializeField]
    public Text LivesCounterText;
    public Text GameStateText;
    public int Lives;

    // Start is called before the first frame update
    void Start()
    {
        Lives = 5;
    }

    // Update is called once per frame
    void Update()
    {
        LivesCounterText.text = $"Lives: {Lives}";

        if (Lives < 1)
        {
            GameStateText.text = "YOU LOSE";
        }
    }
}
