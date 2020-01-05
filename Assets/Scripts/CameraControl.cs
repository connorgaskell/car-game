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
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, target.position.x + xOffset, speed * Time.deltaTime),
            Mathf.Lerp(transform.position.y, yPosition, speed * Time.deltaTime),
            Mathf.Lerp(transform.position.z, target.position.z - zOffset, speed * Time.deltaTime)
        );

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(target.position - transform.position), Time.time * 2.0f);
    }
}
