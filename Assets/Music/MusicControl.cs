using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicControl : MonoBehaviour {

	public AudioClip Achilles;
	public AudioClip AscendingTheVale;
	public AudioClip BlackVortex;
	public AudioClip ClashDefiant;
	public AudioClip RiverOfIo;
	public AudioClip FinalBattleOfTheDarkWizards;
	public AudioClip FiveArmies;
    AudioSource audio;
    int r =0;
    //public List<bool> PlayedMusic = new List<bool>();
	bool a = false;
	bool b = false;
	bool c = false;
	bool d = false;
	bool e = false;
	bool f = false;
	bool g = false;
    
    void Start() {
    	audio = GetComponent<AudioSource>();
    	r = Random.Range(0,6);
    }
    
    void Update (){
		if (!audio.isPlaying) {
			/*
			if(PlayedMusic.Count == 5){
				PlayedMusic.Clear();
			}
			if (r == 0 && !PlayedMusic.Contains(a)) {
				audio.clip = Achilles;
            	audio.Play();
            	PlayedMusic.Add(a);
			}
			if (r == 1 && !PlayedMusic.Contains(b)) {
				audio.clip = AscendingTheVale;
            	audio.Play();
				PlayedMusic.Add(b);
			}
			if (r == 2 && !PlayedMusic.Contains(c)) {
				audio.clip = BlackVortex;
            	audio.Play();
				PlayedMusic.Add(c);
			}
			if (r == 3 && !PlayedMusic.Contains(d)) {
				audio.clip = ClashDefiant;
            	audio.Play();
				PlayedMusic.Add(d);
			}
			if (r == 4 && !PlayedMusic.Contains(e)) {
				audio.clip = RiverOfIo;
            	audio.Play();
				PlayedMusic.Add(e);
			}*/
			if(a == true && b == true && c == true && d == true && e == true){
				a = false;
				b = false;
				c = false;
				d = false;
				e = false;
				f = false;
				g = false;
			}
			if (r == 0 && a == false) {
				audio.clip = Achilles;
            	audio.Play();
				a = true;
			}
			if (r == 1 && b == false) {
				audio.clip = AscendingTheVale;
            	audio.Play();
				b = true;
			}
			if (r == 2 && c == false) {
				audio.clip = BlackVortex;
            	audio.Play();
				c = true;
			}
			if (r == 3 && d == false) {
				audio.clip = ClashDefiant;
            	audio.Play();
				d = true;
			}
			if (r == 4 && e == false) {
				audio.clip = RiverOfIo;
            	audio.Play();
				e = true;
			}
			if (r == 5 && f == false) {
				audio.clip = FinalBattleOfTheDarkWizards;
            	audio.Play();
				f = true;
			}
			if (r == 6 && g == false) {
				audio.clip = FiveArmies;
            	audio.Play();
				g = true;
			}
			r = Random.Range(0,6);
        }
		if (Input.GetKeyDown ("m")) {
			audio.Play();
		}
    }
}
