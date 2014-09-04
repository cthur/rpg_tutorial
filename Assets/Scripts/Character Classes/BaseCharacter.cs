using UnityEngine;
using System.Collections;
using System;					// added to access the enum class

public class BaseCharacter : MonoBehaviour {

	private string _name;
	private int _level;
	private uint _freeExp;

	private Attribute[] _primaryAttribute;
	private Vital[] _vital;
	private Skill[] _skill;

	public void Awake() {
		_name = string.Empty;
		_level = 0;
		_freeExp = 0;

		_primaryAttribute = new Attribute[Enum.GetValues (typeof(AttributeName)).Length];
		_vital = new Vital[Enum.GetValues (typeof(VitalName)).Length];
		_skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];

		SetupPrimaryAttributes ();
		SetupVitals ();
		SetupSkills ();
	}

	public string Name {
		get{ return _name; }
		set{ _name = value; }
	}

	public int Level {
		get{ return _level; }
		set{ _level = value; }
	}

	public uint FreeExp {
		get{ return _freeExp; }
		set{ _freeExp = value; }
	}

	public void AddExp(uint exp){
		_freeExp += exp;

		CalculateLevel ();
	}

	// take average of all player skills and assign that as the player level
	public void CalculateLevel() {

	}

	private void SetupPrimaryAttributes() {
		for (int cnt = 0; cnt < _primaryAttribute.Length; cnt++) {
			_primaryAttribute[cnt] = new Attribute();
			_primaryAttribute[cnt].Name = ((AttributeName)cnt).ToString();
		}
	}

	private void SetupVitals() {
		for (int cnt = 0; cnt < _vital.Length; cnt++) {
			_vital[cnt] = new Vital();
		}

		SetupVitalModifiers ();
	}

	private void SetupSkills() {
		for (int cnt = 0; cnt < _skill.Length; cnt++) {
			_skill[cnt] = new Skill();
		}

		SetupSkillModifiers ();
	}

	public Attribute GetPrimaryAttribute(int index) {
		return _primaryAttribute [index];
	}

	public Vital GetVital(int index) {
		return _vital [index];
	}

	public Skill GetSkill(int index) {
		return _skill [index];
	}

	private void SetupVitalModifiers() {
		//health
		GetVital ((int)VitalName.Health).AddModifier (new ModifyingAttribute{attribute = GetPrimaryAttribute((int)AttributeName.Constitution), ratio = .5f});

		//energy
		GetVital ((int)VitalName.Energy).AddModifier (new ModifyingAttribute{attribute = GetPrimaryAttribute((int)AttributeName.Constitution), ratio = 1});

		//mana
		GetVital ((int)VitalName.Mana).AddModifier (new ModifyingAttribute{attribute = GetPrimaryAttribute((int)AttributeName.Willpower), ratio = 1});
	}

	private void SetupSkillModifiers() {
		//melee offense
		GetSkill ((int)SkillName.Melee_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Might), .33f));
		GetSkill ((int)SkillName.Melee_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Nimbleness), .33f));

		//melee defense
		GetSkill ((int)SkillName.Melee_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
		GetSkill ((int)SkillName.Melee_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution), .33f));

		//magic offense
		GetSkill ((int)SkillName.Magic_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), .33f));
		GetSkill ((int)SkillName.Magic_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), .33f));

		//magic defense
		GetSkill ((int)SkillName.Magic_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), .33f));
		GetSkill ((int)SkillName.Magic_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), .33f));

		//ranged offense
		GetSkill ((int)SkillName.Ranged_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), .33f));
		GetSkill ((int)SkillName.Ranged_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));

		//ranged defense
		GetSkill ((int)SkillName.Ranged_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
		GetSkill ((int)SkillName.Ranged_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Nimbleness), .33f));
	}

	public void StatUpdate() {
		for (int cnt = 0; cnt < _vital.Length; cnt++) {
			_vital[cnt].Update();
		}

		for (int cnt = 0; cnt < _skill.Length; cnt++) {
			_skill[cnt].Update();
		}
	}

}
