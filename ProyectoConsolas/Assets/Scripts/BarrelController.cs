using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BarrelController : MonoBehaviour
{
    public int m_MaxHealthPoints;
    public int m_CurrentHealthPoints;
    public TextMeshPro m_Text;
    public bool m_IsUpgrade;
    public bool m_IsPowerUp;
    public bool m_IsExtraSoldier;
    private UpgradeBarrelScript m_UpgradeBarrelScript;
    private PowerUpBarrelScript m_PowerUpBarrelScript;
    private ExtraSoldierBarrel m_ExtraSoldierBarrelScript;
    private CanvasController m_CanvasController;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentHealthPoints = m_MaxHealthPoints;
        m_CanvasController = FindObjectOfType<CanvasController>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Text.text = m_CurrentHealthPoints.ToString();
        gameObject.transform.position += Vector3.left * 10 * Time.deltaTime;
        if (m_CurrentHealthPoints <= 0 )
        {
            if(m_IsUpgrade)
            {
                m_UpgradeBarrelScript = GetComponent<UpgradeBarrelScript>();
                m_UpgradeBarrelScript.UpgradeFireRate();
            }
            if(m_IsPowerUp)
            {
                m_PowerUpBarrelScript = GetComponent<PowerUpBarrelScript>();
                m_PowerUpBarrelScript.GetPowerUp();
            }
            if(m_IsExtraSoldier)
            {
                m_ExtraSoldierBarrelScript = GetComponent<ExtraSoldierBarrel>();
                m_ExtraSoldierBarrelScript.GetExtraSoldier();
            }
            Dead();
        }
    }

    private void Dead()
    {
        m_CanvasController.m_Score += 5;
        Destroy(gameObject);
    }

    public void ChangeHP(int health)
    {
        m_MaxHealthPoints = health;
        m_CurrentHealthPoints = health;
    }
}
