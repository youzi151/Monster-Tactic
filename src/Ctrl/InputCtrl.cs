using System.Collections;
using System.Collections.Generic;

public class InputCtrl{

	/*=========================================Members===========================================*/

	//正在偵聽操作的物件清單
	public List< Func<T, bool> > listenerList;


	/*========================================Components=========================================*/


	/*==========================================Event============================================*/


	/*=====================================Public Function=======================================*/
	//加入偵聽者  params: 偵聽者本身, 優先度
	public void AddListener(Func<T, bool> listener, float priority){
		
		//加入偵聽者
		listenerList.Add(listener);

		//TODO : 排序




	}

	//移除偵聽者  params: 偵聽者本身
	public void RemoveListener(Func<T, bool> listener){
		//加入偵聽者
		listenerList.Remove(listener);
	}

	//檢查Input，可放於Update執行
	public void CheckInput(){
		Object info = InputUtil.getHitObj_example();
		if (info != null){
			this.notifyListener(info);
		}
	}

	/*====================================Private Function=======================================*/

	//依序通知每一個listener
	private void notifyListeners(T inputInfo){

		//依序通知，並詢問是否已經取用  (已取用 == 不給下一個listener)
		foreach(Func<T, bool> eachNotify in listenerList){

			//若該listener回傳true，則代表已取用
			bool isUsed = eachNotify(inputInfo);

			//若已取用，停止繼續通知其他listener
			if (isUsed){
				break;
			}

		}
	}




}