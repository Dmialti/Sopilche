using UnityEngine;

public class WeaponHolderManager : MonoBehaviour
{
    #region Variables

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
        Vector3 direction = (worldMousePosition - characterTransform.position).normalized;
        transform.position = characterTransform.position + direction * offset;
    }


    #endregion

    void Start()
    {
        
    }

    void Update()
    {
        RefreshPosition();
    }
}
