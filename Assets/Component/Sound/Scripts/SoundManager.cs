using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {
	
	[System.Serializable]
	public struct SoundData {
		public AudioSource _sound;
		public float _sound_volume;					//_musicのVolumeを格納する変数
		public bool _sound_spatialize;				//_musicのspatializeを格納する変数
		public bool _sound_PauseFlag;				//_musicをPauseするか判定する変数
		public bool _button_controll;				//各種設定をボタンでコントロールするか判定する変数
	};
	public SoundData _music1;
	public SoundData _music2;
	public SoundData _music3;
	public SoundData _music4;
	public SoundData _music5;
	public SoundData _music6;
	public SoundData _music7;
	public SoundData _music8;
	public SoundData _music9;
	public SoundData _music10;
	public SoundData _music11;
	public SoundData _music12;


	public float volume_change = 0.1f; 



	// Use this for initialization
	void Start () {
		//SoundManagerのInspectorを初期化する
		_music1 = InitializeAudioSource ( _music1._sound );
		_music2 = InitializeAudioSource ( _music2._sound );
		_music3 = InitializeAudioSource ( _music3._sound );
		_music4 = InitializeAudioSource ( _music4._sound );
		_music5 = InitializeAudioSource ( _music5._sound );
		_music6 = InitializeAudioSource ( _music6._sound );
		_music6 = InitializeAudioSource ( _music7._sound );
		_music6 = InitializeAudioSource ( _music8._sound );
		_music6 = InitializeAudioSource ( _music9._sound );
		_music6 = InitializeAudioSource ( _music10._sound );
		_music6 = InitializeAudioSource ( _music11._sound );
		_music6 = InitializeAudioSource ( _music12._sound );
	
	}

	// Update is called once per frame
	void Update () {
		//Inspector内での調整を対応するAoudioSourceに反映する
		_music1 = AdjustmentAudioSource( _music1 );
		_music2 = AdjustmentAudioSource( _music2 );
		_music3 = AdjustmentAudioSource( _music3 );
		_music4 = AdjustmentAudioSource( _music4 );
		_music5 = AdjustmentAudioSource( _music5 );
		_music6 = AdjustmentAudioSource( _music6 );
		_music6 = AdjustmentAudioSource( _music7 );
		_music6 = AdjustmentAudioSource( _music8 );
		_music6 = AdjustmentAudioSource( _music9 );
		_music6 = AdjustmentAudioSource( _music10 );
		_music6 = AdjustmentAudioSource( _music11 );
		_music6 = AdjustmentAudioSource( _music12 );


		//ボタンによる_soundObjectの調整
		_music1 = ButtonControll( _music1 );
		_music2 = ButtonControll( _music2 );
		_music3 = ButtonControll( _music3 );
		_music4 = ButtonControll( _music4 );
		_music5 = ButtonControll( _music5 );
		_music6 = ButtonControll( _music6 );
		_music6 = ButtonControll( _music7 );
		_music6 = ButtonControll( _music8 );
		_music6 = ButtonControll( _music9 );
		_music6 = ButtonControll( _music10 );
		_music6 = ButtonControll( _music11 );
		_music6 = ButtonControll( _music12 );


	}
		
	void LateUpdate() {
		//対応するAoudioSourceの値をInspector内に反映する
		_music1 = ReflectAudioSource( _music1 );
		_music2 = ReflectAudioSource( _music2 );
		_music3 = ReflectAudioSource( _music3 );
		_music4 = ReflectAudioSource( _music4 );
		_music5 = ReflectAudioSource( _music5 );
		_music6 = ReflectAudioSource( _music6 );
		_music6 = ReflectAudioSource( _music7 );
		_music6 = ReflectAudioSource( _music8 );
		_music6 = ReflectAudioSource( _music9 );
		_music6 = ReflectAudioSource( _music10 );
		_music6 = ReflectAudioSource( _music11 );
		_music6 = ReflectAudioSource( _music12 );
	}















	//---SoundManagerのInspectorを初期化する関数
	public SoundData InitializeAudioSource( AudioSource _music ) {
		SoundData x;
		//動的初期化
		x._sound = null;
		x._sound_volume = 0f;
		x._sound_spatialize = false;
		x._sound_PauseFlag = true;
		x._button_controll = false;
		if ( _music ) {
			x._sound = _music;
			x._sound_volume = _music.volume;
			x._sound_spatialize = _music.spatialize;
		} else {
			Debug.LogWarning ("AudioSourceが対応してません。");
		}
		return x;
	}


	//---Inspector内での調整を対応するAoudioSourceに反映する関数
	public SoundData AdjustmentAudioSource( SoundData x ) {
		if (x._sound) {
			x._sound.volume = x._sound_volume;
			x._sound.spatialize = x._sound_spatialize;
			if (x._sound_PauseFlag) {
				x._sound.Pause ();
			} else {
				x._sound.UnPause ();
			}
		} else {
			Debug.LogWarning (x + "に反映させるAudioSourceがありません");
		}
		return x;
	}


	//--対応するAoudioSourceの値をInspector内に反映する関数
	public SoundData ReflectAudioSource( SoundData x ) {
		if (x._sound) {
			x._sound_volume = x._sound.volume;
			x._sound_spatialize = x._sound.spatialize;
		} else {
			Debug.LogWarning (x + "にAudioSourceがないためInspectorに表示出来ません");
		}
		return x;
	}


	//---AudioSourceのVolumeを調整する関数(ボタン操作)
	public void VolumeControll( AudioSource _music ) {
		if (Input.GetKey (KeyCode.V) && Input.GetKeyDown( KeyCode.UpArrow )) {
			_music.volume += volume_change;
			Debug.Log ( _music.gameObject.name + "のVolumeを" + _music.volume + "にしました" );
		}
		if (Input.GetKey (KeyCode.V) && Input.GetKeyDown( KeyCode.DownArrow )) {
			_music.volume -= volume_change;
			Debug.Log ( _music.gameObject.name + "のVolumeを" + _music.volume + "にしました" );
		}
	}

	//---AudioSourceのspatializeを調整する関数(ボタン操作)
	public void SpatializeControll( AudioSource _music ) {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (_music.spatialize) {
				_music.spatialize = false;
				_music.spatialBlend = 0f;
				Debug.Log (_music.gameObject.name + "の空間化を無効にし,3D→2D");
			} else {
				_music.spatialize = true;
				_music.spatialBlend = 1f;
				Debug.Log (_music.gameObject.name + "の空間化を有効にし,2D→3D");
			}
		}
	}


	//---AudioSourceの再生・一時停止を操作する関数(ボタン操作) ※Inspector内のx._sound_PauseFlagを変更するだけです
	public SoundData PauseControll( SoundData x ) {
		if ( Input.GetKeyDown( KeyCode.Return ) ) {
			if ( x._sound_PauseFlag ) {
				x._sound_PauseFlag = false;
				Debug.Log ( x._sound.gameObject.name + "を再生しました" );
			} else {
				x._sound_PauseFlag = true;
				Debug.Log ( x._sound.gameObject.name + "を一時停止しました" );
			}
		}
		return x;
	}


	//---ボタンによってAudioSourceの値を変化させる関数
	public SoundData ButtonControll( SoundData x ) {
		if (x._button_controll) {
			VolumeControll (x._sound);			//Volume調整
			SpatializeControll (x._sound);		//spatialize調整
			x　= PauseControll( x );					//再生・一時停止を操作 ※仮引数に注意
		}
		return x;
	}






}
