using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShipAI : MonoBehaviour {
	private List<IDrive> leftDrives;
	private List<IDrive> rightDrives;
	private List<IDrive> forwardDrives;
	public List<GameObject> leftDriveObjects;
	public List<GameObject> rightDriveObjects;
	public List<GameObject> forwardDriveObjects;

	void Start () {
		leftDrives = Helper.InitializeComponent<IDrive>(leftDriveObjects);
		forwardDrives = Helper.InitializeComponent<IDrive>(forwardDriveObjects);
		rightDrives = Helper.InitializeComponent<IDrive>(rightDriveObjects);
	}
	void Update() {
		float angleToFace = 30;
	}
}
