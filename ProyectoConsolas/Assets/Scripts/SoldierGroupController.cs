using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SoldierGroupController : MonoBehaviour
{
    public GameObject m_SoldierPrefab;
    public List<GameObject> m_SoldiersList;
    private SoldierController m_SoldierScript;
    public Image m_PowerUpImagePC;
    public Image m_PowerUpImageAndroid;
    public int m_AuxNumSoldiers;
    public int m_NumSoliderRight;
    public int m_NumSoliderLeft;
    public int m_SpawnLine;
    public int m_FireRateUpgrade;
    public float aaaa;

    //PowerUp
    public bool m_HasPowerUp;
    public float m_PowerUpMaxTimer = 5f;
    public float m_PowerUpCurrentTimer;
    private bool m_DoingPowerUp = false;

    public Button m_MoveRightButton;
    public Button m_MoveLeftButton;
    private bool m_MovingRight;
    private bool m_MovingLeft;
    public bool m_RightLimit;
    public bool m_LeftLimit;

    public float velocidad = 1f;

    // Start is called before the first frame update
    void Start()
    {
        m_NumSoliderRight = 1;
        m_NumSoliderLeft = 1;
        m_AuxNumSoldiers = m_SoldiersList.Count;
        m_FireRateUpgrade = 0;
        m_PowerUpCurrentTimer = m_PowerUpMaxTimer;
#if UNITY_ANDROID
        m_MoveLeftButton.gameObject.SetActive(true);
        m_MoveRightButton.gameObject.SetActive(true);
#endif
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE_WIN
        /*
        if(Input.GetKeyDown(KeyCode.E))
        {
            CreateNewSoldier();
        }
        */
        if (Input.GetAxis("Horizontal") < 0)
        {
            gameObject.transform.position += Vector3.forward * 15 * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            gameObject.transform.position += Vector3.back * 15 * Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            PowerUpButtonPreshed();
        }

        m_PowerUpImagePC.gameObject.SetActive(m_HasPowerUp);
#endif
#if UNITY_ANDROID
        m_PowerUpImageAndroid.gameObject.SetActive(m_HasPowerUp);

        if(m_MovingLeft && !m_LeftLimit)
        {
            gameObject.transform.position += Vector3.forward * 20 * Time.deltaTime;
        }
        if(m_MovingRight && !m_RightLimit)
        {
            gameObject.transform.position += Vector3.back * 20 * Time.deltaTime;
        }
        
        //Move the soldier following the finger but doesnt work
        if(Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);
            if(toque.phase == TouchPhase.Moved) 
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - toque.deltaPosition.x * velocidad * Time.deltaTime);

            }
        }
        

#endif
        
        if (m_DoingPowerUp)
        {
            if(m_PowerUpCurrentTimer <=0)
            {
                m_PowerUpCurrentTimer = m_PowerUpMaxTimer;
                for (int j = 0; j < m_SoldiersList.Count; j++)
                {
                    m_SoldierScript = m_SoldiersList[j].GetComponent<SoldierController>();
                    m_SoldierScript.m_InPowerUp = false;
                }
                m_DoingPowerUp = false;
            }
            else
            {
                m_PowerUpCurrentTimer -= Time.deltaTime;
            }
        }else
        {
            if(Input.GetKeyDown(KeyCode.Q) && m_HasPowerUp)
            {
                PowerUpButtonPreshed();
            }
        }
        if(m_SoldiersList.Count == 0)
        {
            SceneManager.LoadScene("Menu");
        }
        
    }

    private void CreateNewSoldier()
    {
        if(m_AuxNumSoldiers == 0)
        {
            GameObject newSoldier = Instantiate(m_SoldierPrefab, this.transform);
            m_SoldiersList.Add(newSoldier);
            newSoldier.transform.position = new Vector3(newSoldier.transform.position.x - 2.5f * m_SpawnLine, this.transform.position.y + 0.5f, newSoldier.transform.position.z);
        }else
        {
            if (m_AuxNumSoldiers % 2 == 1)
            {
                GameObject newSoldier = Instantiate(m_SoldierPrefab, this.transform);
                m_SoldiersList.Add(newSoldier);
                newSoldier.transform.position = new Vector3(this.transform.position.x - 2.5f * m_SpawnLine, this.transform.position.y + 0.5f, this.transform.position.z - 1.5f * m_NumSoliderRight);
                m_NumSoliderRight++;
            }
            else
            {
                GameObject newSoldier = Instantiate(m_SoldierPrefab, this.transform);
                m_SoldiersList.Add(newSoldier);
                newSoldier.transform.position = new Vector3(this.transform.position.x - 2.5f * m_SpawnLine, this.transform.position.y + 0.5f, this.transform.position.z + 1.5f * m_NumSoliderLeft);
                m_NumSoliderLeft++;
            }
        }
        m_AuxNumSoldiers++;
        if(m_AuxNumSoldiers%7 == 0)
        {
            m_AuxNumSoldiers = 0;
            m_SpawnLine++;
            m_NumSoliderRight = 1;
            m_NumSoliderLeft = 1;
        }
    }

    public void FireRateUpgraded()
    {
        for(int i = 0;i<m_SoldiersList.Count;i++)
        {
            m_SoldierScript = m_SoldiersList[i].GetComponent<SoldierController>();
            m_SoldierScript.m_NumUpgrades++;
        }
    }

    public void PowerUp(bool HavePowerUp)
    {
        m_HasPowerUp = HavePowerUp;
    }

    public void AddSoldier (int NumSoldiers)
    {
        for(int i = 0;i<NumSoldiers;i++)
        {
            CreateNewSoldier();
        }
    }
    
    public void MoveRight()
    {
        m_MovingRight = true;
    }

    public void MoveLeft() 
    {
        m_MovingLeft = true;
    }

    public void DesactivateMove()
    {
        m_MovingLeft = false;
        m_MovingRight = false;
    }
    public void PowerUpButtonPreshed()
    {
        if(m_HasPowerUp)
        {
            m_HasPowerUp = false;
            m_DoingPowerUp = true;
            for (int j = 0; j < m_SoldiersList.Count; j++)
            {
                m_SoldierScript = m_SoldiersList[j].GetComponent<SoldierController>();
                m_SoldierScript.m_InPowerUp = true;
            }
        }
    }

    public void RemoveSoldier(GameObject soldierRemoved)
    {
        m_SoldiersList.Remove(soldierRemoved);
    }
}
