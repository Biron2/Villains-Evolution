using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 50f;
    [SerializeField] private Transform wp1;
    [SerializeField] private Transform wp2;
    [SerializeField] private Transform wp3;
    [SerializeField] private Transform wp4;
    [SerializeField] private Transform wp5;
    [SerializeField] private Transform wp6;

    void Update()
    {
        wp1.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        wp2.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        wp3.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        wp4.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        wp5.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        wp6.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}