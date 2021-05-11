using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static AudioClip battleCry, collectCoins, fail, frozen, success, swordClash, towerCollapse, wizardSound;
    static AudioSource audioSrc;

    void Start ()
    {
        battleCry = Resources.Load<AudioClip>("BattleCry");
        collectCoins = Resources.Load<AudioClip>("CollectCoins");
        fail = Resources.Load<AudioClip>("FailSound");
        frozen = Resources.Load<AudioClip>("Frozen");
        success = Resources.Load<AudioClip>("SuccessSound");
        swordClash = Resources.Load<AudioClip>("SwordClash");
        towerCollapse = Resources.Load<AudioClip>("TowerCollapse");
        wizardSound = Resources.Load<AudioClip>("WizardSound");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySFX (string clip)
    {
        switch (clip)
        {
            case "BattleCry":
                audioSrc.PlayOneShot(battleCry);
                break;
            case "CollectCoins":
                audioSrc.PlayOneShot(collectCoins);
                break;
            case "FailSound":
                audioSrc.PlayOneShot(fail);
                break;
            case "Frozen":
                audioSrc.PlayOneShot(frozen);
                break;
            case "Success":
                audioSrc.PlayOneShot(success);
                break;
            case "SwordClash":
                audioSrc.PlayOneShot(swordClash);
                break;
            case "TowerCollapse":
                audioSrc.PlayOneShot(towerCollapse);
                break;
            case "WizardSound":
                audioSrc.PlayOneShot(wizardSound);
                break;
        }
    }
}
