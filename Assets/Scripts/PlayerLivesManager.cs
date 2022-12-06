using UnityEngine;
using UnityEngine.UI;

public class PlayerLivesManager : MonoBehaviour
{
    [SerializeField]
    public Text LivesCounterText;
    public Text GameStateText;
    public int Lives = 100;
    private bool IsEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        Lives = 5;
        if(!LivesCounterText && !GameStateText)
        {
            IsEnabled = false;
            throw new System.NullReferenceException("UI Elements Not Defined For Player Manager.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsEnabled) return;

        LivesCounterText.text = $"Lives: {Lives}";

        if (Lives < 1)
        {
            GameStateText.text = "YOU LOSE";
        }
    }
}
