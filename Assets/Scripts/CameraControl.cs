using UnityEngine;

public class CameraControl : MonoBehaviour {
    public Transform target;
    
    [Range(-10.0f, 10.0f)]
    public float speed = 1.0f;

    [Range(-25.0f, 25.0f)]
    public float xOffset = 0.0f;

    [Range(-25.0f, 25.0f)]
    public float zOffset = 0.0f;

    [Range(0.0f, 25.0f)]
    public float yPosition = 5.0f;
    
    void LateUpdate () {        
        Vector3 position = transform.position;
        position.x = Mathf.Lerp(transform.position.x, target.position.x + xOffset, speed * Time.deltaTime);
        position.y = yPosition;
        position.z = Mathf.Lerp(transform.position.z, target.position.z - zOffset, speed * Time.deltaTime);
        
        transform.position = position;
        transform.LookAt(target);
    }
}
