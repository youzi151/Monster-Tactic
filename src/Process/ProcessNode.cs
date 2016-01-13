using System.Collections;
using System.Collections.Generic;

public enum ProcessStatus{
	UNACTIVE/*未啟用*/, ACTIVE/*啟用中*/, COMPLETE/*以達成條件*/,CLOSE/*已結束關閉*/
}

public class ProcessNode{

	/*=============constructor============*/

	/*==============Members===============*/

	//節點狀態
	private ProcessStatus _status = ProcessStatus.UNACTIVE;
	public ProcessStatus status{
		get{
			return _status;
		}
	}

	//是否在條件滿足時，自動關閉此節點
	public bool isCloseOnComplete = false;


	/*=============Components=============*/

	//此節點會執行的事件
	public List<ProcessEvent> eventList;

	//要進行後續節點的條件
	public List<ProcessCondition> conditionToNextList;

	//後續的節點
	public List<ProcessNode> nextNodeList;


	/*================Event===============*/
	public event Action<T> onProcessBegin;
	public event Action<T> onProcessEnd;


	/*===========Public Function==========*/
	
	//開始此節點進程，通常受上一節點呼叫
	public void begin(){
		this._status = ProcessStatus.ACTIVE;
		foreach (ProcessEvent eachEvent in eventList){
			eachEvent.begin();
		}
		onProcessBegin();//event
	}
	
	//結束此節點進程
	public void end(){
		this._status = ProcessStatus.CLOSE;
		foreach (ProcessEvent eachEvent in eventList){
			eachEvent.end();
		}
		onProcessEnd();//event
	}

	//檢查是否完成條件
	public void checkIfComplete(){
		//先預設 條件狀態 已完成
		bool isCompelete = true;
		//若有條件尚未完成，則 條件狀態 改為 未完成，並跳出
		foreach (ProcessCondition eachCondition in nextNodeList){
			if (eachCondition.isCompelete() == false){
				isCompelete = false;
				break;
			}
		}

		//若已完成則呼叫
		if (isCompelete){
			onCoditionComplete();
		}	
	}

	/*==========Private Function==========*/

	//當完成條件時呼叫
	private void onCoditionComplete(){
		this._status = ProcessStatus.COMPLETE;

		//若設定為自動結束節點，則呼叫結束
		if(isCloseOnComplete){
			this.end();
		}

		//啟用每個下一節點
		foreach (ProcessNode eachNode in nextNodeList){
			eachNode.begin();
		}

	}



}