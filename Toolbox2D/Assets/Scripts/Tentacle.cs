using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Transform targetDir;
    [SerializeField] int length;
    [SerializeField] LineRenderer lineRend;
    [SerializeField] Vector3[] segmentPositions;
    [SerializeField] Vector3[] segmentVelocities;
    [SerializeField] float desiredDistance;
    [SerializeField] float smoothSpeed;
    [SerializeField] float trailspeed;


    [SerializeField] Transform wiggleDir;
    [SerializeField] float wiggleSpeed;
    [SerializeField] float wiggleMagnitude;


    private void Start()
    {
        lineRend.positionCount = length;
        segmentPositions = new Vector3[length];
        segmentVelocities = new Vector3[length];
    }

    private void Update()
    {
        wiggleDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);

        segmentPositions[0] = targetDir.position;

        for(int i = 1; i < segmentPositions.Length; i++)
        {
            segmentPositions[i] = Vector3.SmoothDamp(segmentPositions[i], segmentPositions[i-1] + targetDir.right * desiredDistance * -1f, ref segmentVelocities[i], smoothSpeed + i/trailspeed);
        }

        lineRend.SetPositions(segmentPositions);
    }
}
