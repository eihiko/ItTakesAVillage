using UnityEngine;
using System.Collections;

public class TogglePanel : MonoBehaviour {

	public void Toggle(){
		this.gameObject.SetActive(!this.gameObject.activeSelf);
	}

}
