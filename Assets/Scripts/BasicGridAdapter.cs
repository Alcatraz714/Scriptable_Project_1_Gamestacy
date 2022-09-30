using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Other.Extensions;
using Com.TheFallenGames.OSA.CustomAdapters.GridView;
using Com.TheFallenGames.OSA.DataHelpers;
namespace TextureGrids.Grids
{
	public class BasicGridAdapter : GridAdapter<GridParams, MyGridItemViewsHolder>
	{
		public Sphere_Details_SO scriptable;
		public SimpleDataHelper<Sphere_Details> Data { get; private set; }
		
		#region GridAdapter implementation    
		protected override void Start()
		{
			Data = new SimpleDataHelper<Sphere_Details>(this);
			base.Start();
			RetrieveDataAndUpdate(scriptable.SphereDetailsList.Count);
		}
		
		protected override void UpdateCellViewsHolder(MyGridItemViewsHolder newOrRecycled)
		{
			Sphere_Details model = Data[newOrRecycled.ItemIndex];
			newOrRecycled.Update(model);
		}
		#endregion
		
		#region data manipulation
		public void AddItemsAt(int index, IList<Sphere_Details> items)
		{
			//Commented: this only works with Lists. ATM, Insert for Grids only works by manually changing the list and calling NotifyListChangedExternally() after
			//Data.InsertItems(index, items);
			Data.List.InsertRange(index, items);
			Data.NotifyListChangedExternally();
		}

		public void RemoveItemsFrom(int index, int count)
		{
			//Commented: this only works with Lists. ATM, Remove for Grids only works by manually changing the list and calling NotifyListChangedExternally() after
			//Data.RemoveRange(index, count);
			Data.List.RemoveRange(index, count);
			Data.NotifyListChangedExternally();
		}

		public void SetItems(IList<Sphere_Details> items)
		{
			Data.ResetItems(items);
		}
		#endregion
		void RetrieveDataAndUpdate(int count)
		{
			StartCoroutine(FetchMoreItemsFromDataSourceAndUpdate(count));
		}
		
		IEnumerator FetchMoreItemsFromDataSourceAndUpdate(int count)
		{
			yield return new WaitForSeconds(.5f);
			OnDataRetrieved(scriptable.SphereDetailsList.ToArray());
		}
		void OnDataRetrieved(Sphere_Details[] newItems)
		{
			Data.List.AddRange(newItems);
			Data.NotifyListChangedExternally();
		}
	}
	
	public class MyGridItemViewsHolder : CellViewsHolder
	{
		public Text TitleText;
		public Image BackgroundImage;
		private AdapterViewItem item;
		
		public override void CollectViews()
		{
			base.CollectViews();
			item = root.GetComponent<AdapterViewItem>();
		    views.GetComponent<AdapterViewItem>();
		}
		
		public void Update(Sphere_Details sps)
		{
			item.UpdateView(sps);
		}
	}
}