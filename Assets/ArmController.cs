using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{

    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform connectedBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eulerAngles = gameObject.transform.rotation.eulerAngles;
        gameObject.transform.rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z + rotationSpeed * Time.deltaTime);

        if (connectedBody != null)
        {
            connectedBody.position = gameObject.transform.GetChild(1).position;
        }
    }
}
