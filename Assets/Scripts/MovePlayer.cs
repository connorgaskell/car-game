using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
    private Vector3 normalizeDirection;

    public Transform target;
    public float speed = 5f;

    void Start() {
        normalizeDirection = (new Vector3(target.position.x, transform.position.y, target.position.z) - transform.position).normalized;
    }

    void Update() {
        transform.position += normalizeDirection * speed * Time.deltaTime;
    }
}
