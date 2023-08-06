using UnityEngine;
public class Inputs : MonoBehaviour
{
    [Range(0,100)]
    [SerializeField] private float value;
    private void Update() 
    {
       Values.value = value;
    }
}
