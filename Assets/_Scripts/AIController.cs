using Unity.Mathematics;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField]
    BallLogic ball;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float lowerBound, upperBound;
    
    void FixedUpdate()
    {
        float yDifference = (ball.transform.position - transform.position).y;
        float moveInput = 0;
        if(yDifference > 0.1)
        {
            moveInput = 1;
        }
        else if (yDifference < -0.1)
        {
            moveInput = -1;
        }
        float moveAmount =  moveInput * moveSpeed * Time.deltaTime;
        // Debug.LogWarning("Move amount AI: " + moveAmount);
        transform.position = transform.position + (Vector3.up * moveInput * moveSpeed);
        // applyBounds();
    }

    void applyBounds()
    {
        if(transform.position.y > upperBound)
        {
            transform.position = new Vector2(transform.position.x, upperBound);
        }
        
        if(transform.position.y < lowerBound)
        {
            transform.position = new Vector2(transform.position.x, lowerBound);
        }
    }
}
