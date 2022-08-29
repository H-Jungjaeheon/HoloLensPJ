using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum GameState
{
    Main,
    GunChoose,
    Playing,
    GameOver,
    GameClear
}

public enum GunState
{
    MachineGun,
    SniperRifle,
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

    [SerializeField]
    private GameObject[] gunObject;

    public Action<GunState> gunSelect;

    [HideInInspector]
    public GameState nowGameState;
    private GunState nowGunState;

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
        gunSelect = (GunState) => { SelectGun(GunState); };
    }

    public void ChangeGameState(GameState changeGameState)
    {
        switch (changeGameState)
        {
            case GameState.Main:
                nowGameState = GameState.Main;
                break;
            case GameState.GunChoose:
                ButtonManager.Instance.ButtonUpDownAnimCoroutine(true, -2f);
                nowGameState = GameState.GunChoose;
                break;
            case GameState.Playing:
                ButtonManager.Instance.ButtonUpDownAnimCoroutine(false, -5f);
                nowGameState = GameState.Playing;
                break;
            case GameState.GameOver:
                nowGameState = GameState.GameOver;
                break;
            case GameState.GameClear:
                nowGameState = GameState.GameClear;
                break;
        }
    }

    private void SelectGun(GunState chooseGun)
    {
        nowGunState = chooseGun;
        gunObject[(int)chooseGun].SetActive(true);
    }
}
