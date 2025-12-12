using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomTween : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    AnimationCurve tweenCurve;
    [SerializeField]
    float duration, elapsedTime;

    bool isHovering = false;

    void Start()
    {
        
    }
    void Update()
    {
        if(isHovering)
        {
            OnPointerHover();
        }
    }

    public void OnPointerHover()
    {
        Debug.Log("Hovering!");
        transform.localScale = Vector3.one * tweenCurve.Evaluate(math.min(elapsedTime, duration));
        elapsedTime += Time.deltaTime;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        ResetTween();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        ResetTween();
    }

    void ResetTween()
    {
        elapsedTime = 0; 
        transform.localScale = Vector3.one;
        
    }
}
