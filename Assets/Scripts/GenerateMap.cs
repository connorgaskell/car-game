using UnityEngine;

public class GenerateMap : MonoBehaviour {

    public Transform groundPrefab;
    public Transform player;

    Transform lastInstantiated;

    void Start() {
        for (int i = 0; i < 25; i++) {
            lastInstantiated = Instantiate(groundPrefab, new Vector3(0, 0, (i * (groundPrefab.localScale.y * 2))), groundPrefab.rotation);
        }
    }

    void Update() {
        if(Vector3.Distance(player.position, lastInstantiated.position) < 1000) {
            lastInstantiated = Instantiate(groundPrefab, new Vector3(0, 0, (lastInstantiated.position.z + (groundPrefab.localScale.y * 2))), groundPrefab.rotation);
        }
    }
}
