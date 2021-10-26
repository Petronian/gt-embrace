using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatingLerpRotationScheduler : MonoBehaviour
{
    /**
     * Custom rotation scheduler class for controlling the rotations of select components.
     * 
     * Base class just meant for other schedulers that define specific things.
     */
    [SerializeField] private List<RotationController> controllers;
    [SerializeField] private List<Vector2> limits;
    [SerializeField] private float timeInterval = 1;

    private float lerpProgress;
    private int lerpMultiplier;
    private readonly Dictionary<RotationController,KeyValuePair<float,float>> entities 
        = new Dictionary<RotationController, KeyValuePair<float, float>>();

    private void Start()
    {
        // Construct the list of entities.
        for (int i = 0; i < controllers.Count; i++)
        {
            entities.Add(controllers[i], new KeyValuePair<float, float>(limits[i].x, limits[i].y));
            controllers[i].SetRotationSpeed(limits[i].x);
        }

        // Set up the lerping code.
        lerpProgress = 0;
        lerpMultiplier = 1;
    }

    private void Update()
    {
        // Update lerpProgress.
        lerpProgress += Time.deltaTime / timeInterval * lerpMultiplier;

        if (lerpProgress < 0)
        {
            lerpProgress = 0;
            lerpMultiplier = 1;
        }
        else if (lerpProgress > 1)
        {
            lerpProgress = 1;
            lerpMultiplier = -1;
        }

        // Apply lerping update to each person.
        foreach(KeyValuePair<RotationController, KeyValuePair<float,float>> entity in entities)
        {
            entity.Key.SetRotationSpeed(Mathf.Lerp(entity.Value.Key, entity.Value.Value, lerpProgress));
        }
    }
}
