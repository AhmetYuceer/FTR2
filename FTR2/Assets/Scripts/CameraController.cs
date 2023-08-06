using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject camParent;
    [SerializeField] private float camRotateSpeed;
    void Update()
    {
        camParent.transform.Rotate(0,camRotateSpeed * Time.deltaTime,0);
    }
}