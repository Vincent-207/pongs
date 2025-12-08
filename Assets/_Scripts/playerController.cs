using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    [SerializeField]
    InputActionReference move;
    [SerializeField]
    float moveSpeed, bottomBound, topBound;
    void Update()
    {
        float moveInput = move.action.ReadValue<Vector2>().y;
        transform.position = transform.position + (Vector3.up * moveInput * moveSpeed * Time.deltaTime);
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
