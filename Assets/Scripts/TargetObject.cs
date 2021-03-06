﻿using UnityEngine;
using System.Collections;

/*===============================================================*/
/**
* トリガー判定を取得するオブジェクトを制御するスクリプトコンポーネント	
* 2014年7月2日 Buravo
*/
public class TargetObject : MonoBehaviour {

	/*===============================================================*/
	/**
	* @brief 開始時に一度呼ばれるメソッド.
	* @param void.
	* @return void.
	*/
	void Start ()
	{
	
	}
	/*===============================================================*/

	/*===============================================================*/
	/**
	* @brief 常時処理.
	* @param void.
	* @return void.
	*/
	void Update ()
	{
	
	}
	/*===============================================================*/

	/*===============================================================*/
	/**
	* @brief オブジェクトにアタッチしたトリガーの中に別のオブジェクトが入ったときに呼び出される関数.
	* @param Collider2D 2Dゲームプレイで使用されるコライダー型の親クラス
	* @return void
	*/
	void OnTriggerEnter2D (Collider2D collider)
	{
    	if(collider.gameObject.tag == "PlayerObject"){
    		Debug.Log("Trigger Enter SUCESS !");
		}
	}
	/*===============================================================*/

	/*===============================================================*/
	/**
	* @brief トリガー状態のオブジェクトのコライダーと別のオブジェクトのコライダー衝突している最中に、毎フレーム呼び出され続ける関数.
	* @param Collider2D 2Dゲームプレイで使用されるコライダー型の親クラス
	* @return void
	*/
	void OnTriggerStay2D (Collider2D collider){
		if(collider.gameObject.tag == "PlayerObject"){
			Debug.Log("Trigger Stay SUCESS !");
		}
	}
	/*===============================================================*/

	/*===============================================================*/
	/**
	* @brief トリガー状態のオブジェクトのコライダーと別のオブジェクトのコライダーが衝突から離れた瞬間に、呼び出される関数.
	* @param Collider2D 2Dゲームプレイで使用されるコライダー型の親クラス
	* @return void
	*/
	void OnTriggerExit2D (Collider2D collider){
		if(collider.gameObject.tag == "PlayerObject"){
			Debug.Log("Trigger Exit SUCESS !");
		}
	}
	/*===============================================================*/
}
/*===============================================================*/