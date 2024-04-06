using UnityEngine;

public class SpaceRotation : MonoBehaviour {
    private new Rigidbody rigidbody;
    public float Speed;

    protected void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private float rotation;
    public float Rotation {
        get => rotation;
        set => rotation = Mathf.Clamp(value, -1f, 1f);
    }

    protected void OnEnable() {
        rotation = 0f;
    }

    protected void FixedUpdate() {
        rigidbody.AddRelativeTorque(new Vector3(0f, 0f, -Rotation * Speed), ForceMode.Acceleration);
    }

}
