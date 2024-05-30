using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    private BulletPoolManager m_BulletPoolManager;
    private SoldierGroupController m_SoldierGroupScript;
    public Transform m_BulletSpawnPoint;
    private float m_FireRate = 0.5f;
    private float m_RemainingFireRate;
    public int m_NumUpgrades;
    public bool m_InPowerUp;
    private float m_PowerUpShootSpeed;

    void Start()
    {
        m_BulletPoolManager = FindObjectOfType<BulletPoolManager>();
        m_SoldierGroupScript = FindObjectOfType<SoldierGroupController>();
        GetComponent<Rigidbody>().sleepThreshold = 0;
        m_RemainingFireRate = m_FireRate;
        m_NumUpgrades = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(dt);
        }
        */
        if (m_InPowerUp)
        {
            m_PowerUpShootSpeed = 0.3f;
        }else { m_PowerUpShootSpeed = 0; }
        Shoot(dt);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Barrel") || other.gameObject.CompareTag("NormalEnemy"))
        {
            m_SoldierGroupScript.RemoveSoldier(this.gameObject);
            Destroy(gameObject);
        }
    }
    private void Shoot(float dt)
    {
        
        if((m_RemainingFireRate)<=(0.05f * m_NumUpgrades + m_PowerUpShootSpeed))
        {
            m_RemainingFireRate = m_FireRate;
            SpawnBullet();
        }else
        {
            m_RemainingFireRate -= dt;
        }
        
    }

    private void SpawnBullet()
    {
        GameObject bullet = m_BulletPoolManager.TakeShell();
        bullet.transform.position = m_BulletSpawnPoint.position;
        bullet.transform.rotation = m_BulletSpawnPoint.rotation;

        Rigidbody shellRB = bullet.GetComponent<Rigidbody>();
        shellRB.velocity = Vector3.zero;
        shellRB.angularVelocity = Vector3.zero;
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.right * 1000);
    }
}
