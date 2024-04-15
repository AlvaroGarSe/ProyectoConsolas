using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraSoldierBarrel : MonoBehaviour
{
    private SoldierGroupController m_SoldierGroupScript;
    public int m_NumNewSoldiers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetExtraSoldier()
    {
        m_SoldierGroupScript = FindAnyObjectByType<SoldierGroupController>();
        m_SoldierGroupScript.AddSoldier(m_NumNewSoldiers);
    }
}
