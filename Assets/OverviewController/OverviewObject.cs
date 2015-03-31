using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OverviewObject : MonoBehaviour {

	public bool isSelected = false;
	public Material ObjectOverviewMat;
	public ObjectInfoObject ObjectInfoCanvas;

	float COLOR_DIFF = 0.5F;
	Color specColor, selected, deselected;
	OverviewObjectController OOC = new OverviewObjectController();


	void Start () {
		specColor = this.renderer.material.GetColor ("_SpecColor");
		selected = new Color (specColor.a - COLOR_DIFF, specColor.g - COLOR_DIFF, specColor.b - COLOR_DIFF);
		deselected = new Color (specColor.a + COLOR_DIFF, specColor.g + COLOR_DIFF, specColor.b + COLOR_DIFF);
		ObjectInfoCanvas.gameObject.SetActive (false);
	}

	void OnMouseDown() {
		Debug.Log ("mouse clicked on object");
		if (isSelected == false) {
			Activation (true);
		} else {
			Activation (false);
		}
	}

	public void Activation (bool val) {
		if (val) {
			OOC.ActivateObject (this);
		} else {
			OOC.DeactivateObject (this);
		}
	}

	public void setSelected() {
		isSelected = true;
		this.renderer.material.SetColor("_SpecColor", selected);
		// set the object info name as the name of the object
		//ex: if the object is a house the name will be set to House
		ObjectInfoCanvas.gameObject.SetActive (true);
	}

	public void setDeselected() {
		isSelected = false;
		this.renderer.material.SetColor ("_SpecColor", deselected);
		ObjectInfoCanvas.gameObject.SetActive (false);
	}

	void update(){
		if (isSelected) {
			setSelected ();
		} else {
			setDeselected (); 
		}
	}

}
