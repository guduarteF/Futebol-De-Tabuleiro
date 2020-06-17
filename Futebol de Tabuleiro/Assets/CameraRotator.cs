using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float speed;
    private bool stoprotate;

    void Start()
    {
        StartCoroutine(timetorotate());
    }

    // Update is called once per frame
    void Update()
    {
        if(stoprotate == false)
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    IEnumerator timetorotate()
    {
        yield return new WaitForSeconds(14.4f);
        stoprotate = true;
    }
}
