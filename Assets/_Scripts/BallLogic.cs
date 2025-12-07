using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BallLogic : MonoBehaviour
{
    public Rigidbody2D ballRB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
     float xVelocityScale, yVelocityScale = 5.0f;
     Vector2 launchDir;

    void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();

        // Setup inital direction
        bool isStartingLeft = UnityEngine.Random.Range(0.0f, 1.0f) >= 0.5f;
        float x = 1.0f;
        if(isStartingLeft)
        {
            x = -1.0f;
        }

        float y = Random.Range(-1.0f, 1.0f);

        x *= xVelocityScale;
        y *= yVelocityScale;
        Vector2 initialVelocity = new Vector2(x, y);
        launchDir = initialVelocity;
        ballRB.AddForce(initialVelocity, ForceMode2D.Impulse);
        
    }


    void OnCollisionEnter2D(Collision2D collision2D)
    {
        ICollideable collideableObj = collision2D.collider.GetComponent<ICollideable>();
        Debug.LogWarning(collision2D.collider.name);
        if(collideableObj != null)
        {
            Debug.Log("Found collidable!");
            collideableObj.collide(this, collision2D);
        }
        else
        {
            Debug.LogError("Couldn't find collidable Interface in collision!");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        // Gizmos.DrawRay(new Ray( transform.position, (Vector3) launchDir));
    }
}

public interface ICollideable
{
    void collide(BallLogic ball, Collision2D collision2D);
    
}
