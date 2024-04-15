using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBarrelScript : MonoBehaviour
{
    private SoldierGroupController m_SoldierGroupScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetPowerUp()
    {
        m_SoldierGroupScript = FindAnyObjectByType<SoldierGroupController>();
        m_SoldierGroupScript.PowerUp(true);
    }
}
