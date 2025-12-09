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
    [SerializeField]
    int winScore;

    int redScore, blueScore = 0;
    [SerializeField]
    TextMeshPro redScoreDisplay, blueScoreDisplay;
    [SerializeField]
    Transform redPaddle, bluePaddle;
    [SerializeField]
    BallLogic ball;
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
    void restartRound()
    {
        Debug.Log("Restarting!");
        redPaddle.position = new Vector2(redPaddle.position.x, 0);
        bluePaddle.position = new Vector2(bluePaddle.position.x, 0);
        ball.trail.Clear();
        ball.ballRB.linearVelocity = Vector2.zero;
        ball.ballRB.position = Vector2.zero;
        ball.launchBall();
        
    }
    void updateDisplays()
    {
        
        redScoreDisplay.text = redScore.ToString();
        blueScoreDisplay.text = blueScore.ToString();
    }

    void doRedWin()
    {
        redScore++;
        if(redScore == winScore)
        {
            Debug.Log("Red Win!");
            Debug.Break();
        }
        updateDisplays();
        restartRound();
    }
    void doBlueWin()
    {
        blueScore++;
        if(blueScore == winScore)
        {
            Debug.Log("Blue win");
            Debug.Break();
        }
        updateDisplays();
        restartRound();
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
