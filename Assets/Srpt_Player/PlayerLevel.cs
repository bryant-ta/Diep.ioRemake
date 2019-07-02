using UnityEngine;
using UnityEngine.UI;

// Chose exp amount to next level as (level)^1.5 
public class PlayerLevel : MonoBehaviour
{
    [SerializeField] int level = 1;
    [ShowOnly] int exp = 0;

    int nextExp = 10;

    Image expBar;
    Text expTxt;

    void Awake()
    {
        expBar = GameObject.Find("ExpBar").GetComponent<Image>();
        expTxt = GameObject.Find("ExpTxt").GetComponent<Text>();

        expBar.fillAmount = exp / nextExp;
        expTxt.text = exp + "/" + nextExp;
    }

    public void AddExp(int newExp)
    {
        exp += newExp;
        if (exp >= nextExp)
        {
            exp = exp - nextExp;
            nextExp = Mathf.FloorToInt(Mathf.Pow(level, 1.5f));
            level++;
        }
        expBar.fillAmount = ((float)exp / (float)nextExp);
        expTxt.text = exp + "/" + nextExp;
    }






    public int getExp() { return exp; }
    public int getNextExp() { return nextExp; }
}