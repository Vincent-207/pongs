using UnityEngine;

public class Wall : MonoBehaviour, ICollideable
{
    public void collide(BallLogic ball, Collision2D collision2D)
    {
        Vector2 ballVelocity = ball.ballRB.linearVelocity;
        Vector2 collisionNormal = collision2D.contacts[0].normal;
        Vector2 bouncedVelocity = Vector2.Reflect(ballVelocity, collisionNormal);
        ContactPoint2D contactPoint2D = collision2D.contacts[0];
        
        Debug.DrawRay(contactPoint2D.point, contactPoint2D.normal, Color.green);
        Debug.DrawRay(ball.transform.position, ball.ballRB.linearVelocity, Color.yellow);
        Debug.DrawRay(ball.transform.position, bouncedVelocity, Color.red);
    }
}
