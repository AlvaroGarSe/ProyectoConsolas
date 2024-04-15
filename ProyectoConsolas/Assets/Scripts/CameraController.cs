using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform m_CameraChild;
    public GameObject m_Soldiers;
    public Vector3 m_DifferenceInPosition = new Vector3(-70f, 61f, 7f);

    // Start is called before the first frame update
    void Start()
    {
        m_CameraChild = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        AttachCameraToPlayer();
    }

    private void AttachCameraToPlayer()
    {
        transform.position = m_Soldiers.transform.position - m_DifferenceInPosition;
    }

}
