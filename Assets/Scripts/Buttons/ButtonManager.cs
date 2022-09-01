using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : Singleton<ButtonManager>
{
    [SerializeField]
    private GameObject gunSelectButtonObj;
    
    public void SeclectGun(string chooseGun)
    {
        switch (chooseGun)
        {
            case "MachineGun":
                print("����");
                GameManager.Instance.gunSelect(GunState.MachineGun);
                break;
            case "SniperRifle":
                print("����");
                GameManager.Instance.gunSelect(GunState.SniperRifle);
                break;
            case "RocketLauncher":
                print("����");
                GameManager.Instance.gunSelect(GunState.RocketLauncher);
                break;
        }
        GameManager.Instance.ChangeGameState(GameState.Playing);
    }
}
