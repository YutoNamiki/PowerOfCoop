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

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
