
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class BallLogic : MonoBehaviour
{
    [SerializeField] 
    float trailTimeOffset;
    public Rigidbody2D ballRB;
    public TrailRenderer trail;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
     float initalSpeed = 5.0f;
     Vector2 launchDir;

    void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();
        trail = GetComponentInChildren<TrailRenderer>();
        launchBall();
    }

    public void launchBall()
    {
        trail.Clear();
        // Setup inital direction
        bool isStartingLeft = UnityEngine.Random.Range(0.0f, 1.0f) >= 0.5f;
        float x = 1.0f;
        if(isStartingLeft)
        {
            x = -1.0f;
        }

        float y = UnityEngine.Random.Range(-1.0f, 1.0f);
        x = 1.0f;
        y = 0;
        Vector2 initialVelocity = new Vector2(x, y);
        initialVelocity = initialVelocity.normalized * initalSpeed;
        launchDir = initialVelocity;
        ballRB.linearVelocity = initialVelocity;
        
    }
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        ICollideable[] collideableObjects = collision2D.collider.GetComponents<ICollideable>();

        foreach (ICollideable collideableObj in collideableObjects)
        {
            collideableObj.collide(this, collision2D);
        }

        if(collideableObjects == null)
        {
            Debug.LogError("Ball collided with something it's not meant to!");
        }
    }

    void updateTrailLength()
    {
        double baseSpeed = 10;
        float trailLengthTime = (float) math.log10((ballRB.linearVelocity.magnitude/baseSpeed) + trailTimeOffset);
        trail.time = trailLengthTime;
    }
    void Update()
    {
        // updateTrailLength();
    }
}

public interface ICollideable
{
    void collide(BallLogic ball, Collision2D collision2D);

    
}
