using UnityEngine;
using System.Collections;
using Text=UnityEngine.UI.Text;

public class DigitalClock : MonoBehaviour {

	int s = 0;
	int m = 0;
	int h = 0;
	public Text TimeText;


	void Start(){
		h = 8;
		m = 30;
		StartCoroutine ("Time");
		TimeText = TimeText.GetComponent<Text> ();
	}

	void Update(){
		if(h >= 10 && m >= 10 && s < 10){
			TimeText.text = h.ToString() + ":" + m.ToString() + ":0" + s.ToString();
		}
		if(h >= 10 && m < 10 && s < 10){
			TimeText.text = h.ToString() + ":0" + m.ToString() + ":0" + s.ToString();
		}
		if(h < 10 && m < 10 && s < 10){
			TimeText.text = "0" + h.ToString() + ":0" + m.ToString() + ":0" + s.ToString();
		}
		if(h < 10 && m >= 10 && s < 10){
			TimeText.text = "0" + h.ToString() + ":" + m.ToString() + ":0" + s.ToString();
		}
		if(h < 10 && m >= 10 && s >= 10){
			TimeText.text = "0" + h.ToString() + ":" + m.ToString() + ":" + s.ToString();
		}
		if(h >= 10 && m < 10 && s >= 10){
			TimeText.text = h.ToString() + ":0" + m.ToString() + ":" + s.ToString();
		}
		if(h < 10 && m < 10 && s >= 10){
			TimeText.text = "0" + h.ToString() + ":0" + m.ToString() + ":" + s.ToString();
		}
		if(h >= 10 && m >= 10 && s >= 10){
			TimeText.text = h.ToString() + ":" + m.ToString() + ":" + s.ToString();
		}
	}

	IEnumerator Time(){
		while(h <= 24){
			yield return new WaitForSeconds (0.001f);
			s += 1;
			if(s == 60){
				s = 0;
				m += 1;
				if(m == 60){
					m = 0;
					h += 1;
					if(h == 24){
						h = 0;
					}
				}
			}
		}
	}
} 