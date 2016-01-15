using System.Collections;
using System.Collections.Generic;

public class InputCtrl{

	/*==============Members===============*/

	//正在偵聽操作的物件清單
	public List<Action<T>> listenerList;


	/*=============Components=============*/


	/*================Event===============*/


	/*===========Public Function==========*/
	//加入偵聽者  params: 偵聽者本身, 優先度
	public void AddListener(Action<T> listener, int priority){}

	//移除偵聽者  params: 偵聽者本身
	public void RemoveListener(Action<T> listener){}

	//檢查Input，可放於Update執行
	public void CheckInput(){
		Object info = InputUtil.getHitObj_example();
		if (info != null){
			this.notifyListener(info);
		}
	}

	/*==========Private Function==========*/

	//依序通知每一個listener
	private void notifyListeners(T inputInfo){
		//先排序，以免優先度失效
		this.sortListener();

		foreach(Action<T> eachListener in listenerList){
			eachListener(inputInfo);
		}
	}

	//依照優先度排序
	private void sortListener(){}



}