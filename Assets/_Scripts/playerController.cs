using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    [SerializeField]
    InputActionReference move;
    [SerializeField]
    float moveSpeed, bottomBound, TopBound;
    void Update()
    {
        float moveInput = move.action.ReadValue<Vector2>().y;
        transform.position = transform.position + (Vector3.up * moveInput * moveSpeed * Time.deltaTime);
        
    }
}
