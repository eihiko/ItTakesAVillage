using UnityEngine;
using System.Collections;

public class OverviewObjectController {

	public OverviewObject activeObject = null;
	// Use this for initialization

	public void ActivateObject(OverviewObject obj) {
		if (activeObject != null)
			activeObject.setDeselected ();

		activeObject = obj;
		activeObject.setSelected ();
	}

	public void DeactivateObject(OverviewObject obj) {
		activeObject.setDeselected ();
		activeObject = null;
	}
}
