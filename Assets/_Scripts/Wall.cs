using UnityEngine;

public class Wall : MonoBehaviour, ICollideable
{
    [SerializeField]
    ImpactParticle impactParticle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        impactParticle = GetComponentInChildren<ImpactParticle>();
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
        ContactPoint2D contactPoint2D = collision2D.contacts[0];
        Debug.DrawRay(contactPoint2D.point, contactPoint2D.normal, Color.green);
        Debug.DrawRay(ball.transform.position, ball.ballRB.linearVelocity, Color.yellow);
        Debug.DrawRay(ball.transform.position, bouncedVelocity, Color.red);
        // Debug.Log("Ball SPEED: " + ball.ballRB.linearVelocity); 
        impactParticle.PlayImpact(contactPoint2D.point, contactPoint2D.normal, 1);
        // ball.ballRB.linearVelocity = bouncedVelocity;
        // Debug.Break();
    }
}
