using System.Collections;
using System.Collections.Generic;

public enum ProcessStatus{
	INACTIVE/*未啟用*/, ACTIVE/*啟用中*/, COMPLETE/*以達成條件*/
}

public class ProcessNode{

	/*======================================Constructor==========================================*/

	/*=========================================Members===========================================*/

	//節點狀態
	public ProcessStatus status = ProcessStatus.INACTIVE;


	//是否自動開始
	public bool isAutoStart = false;

	//是否在條件滿足時，自動關閉此節點
	public bool isCloseOnComplete = false;


	/*========================================Components=========================================*/

	//此節點會執行的事件
	public List<ProcessEvent> eventList = new List<ProcessEvent>();

	//要進行後續節點的條件
	public List<ProcessCondition> conditionToNextList = new List<ProcessCondition>();

	//後續的節點
	public List<ProcessNode> nextNodeList = new List<ProcessNode>();


	/*==========================================Event============================================*/
	public event Action<T> onProcessBegin = delegate{};
	public event Action<T> onProcessEnd = delegate{};


	/*=====================================Public Function=======================================*/
	
	//開始此節點進程，通常受上一節點呼叫
	public void Begin(){

		//改變狀態
		this.status = ProcessStatus.ACTIVE;

		//開始每一個事件
		foreach (ProcessEvent eachEvent in eventList){
			eachEvent.Begin();
		}

		//開始每一個條件檢查
		foreach (ProcessCondition eachCondition in conditionToNextList){
			eachCondition.Begin();
		}

		//event
		onProcessBegin();
	}
	
	//結束此節點進程
	public void End(){

		//改變狀態
		this.status = ProcessStatus.INACTIVE;

		//結束每一個事件
		foreach (ProcessEvent eachEvent in eventList){
			eachEvent.End();
		}

		//結束每一個條件檢查
		foreach (ProcessCondition eachCondition in conditionToNextList){
			eachCondition.End();
		}

		//event
		onProcessEnd();
	}

	//檢查是否完成條件
	public void CheckIfComplete(){

		//不在啟用狀態下則不作用
		if (this.status != ProcessStatus.ACTIVE) return;

		//先預設 條件狀態 已完成
		bool isCompelete = true;

		//若有條件尚未完成，則 條件狀態 改為 未完成，並跳出
		foreach (ProcessCondition eachCondition in nextNodeList){
			if (eachCondition.isCompelete == false){
				isCompelete = false;
				break;
			}
		}

		//若已完成則呼叫
		if (isCompelete){
			onCoditionComplete();
		}	
	}
	
	/*===================================Protected Function======================================*/

	/*====================================Private Function=======================================*/

	//當完成條件時呼叫
	private void onCoditionComplete(){
		this.status = ProcessStatus.COMPLETE;

		//若設定為自動結束節點，則呼叫結束
		if(isCloseOnComplete){
			this.End();
		}

		//啟用每個下一節點
		foreach (ProcessNode eachNode in nextNodeList){
			eachNode.Begin();
		}

	}



}