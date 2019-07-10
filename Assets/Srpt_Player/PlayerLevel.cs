using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Chose exp amount to next level as (level)^1.5 
public class PlayerLevel : MonoBehaviour
{
    // Level and Exp
    [SerializeField] int level = 1;
    [ShowOnly] int exp = 0;

    int nextExp = 5;

    Image expBar;
    Text expTxt;
    Text lvlTxt;

    // Stat Upgrade
    int statUpPoints;
    int[] statUpCounts = { 0, 0, 0, 0, 0, 0 }; // In order
    public Image maxHPStatBar;
    public Image HPRegenStatBar;
    public Image BulletDmgStatBar;
    public Image BulletSpeedStatBar;
    public Image ReloadStatBar;
    public Image MovespeedStatBar;

    // Class Upgrade

    List<string> classUpVal = new List<string>();
    public Button[] classUpButtons;

    // Misc
    PlayerAttack pa;
    PlayerHealth ph;
    PlayerMovement pm;

    void Start()
    {
        expBar = GameObject.Find("ExpBar").GetComponent<Image>();
        expTxt = GameObject.Find("ExpTxt").GetComponent<Text>();
        lvlTxt = GameObject.Find("LvlTxt").GetComponent<Text>();
        pa = GetComponent<PlayerAttack>();
        ph = GetComponent<PlayerHealth>();
        pm = GetComponent<PlayerMovement>();

        expBar.fillAmount = exp / nextExp;
        expTxt.text = exp + "/" + nextExp;
        lvlTxt.text = ""+level;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            AddExp(100);
        }
    }

    public void AddExp(int newExp)
    {
        exp += newExp;
        if (exp >= nextExp) // level up!
        {
            exp = exp - nextExp;
            nextExp = nextExp + 7;
            level++;
            statUpPoints++;
            if (level == 2 || level == 3 || level == 4)
            {
                SetupUpgradeButtons();
            }
        }
        expBar.fillAmount = ((float)exp / (float)nextExp);
        expTxt.text = exp + "/" + nextExp;
        lvlTxt.text = "" + level;
    }

    public void AddAtt(int att)
    {
        if (statUpPoints == 0 || statUpCounts[att] >= 7) return;
        switch (att)
        {
            case 0:
                ph.AddMaxHP(20);
                statUpCounts[0]++;
                maxHPStatBar.fillAmount = statUpCounts[0] / 7f;
                ph.UpdateHP();
                break;
            case 1:
                ph.hpRegen += 1;
                statUpCounts[1]++;
                HPRegenStatBar.fillAmount = statUpCounts[1] / 7f;
                break;
            case 2:
                pa.priDmg += 2;
                statUpCounts[2]++;
                BulletDmgStatBar.fillAmount = statUpCounts[2] / 7f;
                break;
            case 3:
                pa.priPSpd += .9f;
                statUpCounts[3]++;
                BulletSpeedStatBar.fillAmount = statUpCounts[3] / 7f;
                break;
            case 4:
                pa.priCD -= .075f;
                statUpCounts[4]++;
                ReloadStatBar.fillAmount = statUpCounts[4] / 7f;
                break;
            case 5:
                pm.moveSpeed += 0.5f;
                statUpCounts[5]++;
                MovespeedStatBar.fillAmount = statUpCounts[5] / 7f;
                break;
            default:
                break;
        }
        statUpPoints--;
    }

    public void ChangeTank(int buttonNum)
    {
        pa.Equip((GameObject)Resources.Load("Pf_Player/" + classUpVal[buttonNum]));
        foreach (Button b in classUpButtons)
        {
            b.gameObject.SetActive(false);
        }
    }

    void SetupUpgradeButtons()
    {
        foreach (Button b in classUpButtons)
        {
            b.gameObject.SetActive(false);
        }
        GetClassUpgrades(pa.tank.name);
        for (int i = 0; i < classUpVal.Count; i++)
        {
            print(2);
            classUpButtons[i].gameObject.SetActive(true);
            classUpButtons[i].GetComponentInChildren<Text>().text = classUpVal[i];
        }
    }

    // Huge
    public void GetClassUpgrades(string curTank)
    {
        classUpVal.Clear();
        switch (curTank)
        {
            case "Tank(Clone)":
                classUpVal = new List<string> { "Twin", "Machine Gun", "Sniper", "Flank Guard" };
                break;
            case "Twin(Clone)":
                classUpVal = new List<string> { "Triple Shot", "Quad Tank", "Twin Flank" };
                break;
            case "Sniper(Clone)":
                classUpVal = new List<string> { "Assassin", "Overseer", "Hunter", "Trapper" };
                break;
            case "Machine Gun(Clone)":
                classUpVal = new List<string> { "Destroyer", "Gunner" };
                break;
            case "Flank Guard(Clone)":
                classUpVal = new List<string> { "Tri-Angle", "Quad Tank", "Twin Flank", "Auto 3" };
                break;
            case "Twin Flank(Clone)":
                classUpVal = new List<string> { "Triple Twin", "Battleship" };
                break;
            case "Quad Tank(Clone)":
                classUpVal = new List<string> { "Octo Tank", "Auto 5" };
                break;
            case "Triple Shot(Clone)":
                classUpVal = new List<string> { "Triplet", "Penta Shot", "Spread Shot" };
                break;
            case "Overseer(Clone)":
                classUpVal = new List<string> { "Overlord", "Manager", "Overtrapper", "Battleship" };
                break;
            case "Assassin(Clone)":
                classUpVal = new List<string> { "Ranger", "Stalker" };
                break;
            case "Tri-Angle(Clone)":
                classUpVal = new List<string> { "Booster", "Fighter" };
                break;
            case "Destroyer(Clone)":
                classUpVal = new List<string> { "Hybrid", "Annihilator", "Skimmer", "Rocketeer" };
                break;
            case "Hunter(Clone)":
                classUpVal = new List<string> { "Predator", "Streamliner" };
                break;
            case "Trapper(Clone)":
                classUpVal = new List<string> { "Tri-Trapper", "Gunner Trapper", "Overtrapper", "Mega Trapper", "Auto Trapper" };
                break;
            case "Smasher(Clone)":
                classUpVal = new List<string> { "Landmine", "Auto Smasher", "Spike" };
                break;
            case "Gunner(Clone)":
                classUpVal = new List<string> { "Auto Gunner", "Gunner Trapper", "Streamliner" };
                break;
            case "Auto 3(Clone)":
                classUpVal = new List<string> { "Auto 5", "Auto Gunner" };
                break;
            default:
                break;
        }
        if (level == 30 && curTank == "Machine Gun(Clone)")
        {
            classUpVal.Add("Sprayer");
        } else if (level == 20 && curTank == "Tank(Clone)")
        {
            classUpVal.Add("Smasher");
        }
    }

    public int getExp() { return exp; }
    public int getNextExp() { return nextExp; }
}