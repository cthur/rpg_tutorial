/// <summary>
/// Attribute.cs
/// Sept 20, 2014
/// Corey Thur
/// 
/// This is the class for all of the character attributes in-game.
/// </summary>

using UnityEngine;                                  // Added to use for Debug.Log

public class Attribute : BaseStat {

	new public const int STARTING_EXP_COST = 50;   // This is the starting cost for all of the attributes

	private string _name;                          // This is the name of the attribute 

	/// <summary>
	/// Initializes a new instance of the <see cref="Attribute"/> class.
	/// </summary>
	public Attribute() {
		Debug.Log ("Attribute Created");

		_name = "";
		ExpToLevel = 50;
		LevelModifier = 1.05f;
	}

	/// <summary>
	/// 	Gets or sets the _name.
	/// </summary>
	/// <value>The _name.</value>
	public string Name {
		get { return _name; }
		set { _name = value; }
	}
}

/// <summary>
/// 	This is a list of all the attributes that will be in-game for the characters.
/// </summary>
public enum AttributeName {
	Might,               // Might = 0, 
	Constitution,        // Constitution = 1,
	Nimbleness,          // Nimbleness = 2,
	Speed,               // Speed = 3,
	Concentration,       // Concentration = 4,
	Willpower,           // Willpower = 5,
	Charisma             // Charisma = 6
}
