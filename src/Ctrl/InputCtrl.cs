using System.Collections;
using System.Collections.Generic;

public class InputCtrl{

	/*=========================================Members===========================================*/

	//正在偵聽操作的物件清單
	public List<InputListener> listenerList;


	/*========================================Components=========================================*/


	/*==========================================Event============================================*/


	/*=====================================Public Function=======================================*/
	//加入偵聽者  params: 偵聽者本身, 優先度
	public void AddListener(InputListener listener, float priority){
		
		//加入偵聽者
		listenerList.Add(listener);

		//排序
		this.SortListener();

	}

	//移除偵聽者  params: 偵聽者本身
	public void RemoveListener(InputListener listener){
		//加入偵聽者
		listenerList.Remove(listener);
	}

	//檢查Input，可放於Update執行
	public void CheckInput(){
		Object inputInfo = InputUtil.getHitObj_example();
		if (inputInfo != null){
			this.notifyListener(inputInfo);
		}
	}

	/*====================================Private Function=======================================*/

	//依序通知每一個listener
	private void notifyListeners(Dictionary<string, object> inputInfo){

		//依序通知，並詢問是否已經取用  (已取用 == 不給下一個listener)
		foreach(InputListener eachNotify in listenerList){

			//若該listener回傳true，則代表已取用
			bool isUsed = eachNotify.Call(inputInfo);

			//若已取用，停止繼續通知其他listener
			if (isUsed){
				break;
			}

		}
	}




}