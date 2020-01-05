using UnityEngine;

public class GenerateMap : MonoBehaviour {

    public Transform groundPrefab;
    public Transform player;

    Transform lastInstantiated;

    bool yDirectionUp = true;
    bool xDirectionRight = true;

    void Start() {
        for (int i = 0; i < 5; i++) {
            lastInstantiated = Instantiate(groundPrefab, new Vector3(0, 0, (i * (groundPrefab.localScale.y * 2))), groundPrefab.rotation);
        }

        //InvokeRepeating("ChangeHorizonBend", 0, 1f);
    }

    void Update() {
        if(Vector3.Distance(player.position, lastInstantiated.position) < 50) {
            lastInstantiated = Instantiate(groundPrefab, new Vector3(0, 0, (lastInstantiated.position.z + (groundPrefab.localScale.y * 2))), groundPrefab.rotation);
        }
    }

    void ChangeHorizonBend() {
        HorizonBending hb = GetComponent<HorizonBending>();

        int rollX = Random.Range(0, 100);
        if(rollX >= 75) {
            if(rollX >= 90 && hb.x < 100) {
                xDirectionRight = true;
            } else if(rollX < 90 && hb.x > -50) {
                xDirectionRight = false;
            }
        }

        int rollY = Random.Range(0, 100);

        /*if(hb.x >= 100) {
            yDirectionUp = false;
        } else if(hb.x <= -100) {
            yDirectionUp = true;
        }*/

        if(xDirectionRight) {
            hb.x = hb.x + 1;
        } else {
            hb.x = hb.x - 1;
        }
    }
}
