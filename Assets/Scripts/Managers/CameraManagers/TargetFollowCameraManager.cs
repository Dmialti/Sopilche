using UnityEngine;

public class TargetFollowCameraManager : MonoBehaviour
{
    [SerializeField] private Transform targetPosition;
    private Vector3 offset = new Vector3(0, 0, -10);
    [SerializeField] private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    private void FollowPlayer()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition.position + offset, ref velocity, smoothTime);
    }

    void Awake()
    {
    }

    private void Update()
    {
        FollowPlayer();
    }
}
