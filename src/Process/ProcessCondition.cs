using System;
using System.Collections;

public class ProcessCondition{

	/*======================================Constructor==========================================*/

	/*=========================================Members===========================================*/

	//是否正在偵聽
	protected bool _isListening = false;
	public bool isListening{
		get{
			return _isListening;
		}
	}


	//是否已滿足條件
	protected bool _isCompelete = false;
	public bool isCompelete{
		get{
			return _isCompelete;
		}
	}


	/*========================================Components=========================================*/


	/*==========================================Event============================================*/
	public event Action onCompelete = delegate{};
	public event Action onBegin = delegate{};
	public event Action onPause = delegate{};
	public event Action onResume = delegate{};
	public event Action onEnd = delegate{};

	/*=====================================Public Function=======================================*/

	//NOTE : 每一個函式呼叫內容順序不儘一樣，因為要符合使用者期待。
	
	//開始偵聽
	public void Begin(){
		this._begin();
		onBegin();//event
		_isListening = true;
	}

	//暫停偵聽
	public void Pause(){
		_isListening = false;
		this._pause();
		onPause();//event
	}

	//繼續偵聽
	public void Resume(){
		this._resume();
		onResume();//event
		_isListening = true;
	}
	
	//暫停偵聽
	public void End(){
		_isListening = false;
		this._end();
		onEnd();//event
	}

	//重置此條件
	public void Reset(){
		_isCompelete = false;
		this._reset();//event
	}

	//檢查是否已完成
	public virtual void CheckIfCompelete(){
		//內容繼承後自定義
		//例如:
		if (isListening){
			//作某種檢查
			
			//若沒通過
			return;

			//若通過
			compelete();
		}
	}

	
	/*===================================Protected Function======================================*/
	//設置為完成
	protected void compelete(){
		_isCompelete = true;
	}


	//開始偵聽
	protected virtual void _begin(){
		//內容繼承後自定義
	}

	//暫停偵聽
	protected virtual void _pause(){
		//內容繼承後自定義
	}

	//繼續偵聽
	protected virtual void _resume(){
		//內容繼承後自定義
	}
	
	//暫停偵聽
	protected virtual void _end(){
		//內容繼承後自定義
	}

	//重置此條件
	protected virtual void _reset(){
		//內容繼承後自定義
	}
	

	/*====================================Private Function=======================================*/

}
