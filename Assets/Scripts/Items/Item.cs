﻿using UnityEngine;

public class Item: MonoBehaviour {

	private string _name;
	private int _value;
	private RarityTypes _rarity;
	private int _curDur;
	private int _maxDur;

	public Item () {
		_name = "Need a name";
		_value = 0;
		_rarity = RarityTypes.Common;
		_maxDur = 50;
		_curDur = _maxDur;
	}

	public Item(string name, int value, RarityTypes rarity, int maxDur, int curDur) {
		_name = name;
		_value = value;
		_rarity = rarity;
		_maxDur = maxDur;
		_curDur = _curDur;
	}

	public string Name {
		get { return _name; }
		set { _name = value; }
	}

	public int Value {
		get { return _value; }
		set { _value = value; }
	}

	public RarityTypes Rarity {
		get { return _rarity; }
		set { _rarity = value; }
	}

	public int MaxDurability {
		get { return _maxDur; }
		set { _maxDur = value; }
	}

	public int CurDurability {
		get { return _curDur; }
		set { _curDur = value; }
	}

}

public enum RarityTypes {
	Common,
	Uncommon,
	Rare
}

