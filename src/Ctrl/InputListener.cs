using System;
using System.Collections;
using System.Collections.Generic;

public class InputListener{


	/*=======================================Constructor=========================================*/

	//建構子
	public InputListener(int priority, Func< Dictionary<string, object>, bool> onInput){
		this.priority = priority;
		this.onInput = onInput;
	}

	/*=========================================Members===========================================*/

	//名稱(可用於debug)
	public string name;

	//優先度
	public int priority;


	/*==========================================Event============================================*/

	//帶參數Dictionary 且會回傳 bool 的listener fucntion
	public event Func< Dictionary<string, object>, bool> onInput;



	/*=====================================Public Function=======================================*/

	public bool Call(Dictionary<string, object> inputInfo){
		return onInput(inputInfo);
	}
	
}