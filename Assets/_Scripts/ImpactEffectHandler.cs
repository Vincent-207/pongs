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
    [SerializeField]
    float shakeDuration = 0.1f;
    [SerializeField]
    float shakeScalar = 0.1f;
    bool startShake = false;
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
    }
    public void collide(BallLogic ball, Collision2D collision2D)
    {
        // Reflect the ball's velocity
        Vector2 ballVelocity = ball.ballRB.linearVelocity; 
        Vector2 collisionNormal = collision2D.contacts[0].normal;
        Vector2 bouncedVelocity = Vector2.Reflect(ballVelocity, collisionNormal);
        ContactPoint2D contactPoint2D = collision2D.contacts[0];
        
        
        float weight = (contactPoint2D.normalImpulse - 5) / 10;
        playImpact(contactPoint2D.point, contactPoint2D.normal, weight);
        // StartCoroutine(Shaking());

        if(startShake)
        {
            StartCoroutine(ScreenShake(weight));
        }
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
        Debug.Log("Weight: " + weight);
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
        startShake = true;
    }

    IEnumerator ScreenShake(float weight)
    {
        Transform cameraTransform = Camera.main.transform;
        Vector3 startPosition = cameraTransform.position;
        float elapsedTime= 0f;
        while(elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;
            cameraTransform.position = startPosition + Random.insideUnitSphere * shakeCurve.Evaluate(elapsedTime/shakeDuration) * shakeScalar;
            yield return null;
        }
        cameraTransform.position = startPosition;
    }
}
