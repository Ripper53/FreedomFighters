using UnityEngine;

public class AutoSpaceBehavior : MonoBehaviour {
    public LayerMask DetectionMask;

    protected new Rigidbody rigidbody;

    protected SpaceThrust thrust;
    protected SpaceRotation rotation;
    protected SpaceLift lift;

    protected void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        thrust = GetComponent<SpaceThrust>();
        rotation = GetComponent<SpaceRotation>();
        lift = GetComponent<SpaceLift>();
    }

    private float thrustTimer = 0f, rotationTimer = 0f, liftTimer = 0f;
    protected Collider[] hits = new Collider[1];
    protected void FixedUpdate() {
        if (thrustTimer > 0f)
            thrustTimer -= Time.fixedDeltaTime;
        if (rotationTimer > 0f)
            rotationTimer -= Time.fixedDeltaTime;
        if (liftTimer > 0f)
            liftTimer -= Time.fixedDeltaTime;
        /*timer -= Time.fixedDeltaTime;
        if (timer <= 0f) {
            timer = Random.Range(1f, 2f);
            thrust.Thurst = Random.Range(0f, 1f);
            rotation.Rotation = Random.Range(-1f, 1f);
            lift.Lift = Random.Range(-1, 1f);
        }*/
        if (Physics.OverlapSphereNonAlloc(rigidbody.position, 1000f, hits, DetectionMask) != 0) {
            Collider hit = hits[0];
            Vector3 targetDirection = (hit.attachedRigidbody.position - rigidbody.position).normalized;
            Vector3 ourDirection = rigidbody.transform.forward;
            // Face Target
            float dot = Vector3.Dot(targetDirection, ourDirection);
            Vector3 targetDiff = targetDirection - ourDirection;
            //Debug.Log("DOT: " + dot);
            if (dot < 0.5f) {
                // We are too far, take drastic action!
                if (targetDiff.x > 0.25f && targetDiff.x < -0.25f) {
                    //thrust.Thurst = 1f;
                } else {
                    
                }
            } else {
                // Slight adjustments!
                if (targetDiff.x > 0f) {
                    SetRotation(1f);
                } else {
                    SetRotation(1f);
                }
                if (targetDiff.z > 0f) {
                    SetThrust(1f);
                } else {
                    SetThrust(0f);
                }
                if (targetDiff.y > 0f) {
                    SetLift(1f);
                } else {
                    SetLift(-1f);
                }
            }
        }
    }

    private void SetThrust(float thrust) {
        if (thrustTimer > 0f) return;
        this.thrust.Thurst = thrust;
        //thrustTimer = 0.25f;
        thrustTimer = 0f;
    }

    private void SetRotation(float rotation) {
        if (rotationTimer > 0f) return;
        this.rotation.Rotation = rotation;
        //rotationTimer = 0.25f;
        rotationTimer = 0f;
    }

    private void SetLift(float lift) {
        if (liftTimer > 0f) return;
        this.lift.Lift = lift;
        //liftTimer = 0.25f;
        liftTimer = 0f;
    }

}
