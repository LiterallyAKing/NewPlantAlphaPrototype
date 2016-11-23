using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderText : MonoBehaviour {

	public Text text;
	public Slider slider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int temp = Mathf.RoundToInt(slider.value * 10f);
		float val = (float)temp / 10f;
		text.text = val.ToString();
	}
}
