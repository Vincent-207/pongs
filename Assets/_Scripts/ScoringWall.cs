using UnityEngine;

public class ScoringWall : MonoBehaviour, ICollideable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void collide(BallLogic ball, Collision2D collision2D)
    {
        Debug.Log("Score!");
        GameManager.redWin();
    }
}
