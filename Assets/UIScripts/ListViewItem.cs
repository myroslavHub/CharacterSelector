using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ListViewItem : MonoBehaviour
{
	public int ID;
	public Text name;
	public Image icon;

	// Use this for initialization
	void Start () {
	
	}

	public void OnItemClicked()
	{
		if (ItemClicked != null)
			ItemClicked(ID);
	}

	public event Action<int> ItemClicked;
}