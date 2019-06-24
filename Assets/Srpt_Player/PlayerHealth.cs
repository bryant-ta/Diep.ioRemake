using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Damageable
{
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

    public new void DoDamage(int amt)
    {
        base.DoDamage(amt);
        hpBar.fillAmount = ((float)getHP() / (float)getMaxHP());
        hpTxt.text = getHP() + "/" + getMaxHP();
    }
}
