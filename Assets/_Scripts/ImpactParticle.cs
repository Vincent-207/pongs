using UnityEngine;

public class ImpactParticle : MonoBehaviour
{
    ParticleSystem impactParticles;
    void Start()
    {
        impactParticles = GetComponent<ParticleSystem>();
    }

    public void PlayImpact(Vector2 position, Transform emitTarget, float weight)
    {
        transform.position = position;

        transform.LookAt(emitTarget, Vector3.up);
        impactParticles.Play();
    }
    public void PlayImpact(Vector2 position, Vector2 emitDirection, float weight)
    {
        transform.position = position;
        
        transform.rotation = Quaternion.LookRotation(emitDirection, Vector3.up);
        impactParticles.Play();
    }
}
