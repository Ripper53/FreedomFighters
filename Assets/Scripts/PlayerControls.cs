using UnityEngine;

public class PlayerControls : MonoBehaviour {
    private PlayerInput input;

    private SpaceThrust thrust;
    private SpaceRotation rotation;
    private SpaceLift lift;

    protected void Awake() {
        thrust = GetComponent<SpaceThrust>();
        rotation = GetComponent<SpaceRotation>();
        lift = GetComponent<SpaceLift>();

        input = new PlayerInput();
        input.Movement.Thurst.performed += Thurst_performed;
        input.Movement.Thurst.canceled += Thurst_canceled;
        input.Movement.Rotation.performed += Rotation_performed;
        input.Movement.Rotation.canceled += Rotation_canceled;
        input.Movement.Lift.performed += Lift_performed;
        input.Movement.Lift.canceled += Lift_canceled;
    }

    protected void OnEnable() {
        input.Enable();
    }

    protected void OnDisable() {
        input.Disable();
    }

    private void Thurst_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        float value = obj.ReadValue<float>();
        thrust.Thurst = value;
    }

    private void Thurst_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        thrust.Thurst = 0f;
    }

    private void Rotation_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        float value = obj.ReadValue<float>();
        rotation.Rotation = value;
    }

    private void Rotation_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        rotation.Rotation = 0f;
    }

    private void Lift_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        float value = obj.ReadValue<float>();
        lift.Lift = value;
    }

    private void Lift_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        lift.Lift = 0f;
    }

}
