using UnityEngine;
using UnityEngine.UI;

public class TargetFollowCameraManager : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 0, -10);
    private Vector3 velocity = Vector3.zero;

    [Header("References")]
    [SerializeField] private Transform targetTransform;

    [Header("Properties")]
    [SerializeField] private float smoothTime = 0.25f;
    [SerializeField, Range(0.0f, 100.0f)] private float radiusLimit = 0.5f;

    private void FollowPlayer()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetTransform.position + offset, ref velocity, smoothTime);
    }

    private void CheckLimit()
    {
        float distance = Vector3.Distance((transform.position - offset), targetTransform.position);
        if (distance > radiusLimit)
        {
            transform.position += (targetTransform.position + offset - transform.position).normalized * (distance - radiusLimit);
        }
    }

    private void Update()
    {
        FollowPlayer();
        CheckLimit();
    }
}
