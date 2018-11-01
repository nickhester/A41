using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowIso : MonoBehaviour {

    public GameObject followTarget;

    private Vector3 targetToCameraOffset;

    private Transform targetTrans;
    private Transform cameraTrans;

    // Use this for initialization
    void Start () {
        targetTrans = followTarget.GetComponent<Transform>();
        cameraTrans = transform;

        targetToCameraOffset = targetTrans.position - cameraTrans.position;
    }
	
	// Update is called once per frame
	void Update () {
        cameraTrans.SetPositionAndRotation(targetTrans.position - targetToCameraOffset, cameraTrans.rotation);
	}
}
