using UnityEngine;
using System;
using System.Collections;

public class Character : MonoBehaviour {

    public enum Job
    {
        None,
        Warrior,
        Witch,
        Monk,
        Thief,
        Monster
    }

    [Serializable]
    public struct Power
    {
        public int Attack;
        public int Defence;
    }

    public int Level;
    public Job JobType;
    public int HitPoint;
    public Power PhysicalPower;
    public Power MasicPower;

    [SerializeField]
    protected Character player1;
    [SerializeField]
    protected Character player2;
    [SerializeField]
    protected Character player3;
    [SerializeField]
    protected Character enemy;
    [SerializeField]
    protected float attackRatio = 1.0f;
    [SerializeField]
    protected float defenceRatio = 1.0f;

    [SerializeField]
    CardEffect havingCard;
    [SerializeField]
    CardEffect drawCard;
    
    public float AttackRatio { get { return attackRatio; } }
    public float DefenceRatio { get { return defenceRatio; } }

    // Use this for initialization
    void Start () {
        player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Character>();
        if (player1 == null)
            throw new UnityException(this.name + ": Player1 is null.");
        player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Character>();
        if (player2 == null)
            throw new UnityException(this.name + ": Player2 is null.");
        player3 = GameObject.FindGameObjectWithTag("Player3").GetComponent<Character>();
        if (player3 == null)
            throw new UnityException(this.name + ": Player3 is null.");
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Character>();
        if (enemy == null)
            throw new UnityException(this.name + ": Enemy is null.");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UseCard(CardEffect.CardColor cardColor)
    {
        switch (cardColor)
        {
            case CardEffect.CardColor.Red:
                UseRedCard();
                break;
            case CardEffect.CardColor.Green:
                UseGreenCard();
                break;
            case CardEffect.CardColor.Blue:
                UseBlueCard();
                break;
        }
    }

    public void PhysicalAttackto(Character opponentCharacter)
    {
        // 相手を攻撃する
        var attackPoint = PhysicalPower.Attack * attackRatio;
        var defencePoint = opponentCharacter.PhysicalPower.Defence * opponentCharacter.defenceRatio;
        var attackResult = (attackPoint > defencePoint) ? (attackPoint - defencePoint) : 0;
        opponentCharacter.HitPoint -= (int)attackResult;
    }
    
    protected virtual void UseRedCard() { }
    protected virtual void UseGreenCard() { }
    protected virtual void UseBlueCard() { }

}

