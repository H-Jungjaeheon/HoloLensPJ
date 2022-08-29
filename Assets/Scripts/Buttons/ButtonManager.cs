using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : Singleton<ButtonManager>
{
    [SerializeField]
    private GameObject gunSelectButtonObj;
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

    public void ButtonUpDownAnimCoroutine(bool isUpingAnim, float targetYPointInput)
    {
        StartCoroutine(ButtonUpDownAnim(isUpingAnim, targetYPointInput));
    }

    IEnumerator ButtonUpDownAnim(bool isUpingAnim, float targetYPointInput)
    {
        float targetYPoint = targetYPointInput;
        Vector3 moveSpeed = new Vector3(0, 3, 0);

        if (isUpingAnim)
        {
            gunSelectButtonObj.SetActive(isUpingAnim);
            while (gunSelectButtonObj.transform.position.y < targetYPoint)
            {
                gunSelectButtonObj.transform.position += moveSpeed * Time.deltaTime;
                yield return null;
            }
            gunSelectButtonObj.transform.position = new Vector3(gunSelectButtonObj.transform.position.x, targetYPoint, gunSelectButtonObj.transform.position.z);
        }
        else 
        {
            while (gunSelectButtonObj.transform.position.y > targetYPoint)
            {
                gunSelectButtonObj.transform.position -= moveSpeed * Time.deltaTime;
                yield return null;
            }
            gunSelectButtonObj.transform.position = new Vector3(gunSelectButtonObj.transform.position.x, targetYPoint, gunSelectButtonObj.transform.position.z);
            gunSelectButtonObj.SetActive(isUpingAnim);
        }
    }
}
