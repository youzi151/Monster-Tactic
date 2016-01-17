using System.Collections;
using System.Collections.Generic;


public class CmdData{

	//NOTE : 若是多人連線，最好是只用 CmdData的子類編號 及 附帶參數args 就可以順利傳遞。


	/*=========================================Members===========================================*/
	
	//附帶參數，(receiver也包含在裡面)
	public Dictionary<string, Object> args;


	/*========================================Components=========================================*/


	/*==========================================Event============================================*/
	//因為多人連線應用到CmdData來傳遞訊息，故不使用Event
	// public event Action<T> onDo;
	// public event Action<T> onUndo;
	// public event Action<T> onCancel;
	// public event Action<T> onError;

	/*=====================================Public Function=======================================*/

	//執行
	public virtual void Do(){
		//內容繼承後自定義
	}

	//復原
	public virtual void Undo(){
		//內容繼承後自定義
	}
	
	//取消
	public virtual void Cancel(){
		//內容繼承後自定義
	}


	
	

	/*====================================Private Function=======================================*/



}