using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SeclectGun(string chooseGun)
    {
        if (GameManager.Instance.nowGameState != GameState.GunChoose) return;
        switch (chooseGun)
        {
            case "MachineGun":
                print("실행");
                GameManager.Instance.gunSelect(GunState.MachineGun);
                break;
            case "SniperRifle":
                print("실행");
                GameManager.Instance.gunSelect(GunState.SniperRifle);
                break;
            case "RocketLauncher":
                print("실행");
                GameManager.Instance.gunSelect(GunState.RocketLauncher);
                break;
        }
        GameManager.Instance.ChangeGameState(GameState.Playing);
    }
}
