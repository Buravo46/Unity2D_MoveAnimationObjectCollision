using UnityEngine;
using System.Collections;

/*===============================================================*/
/**
* アニメーションをさせるオブジェクトを制御するスクリプトコンポーネント	
* 2014年7月2日 Buravo
*/
public class AnimationObject : MonoBehaviour {

	#region メンバ変数
	/*===============================================================*/
	/**
	* @brief スクリプト内で生成したアニメーションクリップを使って移動するフラグ
	*/
	public bool m_use_script_animation = false;
	/**
	* @brief エディタ上で生成したアニメーションクリップを使って移動するフラグ
	*/
	public bool m_use_edit_animation = false;
	/**
	* @brief エディタ上で生成したアニメーションクリップ
	*/
	public AnimationClip m_edit_animation;
	/**
	* @brief エディタ上で生成したアニメーションクリップで制御する速度
	*/
	public Vector3 m_speed = Vector3.zero;
	/*===============================================================*/
	#endregion

	#region ローカル変数
	/*===============================================================*/
	/**
	* @brief 目標座標位置
	*/
	private Vector3 _nextVec3;
	/*===============================================================*/
	#endregion

	/*===============================================================*/
	/**
	* @brief 開始時に一度呼ばれるメソッド.
	* @param void.
	* @return void.
	*/
	void Start ()
	{
		// もしもスクリプト内で生成したアニメーションクリップを使って移動するならば
		if(m_use_script_animation){
			// 目標座標位置を設定する
			_nextVec3 = new Vector3(transform.position.x - 3, transform.position.y, transform.position.z);
			// アニメーション開始
			StartMoveAnimation(transform.position, _nextVec3, 0, 60);
		} else if(m_use_edit_animation){ // もしもエディタ上で生成したアニメーションクリップを使って移動するならば
			// アニメーションクリップ名の設定		
			m_edit_animation.name = "speedControlAnimation";
			// アニメーションコンポーネントにクリップを追加
			animation.AddClip(m_edit_animation, m_edit_animation.name);
			// アニメーション開始
			animation.Play(m_edit_animation.name);
		}
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
		// もしもエディタ上で生成したアニメーションクリップを使って移動するならば
		if(m_use_edit_animation){
			transform.position += m_speed;
		}
	}
	/*===============================================================*/

	/*===============================================================*/
	/**
	* @brief オブジェクトのコライダーが別のコライダーに衝突したときに呼び出される関数.
	* @param Collision2D 2D物理挙動で衝突により返される情報
	* @return void
	*/
	void OnCollisionEnter2D (Collision2D coll)
	{
		if(coll.gameObject.tag == "Target"){
			Debug.Log("Collision Enter SUCESS !");
		}
	}
	/*===============================================================*/

	/*===============================================================*/
	/**
	* @brief オブジェクトのコライダーと別のオブジェクトのコライダーが衝突している最中に毎フレーム呼び出され続ける関数.
	* @param Collision2D 2D物理挙動で衝突により返される情報
	* @return void
	*/
	void OnCollisionStay2D (Collision2D coll)
	{
		if(coll.gameObject.tag == "Target"){
			Debug.Log("Collision Stay SUCESS !");
		}
	}
	/*===============================================================*/

	/*===============================================================*/
	/**
	* @brief オブジェクトのコライダーと別のオブジェクトコライダーが衝突から離れた瞬間に呼び出される関数.
	* @param Collision2D 2D物理挙動で衝突により返される情報
	* @return void
	*/
	void OnCollisionExit2D (Collision2D coll)
	{
		if(coll.gameObject.tag == "Target"){
			Debug.Log("Collision Exit SUCESS !");
		}
	}
	/*===============================================================*/

	/*===============================================================*/
	/**
	* @brief 移動のアニメーションクリップを生成し開始する関数.
	* @param Vector3 始点位置
	* @param Vector3 終点位置
	* @param float 始点フレーム数
	* @param float 終点フレーム数
	* @return void
	*/
	void StartMoveAnimation (Vector3 startPosition, Vector3 endPosition, float startFrame, float endFrame)
	{
		// AnimationCurve : キーフレームを追加し、所定の時間に曲線を加え、アニメーションのスピードを変化させます。
		// Linear(startTime, startValue, endTime, endValue) : 時間と値の始めと終わりを設定する。直線の動き。
		AnimationCurve curveX = AnimationCurve.Linear((startFrame/60), startPosition.x, (endFrame/60), endPosition.x);
		AnimationCurve curveY = AnimationCurve.Linear((startFrame/60), startPosition.y, (endFrame/60), endPosition.y);
		AnimationCurve curveZ = AnimationCurve.Linear((startFrame/60), startPosition.z, (endFrame/60), endPosition.z);
		// アニメーションクリップの生成
		AnimationClip clip = new AnimationClip();
		// アニメーション名の設定
		clip.name = "moveAnima";
		clip.SetCurve("", typeof(Transform), "localPosition.x", curveX);
		clip.SetCurve("", typeof(Transform), "localPosition.y", curveY);
		clip.SetCurve("", typeof(Transform), "localPosition.z", curveZ);
		// アニメーションコンポーネントにクリップを追加
		animation.AddClip(clip, clip.name);
		// アニメーション開始
		animation.Play(clip.name);
	}
	/*===============================================================*/
}
/*===============================================================*/
