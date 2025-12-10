using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour, ICollideable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    float maxBounceAngle;
    SpriteRenderer spriteRenderer;
    [SerializeField]
    InputActionReference move;
    Rigidbody2D paddleRB;
    float moveDirection;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    public void collide(BallLogic ball, Collision2D collision2D)
    {
        ContactPoint2D collisionPoint = collision2D.contacts[0];
        float paddleHeight = spriteRenderer.bounds.size.y;
        // get angle of exit ball vector
        float relativeIntersect = transform.position.y- collisionPoint.point.y;
        float normalizedRelativeIntersect = relativeIntersect/(paddleHeight/2);
        float bounceAngle = normalizedRelativeIntersect * (maxBounceAngle * Mathf.Deg2Rad);
        float ballSpeed = collision2D.otherCollider.GetComponent<Rigidbody2D>().linearVelocity.magnitude;
        float normalAngleOffset = Vector2.Angle(collisionPoint.normal, Vector2.right);
        // Debug.Log("Normal angle offset: " + normalAngleOffset);
        bounceAngle += normalAngleOffset * Mathf.Deg2Rad;
        float speedModifier = Mathf.Log10(1 + ballSpeed) + 1;
        Debug.Log("Ballspeed: " + ballSpeed);
        Vector2 newBallVelocity = new Vector2(math.cos(bounceAngle) * ballSpeed, math.sin(bounceAngle) * ballSpeed) * speedModifier;
        Debug.DrawRay((Vector2) transform.position + new Vector2(0, paddleHeight/2), newBallVelocity * 10, Color.red);
        ball.ballRB.linearVelocity = newBallVelocity;

        // Debug.Break();
    }

    
}
