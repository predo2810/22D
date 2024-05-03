using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform PlayerCameraTransform;
    [SerializeField] private Transform PlayerTransform;

    [SerializeField] private Vector3 Offset;

    private void FixedUpdate()
    {
        PlayerCameraTransform.position = new Vector3(PlayerTransform.position.x, 0, 0) + Offset;
    }
}
