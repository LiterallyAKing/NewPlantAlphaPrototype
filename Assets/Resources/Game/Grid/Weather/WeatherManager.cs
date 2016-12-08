using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WeatherManager : MonoBehaviour {

	public bool forceRain = false;


	public Text uiText;

	public GridManager gridman;
	public enum WeatherType {clear, cloudy, rain}
	public WeatherType currentWeather = WeatherType.clear;
	public WeatherType lastweather = WeatherType.clear;

	int weatherTimer = 5;

	public ParticleSystem raineffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeWeather(){
		if (weatherTimer <= 0) {
			WeatherUpdate ();
			weatherTimer = Random.Range (1,3)+Random.Range (3, 7);
		} else {
			weatherTimer--;
		}
	}

	void WeatherUpdate(){
		lastweather = currentWeather;
		float rand = Random.value;

		if (currentWeather == WeatherType.clear) {
			if (rand < 0.5f) {
				currentWeather = WeatherType.clear;
			} else if (rand < 0.55f) {
				currentWeather = WeatherType.cloudy;
			} else {
				currentWeather = WeatherType.rain;
			}
		} else if (currentWeather == WeatherType.cloudy) {
			if (rand < 0.3f) {
				currentWeather = WeatherType.clear;
			} else if (rand < 0.35f) {
				currentWeather = WeatherType.cloudy;
			} else {
				currentWeather = WeatherType.rain;
			}
		} else if (currentWeather == WeatherType.rain) {
			if (rand < 0.3f) {
				currentWeather = WeatherType.clear;
			} else if (rand < 0.35f) {
				currentWeather = WeatherType.cloudy;
			} else {
				currentWeather = WeatherType.rain;
			}
		}
		if (forceRain) {

			currentWeather = WeatherType.rain;
		}

		if(currentWeather != lastweather){

		for (int i = 0; i < gridman.cells.Length; i++) {
			GridStats stat = gridman.cells [i].GetComponent<GridStats> ();
				int newlight = 0, newwater = 0, newheat = 0;
				if (currentWeather == WeatherType.clear) {
					newlight = 0;
					newwater = 0;
					newheat = 0;
				} else if (currentWeather == WeatherType.cloudy) {
					newlight = -1;
					newwater = 0;
					newheat = 0;
				} else if (currentWeather == WeatherType.rain) {
					newlight = -1;
					newwater = 1;
					newheat = 0;
				}
				stat.baseLight = newlight;
				stat.baseWater = newwater;
				stat.baseHeat = newheat;
		}
			string desc = "";
			if (currentWeather == WeatherType.clear) {
				desc = "Clear";
			} else if (currentWeather == WeatherType.cloudy) {
				desc = "Cloudy";
			} else if (currentWeather == WeatherType.rain) {
				desc = "Rain";
			}
			uiText.text = desc;

			if (currentWeather == WeatherType.clear) {
				raineffect.Stop ();
			} else if (currentWeather == WeatherType.cloudy) {
				raineffect.Stop ();
			} else if (currentWeather == WeatherType.rain) {
				raineffect.Play ();
			}



		}


			
	}

}
