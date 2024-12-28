using UnityEngine;

public class WeaponHolderManager : MonoBehaviour
{
    #region Variables

    Vector3 currentDirection;

    [Header("References")]
    [SerializeField] private Transform characterTransform;

    [Header("Settings")]
    [SerializeField, Range(0.0f, 10.0f)] private float offset = 0.5f;

    #endregion

    #region Methods

    private void RefreshPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = characterTransform.position.z - Camera.main.transform.position.z;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        currentDirection = (worldMousePosition - characterTransform.position).normalized;
        transform.position = characterTransform.position + currentDirection * offset;
    }

    private void RefreshRotation()
    {
        float angle = Mathf.Atan2(currentDirection.y, currentDirection.x) * Mathf.Rad2Deg;
        
        if(angle > 90 || angle < -90)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            angle -= 180;
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    #endregion

    void Start()
    {
        
    }

    void Update()
    {
        RefreshPosition();
        RefreshRotation();
    }
}
