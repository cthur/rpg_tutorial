﻿using UnityEngine;
using System.Collections;
using System;

public class GameSettings : MonoBehaviour {

	void Awake() {
		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SaveCharacterData() {
		GameObject pc = GameObject.Find ("PC");
		PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter> ();

//		PlayerPrefs.DeleteAll ();

		PlayerPrefs.SetString ("Player Name", pcClass.Name);

		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++) {
			PlayerPrefs.SetInt(((AttributeName)cnt).ToString() + " - Base Value", pcClass.GetPrimaryAttribute(cnt).BaseValue);
			PlayerPrefs.SetInt(((AttributeName)cnt).ToString() + " - Exp To Level", pcClass.GetPrimaryAttribute(cnt).ExpToLevel);

		}

		for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++) {
			PlayerPrefs.SetInt(((VitalName)cnt).ToString() + " - Base Value", pcClass.GetVital(cnt).CurValue);
			PlayerPrefs.SetInt(((VitalName)cnt).ToString() + " - Exp To Level", pcClass.GetVital(cnt).CurValue);
			PlayerPrefs.SetInt(((VitalName)cnt).ToString() + " - Current Value", pcClass.GetVital(cnt).CurValue);

			pcClass.GetVital(cnt).GetModifyingAttributesString();
		}
	}

	public void LoadCharacterData() {

	}

}
