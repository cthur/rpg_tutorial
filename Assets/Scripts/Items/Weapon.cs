﻿public class Weapon : BuffItem {

	private int _maxDamage;
	private float _dmgVar;
	private float _maxRange;
	private DamageType _dmgType;

	public Weapon () {
		_maxDamage = 0;
		_dmgVar = 0;
		_maxRange = 0;
		_dmgType = DamageType.Bludgeon;
	}

	public Weapon(int mDmg, float dmgVar, float mRange, DamageType dt) {
		_maxDamage = mDmg;
		_dmgVar = dmgVar;
		_maxRange = mRange;
		_dmgType = dt;
	}

	public int MaxDamage {
		get { return _maxDamage; }
		set { _maxDamage = value; }
	}

	public float DamageVariance {
		get { return _dmgVar; }
		set { _dmgVar = value; }
	}

	public float MaxRange {
		get { return _maxRange; }
		set { _maxRange = value; }
	}

	public DamageType TypeOfDamage {
		get { return _dmgType; }
		set { _dmgType = value; }
	}

}

public enum DamageType {
	Bludgeon,
	Pierce,
	Slash,
	Fire,
	Ice,
	Lightning,
	Acid
}