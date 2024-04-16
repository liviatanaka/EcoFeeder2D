using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corn : MonoBehaviour, IWeapon
{
    public void Attack(){
        ActiveWeapon.Instance.ToggleIsAttacking(false);
    }
}
