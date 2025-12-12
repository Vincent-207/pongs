using System.Collections;
using UnityEngine;

public class ImpactEffectHandler : MonoBehaviour, ICollideable
{
    [SerializeField]
    GameObject impactParticlePrefab;
    [SerializeField]
    int particleSystemPoolSize;
    [SerializeField]
    ImpactParticle[] impactParticles;
    int currentImpactParticle;
    Camera myCam;
    [Header("Screen Shake")]
    public AnimationCurve shakeCurve;
    float shakeStrength;
    float shakeDuration = 1f;
    bool doShake;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        impactParticles = new ImpactParticle[particleSystemPoolSize];
        myCam = Camera.main;
        for(int i = 0; i < particleSystemPoolSize; i++)
        {
            GameObject childParticleSystem = Instantiate(impactParticlePrefab, transform);
            impactParticles[i] = childParticleSystem.GetComponent<ImpactParticle>();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(doShake)
        {
            doShake = false;
            StartCoroutine(Shaking());
        }
    }
    IEnumerator Shaking()
    {
        Vector3 startPosition = myCam.transform.position;
        float elapsedTime = 0f;
        Debug.Log("running");
        while(elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;
            Vector3 added = (Vector3) (Random.insideUnitSphere * shakeStrength * shakeCurve.Evaluate(elapsedTime / shakeDuration));
            // Debug.Log("Added: " + added);
            myCam.transform.position = startPosition + added;
            yield return null;
            
        }

        myCam.transform.position = startPosition;
    }
    public void collide(BallLogic ball, Collision2D collision2D)
    {
        // Reflect the ball's velocity
        Vector2 ballVelocity = ball.ballRB.linearVelocity; 
        Vector2 collisionNormal = collision2D.contacts[0].normal;
        Vector2 bouncedVelocity = Vector2.Reflect(ballVelocity, collisionNormal);
        ContactPoint2D contactPoint2D = collision2D.contacts[0];
        
        
        
        playImpact(contactPoint2D.point, contactPoint2D.normal, 1);
        doShake = true;
        // StartCoroutine(Shaking());
    }

    void drawDebugRays(BallLogic ball, Collision2D collision2D)
    {
        ContactPoint2D contactPoint2D = collision2D.contacts[0];
        Vector2 ballVelocity = ball.ballRB.linearVelocity; 
        Vector2 bouncedVelocity = Vector2.Reflect(ballVelocity, contactPoint2D.normal);
        
        Debug.DrawRay(contactPoint2D.point, contactPoint2D.normal, Color.green);
        Debug.DrawRay(ball.transform.position, ball.ballRB.linearVelocity, Color.yellow);
        Debug.DrawRay(ball.transform.position, Vector2.Reflect(ball.ballRB.linearVelocity, contactPoint2D.normal), Color.red);
    }

    void playImpact(Vector2 position, Vector2 direction, float weight)
    {
        if(impactParticles[currentImpactParticle].GetComponent<ParticleSystem>().isPlaying)
        {
            Debug.LogWarning("Not enough particles, interrupting this system");
            impactParticles[currentImpactParticle].GetComponent<ParticleSystem>().Stop();
        }

        impactParticles[currentImpactParticle].PlayImpact(position, direction, weight);

        currentImpactParticle++;
        if(currentImpactParticle == impactParticles.Length)
        {
            currentImpactParticle = 0;
        }
        
    }
}
