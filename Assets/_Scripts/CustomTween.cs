using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomTween : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    AnimationCurve hoverTweenCurve, exitTweenCurve;
    [SerializeField]
    float duration, elapsedTime;

    bool isHovering = false;
    bool isLeavingHover = false;
    void Start()
    {
        
    }
    void Update()
    {
        if(isHovering)
        {
            OnPointerHover();
        }
        if(isLeavingHover)
        {
            OnHoverLeave();
        }
    }

    public void OnHoverLeave()
    {
        transform.localScale = Vector3.one * exitTweenCurve.Evaluate(math.min(elapsedTime, duration));
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= duration)
        {
            ResetTween();
            isLeavingHover = false;
            return;
        }
    }

    public void OnPointerHover()
    {
        Debug.Log("Hovering!");
        transform.localScale = Vector3.one * hoverTweenCurve.Evaluate(math.min(elapsedTime, duration));
        elapsedTime += Time.deltaTime;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        isLeavingHover = false;
        ResetTween();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if(isHovering)
        {
            isLeavingHover = true;
        }
        isHovering = false;
        ResetTween();
    }

    void ResetTween()
    {
        elapsedTime = 0; 
        transform.localScale = Vector3.one;
        
    }
}
