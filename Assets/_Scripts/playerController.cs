using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    [SerializeField]
    InputActionReference move;
    [SerializeField]
    float moveSpeed, bottomBound, topBound;
    void FixedUpdate()
    {
        float moveInput = move.action.ReadValue<Vector2>().y;
        Debug.Log("Moveinput " + moveInput);
        Debug.LogWarning("Move amount Player: " + moveInput * moveSpeed * Time.deltaTime);
        transform.position = transform.position + (Vector3.up * moveInput * moveSpeed);
        applyBounds();
    }
    void applyBounds()
    {
        if(transform.position.y > topBound)
        {
            transform.position = new Vector2(transform.position.x, topBound);
        }
        else if(transform.position.y < bottomBound)
        {
            transform.position = new Vector2(transform.position.x, bottomBound);
        }
    }
}
