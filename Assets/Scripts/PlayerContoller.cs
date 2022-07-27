using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    private CanonBehaviour canon;
    [SerializeField] private float k_z_rotation = 0.2f;

    private void Start()
    {
        canon = GetComponentInChildren<CanonBehaviour>();
    }

    private void Update()
    {
        
        //if (Input.GetMouseButton(0))
        if (Input.touchCount > 0)
        {
            canon.Shoot();
        }

        
        foreach (Touch i in Input.touches)
        {
            canon.RotateMuzzle(i.deltaPosition.y * k_z_rotation);
        }
        
    }
    
}
