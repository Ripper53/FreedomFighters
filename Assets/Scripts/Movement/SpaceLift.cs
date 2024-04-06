using UnityEngine;

public class SpaceLift : MonoBehaviour {
    private new Rigidbody rigidbody;
    public float Speed;

    protected void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private float lift;
    public float Lift {
        get => lift;
        set => lift = Mathf.Clamp(value, -1f, 1f);
    }

    protected void OnEnable() {
        lift = 0f;
    }

    protected void FixedUpdate() {
        rigidbody.AddRelativeTorque(new Vector3(-Lift * Speed, 0f, 0f), ForceMode.Acceleration);
    }
}
