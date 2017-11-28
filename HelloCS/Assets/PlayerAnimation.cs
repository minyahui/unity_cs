using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//		PlayState ("soldierFalling");
		if (Input.GetKeyDown (KeyCode.W) ||Input.GetKeyDown (KeyCode.UpArrow)) {
			PlayState ("soldierWalk");
		}  
		else  if (Input.GetKeyDown (KeyCode.D) ||Input.GetKeyDown (KeyCode.RightArrow)) {//
			PlayState ("soldierStrafeRight");
		}
		if (Input.GetKeyDown (KeyCode.A) ||Input.GetKeyDown (KeyCode.LeftArrow)) {
			PlayState ("soldierStrafeLeft");
		}
		if (Input.GetKeyDown (KeyCode.S) ||Input.GetKeyDown (KeyCode.DownArrow)) {
			PlayState ("soldierWalk");
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			PlayState ("soldierFalling");
		} 
		if (Input.GetKeyUp (KeyCode.W)||Input.GetKeyUp (KeyCode.UpArrow)||Input.GetKeyUp (KeyCode.D)
			||Input.GetKeyUp (KeyCode.RightArrow)||Input.GetKeyUp (KeyCode.A)||Input.GetKeyUp (KeyCode.LeftArrow)
			||Input.GetKeyUp (KeyCode.S)||Input.GetKeyUp (KeyCode.DownArrow)||Input.GetKeyUp (KeyCode.Space)) {
			PlayState ("soldierIdle");
		}
	}
	void PlayState(string animName){
		GetComponent<Animation>().CrossFade (animName, 0.2f);//会有0.2秒的缓冲时间，在这0.2秒内，会由当前动画渐变到aniName动画
//		GetComponent<Animation> ().Play (animName);//不管当前正在播放什么样的动画，全部终止，播放animName动画
	}
}
