using UnityEngine;

public class ImpactParticle : MonoBehaviour
{
    ParticleSystem impactParticles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        impactParticles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayImpact(Vector2 position, Vector2 directionToEmit, float weight)
    {
        transform.position = position;
        transform.rotation = Quaternion.LookRotation(directionToEmit, Vector3.up);
        impactParticles.Play();
    }
}
