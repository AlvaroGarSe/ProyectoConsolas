using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyController : MonoBehaviour
{
    public int m_MaxHealthPoints;
    public int m_CurrentHealthPoints;

    void Start()
    {
        m_CurrentHealthPoints = m_MaxHealthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_CurrentHealthPoints <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        Destroy(gameObject);
    }
}
