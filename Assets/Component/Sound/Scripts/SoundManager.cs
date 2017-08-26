using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {
	/*
	public AudioSource _soundObject1;
	public float _soundObject1_volume;					//_soundObject1のVolumeを格納する変数
	public bool _soundObject1_spatialize;				//_soundObject1のspatializeを格納する変数
	public bool _soundObject1_PauseFlag;				//_soundObject1をPauseするか判定する変数

	public AudioSource _soundObject2;
	public float _soundObject2_volume;					//_soundObject2のVolumeを格納する変数
	public bool _soundObject2_spatialize;				//_soundObject2のspatializeを格納する変数
	public bool _soundObject2_PauseFlag;				//_soundObject2をPauseするか判定する変数

	public AudioSource _soundObject3;
	public float _soundObject3_volume;					//_soundObject3のVolumeを格納する変数
	public bool _soundObject3_spatialize;				//_soundObject3のspatializeを格納する変数
	public bool _soundObject3_PauseFlag;				//_soundObject3をPauseするか判定する変数

	public AudioSource _soundObject4;
	public float _soundObject4_volume;					//_soundObject4のVolumeを格納する変数
	public bool _soundObject4_spatialize;				//_soundObject4のspatializeを格納する変数
	public bool _soundObject4_PauseFlag;				//_soundObject4をPauseするか判定する変数

	public AudioSource _soundObject5;
	public float _soundObject5_volume;					//_soundObject5のVolumeを格納する変数
	public bool _soundObject5_spatialize;				//_soundObject5のspatializeを格納する変数
	public bool _soundObject5_PauseFlag;				//_soundObject5をPauseするか判定する変数

	public AudioSource _soundObject6;
	public float _soundObject6_volume;					//_soundObject6のVolumeを格納する変数
	public bool _soundObject6_spatialize;				//_soundObject6のspatializeを格納する変数
	public bool _soundObject6_PauseFlag;				//_soundObject6をPauseするか判定する変数
*/
	[System.Serializable]
	public struct SoundData {
		public AudioSource _sound;
		public float _sound_volume;					//_musicのVolumeを格納する変数
		public bool _sound_spatialize;				//_musicのspatializeを格納する変数
		public bool _sound_PauseFlag;				//_musicをPauseするか判定する変数
	};


	public SoundData _music1;
	public SoundData _music2;
	public SoundData _music3;
	public SoundData _music4;
	public SoundData _music5;
	public SoundData _music6;

	// Use this for initialization
	void Start () {
		/*if (_soundObject1) {
			_soundObject1_volume = _soundObject1.volume;
			_soundObject1_spatialize = _soundObject1.spatialize;
			_soundObject1_PauseFlag = true;
		}*/

		_music1 = InitializeAudioSource ( _music1._sound );
		/*
		if (_soundObject2) {
			_soundObject2_volume = _soundObject2.volume;
			_soundObject2_spatialize = _soundObject2.spatialize;
			_soundObject2_PauseFlag = true;
		}
		if (_soundObject3) {
			_soundObject3_volume = _soundObject3.volume;
			_soundObject3_spatialize = _soundObject3.spatialize;
			_soundObject3_PauseFlag = true;
		}
		if (_soundObject4) {
			_soundObject4_volume = _soundObject4.volume;
			_soundObject4_spatialize = _soundObject4.spatialize;
			_soundObject4_PauseFlag = true;
		}
		if (_soundObject5) {
			_soundObject5_volume = _soundObject5.volume;
			_soundObject5_spatialize = _soundObject5.spatialize;
			_soundObject5_PauseFlag = true;
		}
		if (_soundObject6) {
			_soundObject6_volume = _soundObject6.volume;
			_soundObject6_spatialize = _soundObject6.spatialize;
			_soundObject6_PauseFlag = true;
		}
		*/
	}

	// Update is called once per frame
	void Update () {
		//Inspector内での_soundObjectの調整
		_music1 = AdjustmentAudioSource( _music1 );
		/*
		if (_soundObject1) {
			_soundObject1.volume = _soundObject1_volume;
			_soundObject1.spatialize = _soundObject1_spatialize;
			if (_soundObject1_PauseFlag) {
				_soundObject1.Pause ();
			} else {
				_soundObject1.UnPause ();
			}
		}
		if (_soundObject2) {
			_soundObject2.volume = _soundObject2_volume;
			_soundObject2.spatialize = _soundObject2_spatialize;
			if (_soundObject2_PauseFlag) {
				_soundObject2.Pause ();
			} else {
				_soundObject2.UnPause ();
			}
		}
		if (_soundObject3) {
			_soundObject3.volume = _soundObject3_volume;
			_soundObject3.spatialize = _soundObject3_spatialize;
			if (_soundObject3_PauseFlag) {
				_soundObject3.Pause ();
			} else {
				_soundObject3.UnPause ();
			}
		}
		if (_soundObject4) {
			_soundObject4.volume = _soundObject4_volume;
			_soundObject4.spatialize = _soundObject4_spatialize;
			if (_soundObject4_PauseFlag) {
				_soundObject4.Pause ();
			} else {
				_soundObject4.UnPause ();
			}
		}
		if (_soundObject5) {
			_soundObject5.volume = _soundObject5_volume;
			_soundObject5.spatialize = _soundObject5_spatialize;
			if (_soundObject5_PauseFlag) {
				_soundObject5.Pause ();
			} else {
				_soundObject5.UnPause ();
			}
		}
		if (_soundObject6) {
			_soundObject6.volume = _soundObject6_volume;
			_soundObject6.spatialize = _soundObject6_spatialize;
			if (_soundObject6_PauseFlag) {
				_soundObject6.Pause ();
			} else {
				_soundObject6.UnPause ();
			}
		}
		*/


		//ボタンによる_soundObjectの調整
		/*
		if (_soundObject1) {
			VolumeControll (_soundObject1);
			SpatializeControll ( _soundObject1 );
		}
		if (_soundObject2) {
			VolumeControll (_soundObject2);
			SpatializeControll ( _soundObject2 );
		}
		if (_soundObject3) {
			VolumeControll (_soundObject3);
			SpatializeControll ( _soundObject3 );
		}
		if (_soundObject4) {
			VolumeControll (_soundObject4);
			SpatializeControll ( _soundObject4 );
		}
		if (_soundObject5) {
			VolumeControll (_soundObject5);
			SpatializeControll ( _soundObject5 );
		}
		if (_soundObject6) {
			VolumeControll (_soundObject6);
			SpatializeControll ( _soundObject6 );
		}
		*/
	}





	void LateUpdate() {
		//Inspectorに_soundObject1の調整を反映
		_music1 = ReflectAudioSource( _music1._sound );
		/*
		if (_soundObject1) {
			_soundObject1_volume = _soundObject1.volume;
			_soundObject1_spatialize = _soundObject1.spatialize;
		}
		if (_soundObject2) {
			_soundObject2_volume = _soundObject2.volume;
			_soundObject2_spatialize = _soundObject2.spatialize;
		}
		if (_soundObject3) {
			_soundObject3_volume = _soundObject3.volume;
			_soundObject3_spatialize = _soundObject3.spatialize;
		}
		if (_soundObject4) {
			_soundObject4_volume = _soundObject4.volume;
			_soundObject4_spatialize = _soundObject4.spatialize;
		}
		if (_soundObject5) {
			_soundObject5_volume = _soundObject5.volume;
			_soundObject5_spatialize = _soundObject5.spatialize;
		}
		if (_soundObject6) {
			_soundObject6_volume = _soundObject6.volume;
			_soundObject6_spatialize = _soundObject6.spatialize;
		}
*/
	}










	//---AudioSourceのVolumeを調整する関数
	public void VolumeControll( AudioSource _music ) {
		if (Input.GetKeyDown (KeyCode.F)) {
			_music.volume += 0.1f;
			Debug.Log ( _music.gameObject.name + "のVolumeを" + _music.volume + "にしました" );
		}
		if (Input.GetKeyDown (KeyCode.J)) {
			_music.volume -= 0.1f;
			Debug.Log ( _music.gameObject.name + "のVolumeを" + _music.volume + "にしました" );
		}
	}

	//---AudioSourceのspatializeを調整する関数
	public void SpatializeControll( AudioSource _music ) {
		if (Input.GetKeyDown (KeyCode.Space)) {
			_music.spatialize = false;
			_music.spatialBlend = 0f;
			Debug.Log (_music.gameObject.name + "の空間化を無効にし,3D→2D");
		}
		if (Input.GetKeyDown (KeyCode.Return)) {
			_music.spatialize = true;
			_music.spatialBlend = 1f;
			Debug.Log (_music.gameObject.name + "の空間化を有効にし,2D→3D");
		}
	}


	//---SoundManagerのInspectorを初期化する関数
	public SoundData InitializeAudioSource( AudioSource _music ) {
		SoundData x;

		x._sound = null;
		x._sound_volume = 0f;
		x._sound_spatialize = false;
		x._sound_PauseFlag = true;
		if ( _music ) {
			x._sound = _music;
			x._sound_volume = _music.volume;
			x._sound_spatialize = _music.spatialize;
			x._sound_PauseFlag = true;
			Debug.Log ( "初期化されたよ" );
			return x;
		}
		Debug.Log ( "何もないよ" );
		return x;
	}


	//---Inspector内での調整をAoudioSourceに反映する関数
	public SoundData AdjustmentAudioSource( SoundData x ) {
		if (x._sound) {
			x._sound.volume = x._sound_volume;
			x._sound.spatialize = x._sound_spatialize;
			if (x._sound_PauseFlag) {
				x._sound.Pause ();
			} else {
				x._sound.UnPause ();
			}
			return x;

		}
		Debug.LogError ( "何もないよ！！" );
		return x;
	}


	//--AoudioSourceの値をInspector内に反映する関数
	public SoundData ReflectAudioSource( AudioSource _music ) {
		SoundData x;

		x._sound = null;
		x._sound_volume = 0f;
		x._sound_spatialize = false;
		x._sound_PauseFlag = true;
		if (_music) {
			x._sound_volume = _music.volume;
			x._sound_spatialize = _music.spatialize;

			return x;
		}
		Debug.Log ("何もないよ");
		return x;
	}








}
