using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//开始时＋一个限制 必须有刚
[RequireComponent (typeof(Rigidbody ))]
//碰撞器
[RequireComponent(typeof (CapsuleCollider ))]
public class MyPeopleCharacter : MonoBehaviour {
	public float m_speed = 0.01f;
	Rigidbody m_rigidbody;
	void Start () {
		m_rigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		this.MoveControlByTranslate ();
	}

	//Translate移动控制函数
	void MoveControlByTranslate()
	{
//		float horizontal = Input.GetAxis("Horizontal"); //A D 左右
//		float vertical = Input.GetAxis("Vertical"); //W S 上 下
//		//这个必须分开判断 因为一个物体的速度只有一个
//		if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.S))
//		{
//			m_rigidbody.velocity = Vector3.forward * vertical * m_speed;
//		}
//		if (Input.GetKey(KeyCode.A)|Input.GetKey(KeyCode.D))
//		{
//			m_rigidbody.velocity = Vector3.right * horizontal * m_speed;
//		} 

		if (Input.GetKey(KeyCode.W)|Input.GetKey(KeyCode.UpArrow)) //前
		{
			this.transform.Translate(Vector3.forward*m_speed*Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow)) //后
		{
			this.transform.Translate(Vector3.forward *- m_speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow)) //左
		{
			this.transform.Translate(Vector3.right *-m_speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow)) //右
		{
			this.transform.Translate(Vector3.right * m_speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Space)) //前
		{
			this.transform.Translate(Vector3.up*20);
		}
	}
}
