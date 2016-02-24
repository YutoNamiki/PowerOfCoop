using UnityEngine;
using System.Collections;

public class Warrior : Character {

    public float RedCardEffectAttackRatio = 3.0f;
    public float BlueCardEffectDefenceRatio = 1.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected override void UseRedCard()
    {
        // 敵に通常攻撃する
        var attackPoint = PhysicalPower.Attack * attackRatio;
        var defencePoint = enemy.PhysicalPower.Defence * enemy.DefenceRatio;
        var attackResult = (PhysicalPower.Attack * attackRatio > enemy.PhysicalPower.Defence) ? 
            (PhysicalPower.Attack * attackRatio - enemy.PhysicalPower.Defence) : 0;
        enemy.HitPoint -= (int)attackResult;
        attackRatio = 1.0f;
        
        base.UseRedCard();
    }

    protected override void UseGreenCard()
    {
        // 次ターンの攻撃力を指定倍にする
        defenceRatio = 1.0f;
        attackRatio = RedCardEffectAttackRatio;
        base.UseGreenCard();
    }

    protected override void UseBlueCard()
    {
        defenceRatio = BlueCardEffectDefenceRatio;
        attackRatio = 1.0f;
        base.UseBlueCard();
    }

}
