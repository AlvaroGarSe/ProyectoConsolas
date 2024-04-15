using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeBarrelScript : MonoBehaviour
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

    public void UpgradeFireRate()
    {
        m_SoldierGroupScript.FireRateUpgraded();
    }
}
