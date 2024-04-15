using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitsScript : MonoBehaviour
{
    private SoldierGroupController m_SoldierGroupScript;
    
    
    // Start is called before the first frame update
    void Start()
    {
        m_SoldierGroupScript = FindAnyObjectByType<SoldierGroupController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Soldier"))
        {
            if (other.transform.position.z > 0)
            {
                m_SoldierGroupScript.m_LeftLimit = true;
            }else { m_SoldierGroupScript.m_RightLimit = true; }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Soldier"))
        {
            m_SoldierGroupScript.m_RightLimit = false;
            m_SoldierGroupScript.m_LeftLimit = false;
        }
    }
}
