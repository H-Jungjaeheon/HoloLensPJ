using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum GameState
{
    Main,
    Playing,
    GameOver,
    GameClear
}

public enum GunState
{
    MachineGun,
    ShotGun,
    RocketLauncher
}

public class GameManager : Singleton<GameManager>
{
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

    public GameObject PlayerObj;

    [SerializeField]
    private GameObject[] gunObject;

    public Action<GunState> gunSelect;

    [HideInInspector]
    public GameState nowGameState;
    [HideInInspector]
    public GunState nowGunState;
    [HideInInspector]
    public bool isGunChangeAble;

    public List<GameObject> enemyList = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        StartSetting();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartSetting()
    {
        nowGameState = GameState.Main;
        gunSelect = (GunState) => { ChangeGun(GunState); };
        isGunChangeAble = true;
    }

    public void ChangeGameState(GameState changeGameState)
    {
        switch (changeGameState)
        {
            case GameState.Main:
                nowGameState = GameState.Main;
                TitleManager.Instance.TitleObj.SetActive(true);
                break;
            case GameState.Playing:
                nowGameState = GameState.Playing;
                ChangeGun(GunState.MachineGun);
                break;
            case GameState.GameOver: //게임 오버 캔버스 창 띄우기
                nowGameState = GameState.GameOver;
                break;
            case GameState.GameClear: //게임 클리어 캔버스 창 띄우기
                nowGameState = GameState.GameClear;
                break;
        }
    }

    public void ChangeGun(GunState chooseGun)
    {
        gunObject[(int)nowGunState].SetActive(false);
        nowGunState = chooseGun;
        gunObject[(int)chooseGun].SetActive(true);
    }
    public void GunChangeCoolTimeCoroutine()
    {
        StartCoroutine(GunChangeCoolTime());
    }

    IEnumerator GunChangeCoolTime()
    {
        float nowCoolTime = 0;
        isGunChangeAble = false;
        while (nowCoolTime < 10)
        {
            nowCoolTime += Time.deltaTime;
            yield return null;
        }
        isGunChangeAble = true;
    }
}
