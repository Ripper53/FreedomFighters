using UnityEngine;

public class SpaceThrust : MonoBehaviour {
    private new Rigidbody rigidbody;
    public float Speed;

    protected void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private float thrust;
    public float Thurst {
        get => thrust;
        set => thrust = Mathf.Clamp(value, -1f, 1f);
    }

    protected void OnEnable() {
        thrust = 0f;
    }

    protected void FixedUpdate() {
        rigidbody.AddRelativeForce(new Vector3(0f, 0f, Thurst * Speed), ForceMode.Acceleration);
    }

}
