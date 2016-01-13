using System.Collections;
using System.Collections.Generic;

public class ChessObj{

	/*==============Members===============*/

	//生命值health point
	public float hp;

	//行動點數action point
	public float ap;


	/*=============Components=============*/

	//該單位的行動列表(移動、普攻、技能...等)
	public List<ActionData> actionList;
	
	//該單位會採用的 路徑搜索功能模塊(非真正的路徑演算核心)
	public PathFindComp pathFindComp;


	/*================Event===============*/
	public event Action<T> onAction;
	public event Action<T> onHurt;
	public event Action<T> onDead;
	


	/*===========Public Function==========*/
	//行動
	public void action(){}

	//受傷
	public void hurt(){}
	
	//死亡
	public void dead(){}
	
	

	/*==========Private Function==========*/

	//移動到指定位置
	private void moveTo(){}



}