using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessDaisyController : MonoBehaviour
{
    void Update()
    {
        RotateDaisy();
    }
    private void RotateDaisy()
    {
        transform.Rotate(0,90 * Time.deltaTime,0) ;
    }
}
