using UnityEngine;

public class MyFirstScript :  MonoBehaviour
{
    Transform monTransform = GetComponent<Transform>();
    void Start()
    {
        
    }

    void Update()
    { 
        monTransform.position = new Vector3(0.01,0,0);
    }
}
