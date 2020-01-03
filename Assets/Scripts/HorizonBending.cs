using UnityEngine;

[ExecuteInEditMode]
public class HorizonBending : MonoBehaviour {
    [Range(-1000f, 1000f)]
    [SerializeField]
    public float x, y, z = 0f;
 
    [Range(0f, 50f)]
    [SerializeField]
    float falloffAmount = 0f;
 
    private int bendAmountId;
    private int bendOriginId;
    private int bendFalloffId;
 
    void Start () {
        bendAmountId = Shader.PropertyToID("_BendAmount");
        bendOriginId = Shader.PropertyToID("_BendOrigin");
        bendFalloffId = Shader.PropertyToID("_BendFalloff");
    }
    
    void Update () {
        Shader.SetGlobalVector(bendAmountId, new Vector3(x, y, z));
        Shader.SetGlobalVector(bendOriginId, transform.position);
        Shader.SetGlobalFloat(bendFalloffId, falloffAmount);
    }
}
