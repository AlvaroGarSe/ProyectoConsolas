using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    public GameObject m_NomalBarrelPrefab;
    public GameObject m_UpgradeBarrelPrefab;
    public GameObject m_ExtraSoldierBarrelPrefab;
    public GameObject m_PowerUpBarrelPrefab;
    private BarrelController m_BarrelScript;

    public Transform m_Spawner1;
    public Transform m_Spawner2;
    public Transform m_Spawner3;
    public Transform m_Spawner4;

    private GameObject m_Barrel;

    private int m_RandomNumber;
    private Transform m_SpawnPoint;
    public int m_CurrentDifficulty = 1;
    public int m_DifficultyCountdown = 0;
    private float m_MaxCooldownSpawn = 3f;
    private float m_CurrentCooldownSpawn;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentCooldownSpawn = m_MaxCooldownSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_CurrentCooldownSpawn <= 0)
        {
            m_CurrentCooldownSpawn = m_MaxCooldownSpawn;
            m_DifficultyCountdown++;
            SpawnBarrel();
        }
        else
        {
            m_CurrentCooldownSpawn -= Time.deltaTime;
        }
        if(m_DifficultyCountdown >= 10)
        {
            m_CurrentDifficulty++;
            m_DifficultyCountdown = 0;
        }
    }

    private void SpawnBarrel()
    {
        m_RandomNumber = Random.Range(0, 4);
        switch(m_RandomNumber)
        {
            case 0:
                m_SpawnPoint = m_Spawner1;
                break;
            case 1:
                m_SpawnPoint = m_Spawner2;
                break;
            case 2:
                m_SpawnPoint = m_Spawner3;
                break;
            case 3:
                m_SpawnPoint = m_Spawner4;
                break;
        }
        if (Random.Range(0,2) == 0)
        {
            m_Barrel = Instantiate(m_NomalBarrelPrefab, m_SpawnPoint);
            m_BarrelScript = m_Barrel.GetComponent<BarrelController>();
            m_BarrelScript.ChangeHP(Random.Range(20, 51) * m_CurrentDifficulty);
        }else
        {
            switch(Random.Range(0,3))
            {
                case 0:
                    m_Barrel = Instantiate(m_UpgradeBarrelPrefab, m_SpawnPoint);
                    break;
                case 1:
                    m_Barrel = Instantiate(m_ExtraSoldierBarrelPrefab, m_SpawnPoint);
                    break;
                case 2:
                    m_Barrel = Instantiate(m_PowerUpBarrelPrefab, m_SpawnPoint);
                    break;
            }
            m_BarrelScript = m_Barrel.GetComponent<BarrelController>();
            m_BarrelScript.ChangeHP(Random.Range(40, 71) * m_CurrentDifficulty);
        }
    }
}
