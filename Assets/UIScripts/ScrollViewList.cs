using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class ListViewDataItem
{
	public int ID;
	public string name;
	public Sprite characterIcon;
	public GameObject character;
}


public class ScrollViewList : MonoBehaviour
{

	public GameObject itemTemplate;
	public List<ListViewDataItem> Items;

	public Transform contentPanel;

	private int selectedIndex = 0;
	// Use this for initialization

	private GameObject champion;
	private bool championRun = false;

	public void MakeItRun()
	{
		championRun = !championRun;
		var an = champion.GetComponent<Animator>();
		an.SetBool("Move", championRun);
		Debug.Log(championRun);
	}

	void Start ()
	{
		ShowChamp(selectedIndex);
		foreach (ListViewDataItem listViewDataItem in Items)
		{ 
			var obj = Instantiate(itemTemplate) as GameObject;

			ListViewItem item = obj.GetComponent<ListViewItem>();
			item.ID = listViewDataItem.ID;
			item.name.text = listViewDataItem.name;
			item.icon.sprite = listViewDataItem.characterIcon;

			item.ItemClicked += OnItemClicked;

			obj.transform.SetParent(contentPanel);
		}
	}

	private void ShowChamp(int index)
	{
		if (champion != null)
		{
			GameObject.Destroy(champion);
			champion = null;
		}
		selectedIndex = index;
		var item = Items.Where(x => x.ID == selectedIndex).ToList();
		championRun = false;

		champion = Instantiate(item[0].character);
	}

	private void OnItemClicked(int index)
	{
		ShowChamp(index);
	}
}