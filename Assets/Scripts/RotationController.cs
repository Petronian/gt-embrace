using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public Transform transformAtSocket;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool allowRotationSpeedChanges = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float rotation360 = rotationSpeed / Mathf.PI * 180;
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + rotation360 * Time.deltaTime);

        if (transformAtSocket != null)
        {
            transformAtSocket.position = gameObject.transform.GetChild(1).position;
        }
    }

    public bool SetRotationSpeed(float newSpeed)
    {
        if (allowRotationSpeedChanges) rotationSpeed = newSpeed;
        return allowRotationSpeedChanges;
    }

    public float GetRotationSpeed()
    {
        return rotationSpeed;
    }
}
