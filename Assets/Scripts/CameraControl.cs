using UnityEngine;

public class CameraControl : MonoBehaviour {
    public Transform target;
    
    public float speed = 1.0f;
    
    void LateUpdate () {        
        Vector3 position = transform.position;
        position.x = Mathf.Lerp(transform.position.x, target.position.x, speed * Time.deltaTime);
        position.z = Mathf.Lerp(transform.position.z, target.position.z - 2.5f, speed * Time.deltaTime);
        
        transform.position = position;
        transform.LookAt(target);
    }
}
