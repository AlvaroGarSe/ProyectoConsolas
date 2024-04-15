using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public GameObject Text;
    private TextMeshProUGUI m_ScoreText;
    public int m_Score;
    private int m_MaxTimer = 2;
    private float m_CurrentTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        m_CurrentTimer = m_MaxTimer;
        m_ScoreText = Text.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
       if(m_CurrentTimer <=0)
        {
            m_CurrentTimer = m_MaxTimer;
            m_Score++;
        }else
        {
            m_CurrentTimer -= Time.deltaTime;
        }
        m_ScoreText.text = m_Score.ToString();

    }
}
