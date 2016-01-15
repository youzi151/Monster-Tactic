using System.Collections;

public class ProcessCondition{

	/*=============constructor============*/

	/*==============Members===============*/
	

	//是否正在偵聽
	private bool _isListening = false;
	public bool isListening{
		get{
			return _isListening;
		}
	}


	//是否已滿足條件
	private bool _isComplete = false;
	public bool isComplete{
		get{
			return _isComplete;
		}
	}


	/*=============Components=============*/


	/*================Event===============*/
	public event Action<T> onCompelete;

	public event Action<T> onStart;
	public event Action<T> onPause;
	public event Action<T> onResume;
	public event Action<T> onStop;

	/*===========Public Function==========*/

	//NOTE : 每一個函式呼叫內容順序不儘一樣，因為要符合使用者期待。
	
	//開始偵聽
	public void Start(){
		this._start();
		onStart();//event
		isListening = true;
	}

	//暫停偵聽
	public void Pause(){
		isListening = false;
		this._pause();
		onPause();//event
	}

	//繼續偵聽
	public void Resume(){
		this._resume();
		onResume();//event
		isListening = true;
	}
	
	//暫停偵聽
	public void Stop(){
		isListening = false;
		this._stop();
		onStop();//event
	}

	//重置此條件
	public void Reset(){
		isComplete = false;
		this._reset();//event
	}

	/*==========Private Function==========*/
	//開始偵聽
	public virtual void _start(){
		//內容繼承後自定義
	}

	//暫停偵聽
	public virtual void _pause(){
		//內容繼承後自定義
	}

	//繼續偵聽
	public virtual void _resume(){
		//內容繼承後自定義
	}
	
	//暫停偵聽
	public virtual void _stop(){
		//內容繼承後自定義
	}

	//重置此條件
	public virtual void _reset(){
		//內容繼承後自定義
	}


}