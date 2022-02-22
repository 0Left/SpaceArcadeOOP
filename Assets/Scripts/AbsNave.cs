using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsNave : MonoBehaviour
{
    protected int vidaBase;
    protected float speedBase;
    [HideInInspector]
    public float speedMultiplyed;
    //Depois de começar a implementar a classe de armas, expandir para adicionar
    //public Weapon BaseWeapon();
    //public abstract void ChangeWeapon();
    protected float dmgMultiplyBase;

    //Move não se mostrou muito util de manter como metódo de todos, pois acredito que o fixedUpdate vá suprir
    //public abstract void Move();
    public abstract void Shoot();
    public abstract void TakeDmg();
    public abstract void Die();
    // Start is called before the first frame update

}
