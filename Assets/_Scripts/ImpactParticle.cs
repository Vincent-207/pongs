using UnityEngine;

public class ImpactParticle : MonoBehaviour
{
    public AudioSource hitSound;
    public ParticleSystem myParticles;
    [SerializeField] 
    float baseSize, sizeRange;
    void Start()
    {
        myParticles = GetComponent<ParticleSystem>();
        hitSound = GetComponent<AudioSource>();
    }

    public void PlayImpact(Vector2 position, Transform emitTarget, float weight)
    {
        transform.position = position;
        transform.LookAt(emitTarget, Vector3.up);
        myParticles.Play();
    }
    void updateSizeCurve(float weight)
    {
        ParticleSystem.MinMaxCurve sizeCurve = new ParticleSystem.MinMaxCurve();
        sizeCurve.mode = ParticleSystemCurveMode.TwoConstants;
        sizeCurve.constantMin = baseSize * weight;
        sizeCurve.constantMin = baseSize * weight * sizeRange;

        ParticleSystem.MainModule main = myParticles.main;
        main.startSize = sizeCurve;
        
    }
    public void PlayImpact(Vector2 position, Vector2 emitDirection, float weight)
    {
        transform.position = position;
        updateSizeCurve(weight);
        transform.rotation = Quaternion.LookRotation(emitDirection, Vector3.up);
        myParticles.Play();
        hitSound.Play();
    }
    public bool isPlaying()
    {
        if(myParticles.isPlaying)
        {
            return true;
        }

        if (hitSound.isPlaying)
        {
            return true;
        }


        return false;
    }
}
