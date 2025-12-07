using UnityEngine;

public class Wall : MonoBehaviour, ICollideable
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
        // Reflect the ball's velocity
        Vector2 ballVelocity = ball.ballRB.linearVelocity;
        // get normal of contact plane. 
        /*
        int contactNum = collision2D.contactCount;
        ContactPoint2D[] contactPoints = collision2D.contacts;
        foreach (ContactPoint2D contactPoint in contactPoints)
        {
            Debug.Log(contactPoint.normal);
        }
        Debug.Break();
        */
        // TODO get correct contact point, not just first one. 
        Vector2 collisionNormal = collision2D.contacts[0].normal;
        Vector2 bouncedVelocity = Vector2.Reflect(ballVelocity, collisionNormal);

        Debug.DrawRay(collision2D.contacts[0].point, collision2D.contacts[0].normal, Color.green);
        Debug.DrawRay(ball.transform.position, ball.ballRB.linearVelocity, Color.yellow);
        Debug.DrawRay(ball.transform.position, bouncedVelocity, Color.red);
        Debug.Log("Ball SPEED: "  + ball.ballRB.linearVelocity); 
        // ball.ballRB.linearVelocity = bouncedVelocity;
        // Debug.Break();
    }
}
