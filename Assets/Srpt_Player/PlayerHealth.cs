using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Damageable
{
    public float hpRegen;

    Image hpBar;
    Text hpTxt;

    private void Start()
    {
        Setup(getMaxHP());
        hpBar = GameObject.Find("HPBar").GetComponent<Image>();
        hpTxt = GameObject.Find("HPTxt").GetComponent<Text>();

        hpBar.fillAmount = getHP() / getMaxHP();
        hpTxt.text = getHP() + "/" + getMaxHP();
    }

    //float startRegen;
    private void Update()
    {
        // HP Regen
        int regenAmt = (int)(getMaxHP() * (hpRegen / 100));
        AddHP(regenAmt);
    }

    public new int DoDamage(int amt)
    {
        int ret = base.DoDamage(amt);
        hpBar.fillAmount = ((float)getHP() / (float)getMaxHP());
        hpTxt.text = getHP() + "/" + getMaxHP();
        return ret;
    }
}
