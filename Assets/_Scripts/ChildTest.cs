using UnityEngine;

public class ChildTest : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Starting children: " + transform.childCount);
        GameObject testChild1 = new GameObject("Test child 1");
        testChild1.transform.SetParent(transform);
        Debug.Log("child parent name: " + testChild1.transform.parent.name);
        Debug.Log("Ending children: " + transform.childCount);

    }
}
