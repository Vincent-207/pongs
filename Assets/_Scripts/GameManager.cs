using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    static GameManager GetInstance()
    {
        if(_instance == null)
        {
            _instance = new GameObject("Game Manager").AddComponent<GameManager>();
            _instance.Initialise();
        }

        return _instance;
    }

    int redScore, blueScore = 0;
    [SerializeField]
    TextMeshPro redScoreDisplay, blueScoreDisplay;
    void Start()
    {
        _instance = this;
        Initialise();
        GetInstance();
    }
    void Initialise()
    {
        //do startup stuff
        // Debug.Log("Initializing!");
        redScoreDisplay = transform.GetChild(0).GetComponent<TextMeshPro>();
        blueScoreDisplay = transform.GetChild(1).GetComponent<TextMeshPro>();
        updateDisplays();
    }

    void updateDisplays()
    {
        
        redScoreDisplay.text = redScore.ToString();
        blueScoreDisplay.text = blueScore.ToString();
    }

    void doRedWin()
    {
        redScore++;
        updateDisplays();
    }
    void doBlueWin()
    {
        blueScore++;
        updateDisplays();
    }
    public static void redWin()
    {
        
        GetInstance().doRedWin();

    }

    public static void blueWin()
    {
        GetInstance().doBlueWin();
    }
}
