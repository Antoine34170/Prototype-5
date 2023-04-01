using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBound : MonoBehaviour
{
    [SerializeField] private bool isFalling;
    private Rigidbody targetRb;
    private float previousYPos;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        previousYPos = transform.position.y;
        isFalling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetIsFalling() && transform.position.y < -0.5)
        {
            Destroy(gameObject);
        }
        previousYPos = transform.position.y;
    }

    private bool TargetIsFalling()
    {
        return targetRb.velocity.y < 0 && transform.position.y < -0.5;
    }
}
