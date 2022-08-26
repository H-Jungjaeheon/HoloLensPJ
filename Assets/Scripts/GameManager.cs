using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private bool isGameStart;
    public bool IsGameStart
    {
        get { return isGameStart; }
        set 
        {
            if (value == true)
            {
                TitleManager.Instance.GameStart();
            }
            isGameStart = value;
        }
    }

    [SerializeField]
    private bool isDead;
    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }
    }

    [SerializeField]
    private int hp;
    public int Hp
    {
        get { return hp; }
        set
        {
            if (hp <= 0)
            {
                TitleManager.Instance.GameOver();
            }
            hp = value;
        }
    }
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
