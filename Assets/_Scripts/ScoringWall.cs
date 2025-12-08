using System;
using UnityEngine;

public class ScoringWall : MonoBehaviour, ICollideable
{
    [SerializeField]   
    Team team;
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
        if(team == Team.Red)
        {
            GameManager.redWin();
            
        }
        else if(team == Team.Blue)
        {
            GameManager.blueWin();
        }
        else
        {
            Debug.LogError("Team not set.");
            Debug.Break();
        }
    }
}
[Serializable]
public enum Team
{
    Red,
    Blue,
}