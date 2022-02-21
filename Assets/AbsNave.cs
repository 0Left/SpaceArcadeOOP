using System.Collections;
using System.Collections.Generic;

abstract class AbsNave
{
    protected int vidaBase;
    protected float speedBase;
    //Depois de começar a implementar a classe de armas, expandir para adicionar
    //public Weapon BaseWeapon();
    //public abstract void ChangeWeapon();
    protected float dmgMultiplyBase;

    public abstract void Move();
    public abstract void Shoot();
    public abstract void TakeDmg();
    public abstract void Die();


}
