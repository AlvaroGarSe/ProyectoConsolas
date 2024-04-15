    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float m_MaxLifeTime;
    public float m_LifeTime;
    private BulletPoolManager m_BulletPoolManager;
    private BarrelController m_BarrelSrcipt;
    private NormalEnemyController m_NormalEnemyScript;


    private void Awake()    
    {
        m_BulletPoolManager = FindObjectOfType<BulletPoolManager>();
    }

    // Update is called once per frame
    void Update()
    {
        m_LifeTime -= Time.deltaTime;
        if (m_LifeTime <= 0)
        {
            m_BulletPoolManager.ReturnShell(gameObject);
        }
    }

    private void OnEnable()
    {
        m_LifeTime = m_MaxLifeTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Barrel"))
        {
            m_BarrelSrcipt = collision.gameObject.GetComponent<BarrelController>();
            m_BarrelSrcipt.m_CurrentHealthPoints--;
            m_BulletPoolManager.ReturnShell(gameObject);
        }
        if (collision.gameObject.CompareTag("NormalEnemy"))
        {
            m_NormalEnemyScript = collision.gameObject.GetComponent<NormalEnemyController>();
            m_NormalEnemyScript.m_CurrentHealthPoints--;
            m_BulletPoolManager.ReturnShell(gameObject);
        }
    }
}
