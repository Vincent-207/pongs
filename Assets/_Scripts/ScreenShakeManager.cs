using System.Collections;
using UnityEngine;

public class ScreenShakeManager : MonoBehaviour
{
    [SerializeField]
    float testShakeStrength, testShakeDuration;
    [SerializeField]
    Transform targetTransform;
    [SerializeField] AnimationCurve shakeCurve;
    float duration = 1f;
    public bool start;
    void Update()
    {
        if(start)
        {
            start = false;
            StartCoroutine(Shake());
        }
    }
    IEnumerator Shake()
    {
        
        Vector3 startPosition = Camera.main.transform.position;
        float elapsedTime= 0f;
        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = startPosition + Random.insideUnitSphere * shakeCurve.Evaluate(elapsedTime/duration);
            yield return null;
        }
        Camera.main.transform.position = targetTransform.position;
    }

    public void DoStart()
    {
        start = true;
    }
}