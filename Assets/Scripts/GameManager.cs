using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private static GameManager m_instance;
	public static GameManager Instance {
		get {
			if (!m_instance)
				m_instance = FindObjectOfType(typeof(GameManager)) as GameManager;
			return m_instance;
		}
	}

	private Action m_inIt;

	/// <summary>
	/// 매니저 클래스 초기화 작업
	/// </summary>
	/// <param name="method"></param>
	public void Init (Action method) {	m_inIt += method; }

	private void Awake () {
		if (m_instance == null) {
			m_instance = this;
		} else if (m_instance != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
		
		if(m_inIt != null)
			m_inIt();
	}

	private void Start () {
		
	}

	private void Update () {
		
	}
}