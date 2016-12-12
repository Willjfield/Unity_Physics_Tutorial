﻿using UnityEngine;
using System.Collections;

public class RulesManager : MonoBehaviour {
	public static string[] balls;
	private static int curBallNum;
	public static GameObject currentBall;

	public static Vector3[] ballPositions;
	public static bool[,] deadness;

	private UIManager UIManagerScript;

	// Use this for initialization
	void Awake () {
		curBallNum = 0;
		balls = new string[]{"BlueBall","RedBall","BlackBall","YellowBall"};
		currentBall = GameObject.Find (balls [curBallNum]);
		UIManagerScript = GameObject.Find ("UI").GetComponent<UIManager> ();
		//UIManagerScript.activateCurrentBall ();
		ballPositions = new Vector3[4];
		deadness = new bool[4,3];
		for(int i = 0;i<4;i++){
			//int index = i;
			for(int j = 0;j<3;j++){
				deadness[i,j] = false;
			}
		}
	}

	public static void updateBallPositions(){
		for (int b =0;b<4;b++) {
			Ball ball = GameObject.Find (balls[b]).GetComponent<Ball>();
			ballPositions [b] = ball.transform.position;
			Debug.Log (ballPositions[b]);
		}

	}

	private static int getBallIndex(string ball){
		int ballIndex = 4;
		switch (ball) {
		case "BlueBall":
			ballIndex = 0;
				break;
		case "RedBall":
			ballIndex = 1;
				break;
		case "BlackBall":
			ballIndex = 2;
				break;
		case "YellowBall":
			ballIndex = 3;
				break;
		}
		return ballIndex;
	}

	public static void updateDeadness(string ballPlayed, string ballCollided){
		int ballPlayedIndex = getBallIndex(ballPlayed);
		int ballCollidedIndex = getBallIndex(ballCollided);

		deadness [ballPlayedIndex, ballCollidedIndex] = true;
		Debug.Log (ballPlayedIndex+" dead on "+ballCollidedIndex);
		Debug.Log (deadness[ballPlayedIndex,ballCollidedIndex]);
		//Debug.Log (deadness[2,1]);
	}

	public static void nextBall(){
		curBallNum++;
		if (curBallNum > 3) {
			curBallNum = 0;		
		}
		//UIManagerScript.deactivatePreviousBall ();
		currentBall = GameObject.Find (balls [curBallNum]);
		currentBall.GetComponent<Ball> ().setStrokes (1);
		//UIManagerScript.activateCurrentBall ();
		//UIManager.
	}
	
	public static void lastBall(){
		//UIManagerScript.deactivatePreviousBall ();
		curBallNum--;
		if (curBallNum > 3) {
			curBallNum = 0;		
		}
		if (curBallNum < 0) {
			curBallNum = 3;		
		}
		//UIManagerScript.activateCurrentBall ();
//		currentBall = GameObject.Find (balls [curBallNum]);
//		currentBall.GetComponent<Ball> ().setStrokes (1);
	}

	public static void setBallsInHand(){
		foreach (string b in balls) {
			Ball ball = GameObject.Find (b).GetComponent<Ball>();
			ball.setBallInHand(true);
		}
	}

	public static string getCurBallName(){
		return balls[curBallNum];
	}

	public static string getLastBallName(){
		int lastBallIndex = curBallNum - 1;

		if (lastBallIndex > 3) {
			lastBallIndex = 0;		
		}

		if (lastBallIndex < 0) {
			lastBallIndex = 3;		
		}
		return balls[lastBallIndex];
	}
		
	// Update is called once per frame
	void Update () {
		//Debug.Log (getCurBallName ());
	}
}
