using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
    public List<GameObject> bulletPool = new List<GameObject>();
    private BulletScript ScriptBullet;
    public GameObject m_BulletPrefab;
    public int m_PoolSize;


    private void Awake()
    {
        for (int i = 0; i < m_PoolSize; i++)
        {
            GameObject bullet = Instantiate(m_BulletPrefab);
            bullet.SetActive(false);
            ScriptBullet = bullet.GetComponent<BulletScript>();
            bulletPool.Add(bullet);
        }
    }

    // Update is called once per frame
    public GameObject TakeShell()
    {
        foreach (GameObject bullet in bulletPool)
        {
            ScriptBullet = bullet.GetComponent<BulletScript>();
            if (!bullet.activeSelf)
            {
                return bullet;
            }
        }
        GameObject newBullet = Instantiate(m_BulletPrefab);
        newBullet.SetActive(false);
        ScriptBullet = newBullet.GetComponent<BulletScript>();
        bulletPool.Add(newBullet);
        return newBullet;
    }

    public void ReturnShell(GameObject shell)
    {
        shell.SetActive(false);
    }
}
