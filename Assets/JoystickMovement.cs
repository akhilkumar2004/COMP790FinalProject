using UnityEngine;
using UnityEngine.XR;

public class JoystickMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public float gravity = -9.81f;
    public float rotationSpeed = 100f;
    public float pitchLimit = 80f;
    private CharacterController characterController;
    private Transform cameraTransform;
    private Vector3 velocity;
    private float cameraPitch = 0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        Vector2 leftInputAxis;
        InputDevice leftDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        if (leftDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out leftInputAxis))
        {
            Vector3 direction = cameraTransform.forward * leftInputAxis.y + cameraTransform.right * leftInputAxis.x;
            direction.y = 0;
            characterController.Move(direction * speed * Time.deltaTime);
        }

        Vector2 rightInputAxis;
        InputDevice rightDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        if (rightDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out rightInputAxis))
        {
            float yawRotation = rightInputAxis.x * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, yawRotation, 0);

            float pitchRotation = -rightInputAxis.y * rotationSpeed * Time.deltaTime;
            cameraPitch = Mathf.Clamp(cameraPitch + pitchRotation, -pitchLimit, pitchLimit);
            cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);
        }

        if (characterController.isGrounded)
        {
            velocity.y = 0f;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        characterController.Move(velocity * Time.deltaTime);
    }
}