using System.Collections;
using System.Collections.Generic;

public class BuffData{


	/*==============Members===============*/



	/*=============Components=============*/



	/*================Event===============*/

	

	/*===========Public Function==========*/

	//把傳入的actionArgs經過buff 加成計算 或 再加入其他數值 params：actionArgs(行動資料), when(時機)
	public virtual void Buff(Dictionary<string, Object> actionArgs, string when){
		
		/*內容繼承後自定義*/

		//例如：

		//只有在使用時有作用；在受到攻擊時不作用
		switch (when){
			case "take":
				break;

			case "use":
				
				//[加成計算]攻擊力加倍
				if (args["atk"] != null){
					args["atk"] *= 2f;
				}

				//[加入數值]如果有特殊需求，可以加入其他數值
				//(例如加入"刺擊無效"當作tag，並且在有關刺擊的action中，檢查是否有"刺擊無效"的tag，有則改傷害為0)
				args["刺擊無效"] = 1/*true*/;

				break;

			default:
				break;
		}


	}



	/*==========Private Function==========*/




}