using UnityEngine;

public class ImpactParticle : MonoBehaviour
{
    public ParticleSystem particleSystem;
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    public void PlayImpact(Vector2 position, Transform emitTarget, float weight)
    {
        transform.position = position;

        transform.LookAt(emitTarget, Vector3.up);
        particleSystem.Play();
    }
    public void PlayImpact(Vector2 position, Vector2 emitDirection, float weight)
    {
        transform.position = position;
        
        transform.rotation = Quaternion.LookRotation(emitDirection, Vector3.up);
        particleSystem.Play();
    }
}
