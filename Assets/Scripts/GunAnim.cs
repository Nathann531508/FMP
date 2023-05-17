using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnim : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            animator.Play("Shoot");
        }
        
    }
}
