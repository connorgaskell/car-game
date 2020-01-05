using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {
    void Update () {
        if(transform.position.z - Camera.main.transform.position.z < -100) {
            Destroy (gameObject);
        }
    }
}
