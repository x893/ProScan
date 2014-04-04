using System;

[Serializable]
public class VehicleProfile
{
	public string Name;
	public bool AutoTransmission;
	public float FirstGearRatio;
	public float SecondGearRatio;
	public float ThirdGearRatio;
	public float FourthGearRatio;
	public float FifthGearRatio;
	public float SixthGearRatio;
	public float DynoDriveRatio;
	public float AxleGearRatio;
	public float Weight;
	public float DragCoefficient;
	public int ElmTimeout;
	public float SpeedCalibrationFactor;
	public WheelStruc Wheel;
	public string Notes;

	public VehicleProfile()
	{
		Name = "New Vehicle";
		AutoTransmission = false;
		FirstGearRatio = 2.66f;
		SecondGearRatio = 1.78f;
		ThirdGearRatio = 1.3f;
		FourthGearRatio = 1f;
		FifthGearRatio = 0.74f;
		SixthGearRatio = 0.5f;
		AxleGearRatio = 3.73f;
		DynoDriveRatio = 0.022f;
		SpeedCalibrationFactor = 1f;
		Weight = 3500f;
		DragCoefficient = 0.13f;
		Wheel = new WheelStruc();
		Wheel.Width = 255;
		Wheel.AspectRatio = 40;
		Wheel.RimDiameter = 16;
		ElmTimeout = 200;
		Notes = "";
	}

	public override string ToString()
	{
		return Name;
	}


	public bool Equals(VehicleProfile p)
	{
		return (
			Name.Equals(p.Name) &&
			AutoTransmission == p.AutoTransmission &&
			Weight == p.Weight &&
			DynoDriveRatio == p.DynoDriveRatio &&
			DragCoefficient == p.DragCoefficient &&
			Wheel.Width == p.Wheel.Width &&
			Wheel.AspectRatio == p.Wheel.AspectRatio &&
			Wheel.RimDiameter == p.Wheel.RimDiameter &&
			ElmTimeout == p.ElmTimeout && Notes.Equals(p.Notes)
			);
	}
}
