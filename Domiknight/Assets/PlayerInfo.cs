using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{

    public bool isBox;
    public bool sado;
    public int maxHp;
    public int nowHp;

    private void Awake()
    {
        nowHp = maxHp;
    }
}
