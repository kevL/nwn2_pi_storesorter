using System;

using NWN2Toolset;
using NWN2Toolset.NWN2.Data.Templates;
using NWN2Toolset.NWN2.Data.TypedCollections;
using NWN2Toolset.NWN2.Views;

using NWN2Toolset.NWN2.Data.Blueprints;
using NWN2Toolset.NWN2.Data.Instances;

using OEIShared.IO.TwoDA;
using OEIShared.Utils;


namespace nwn2_pi_storesorter
{
	sealed class StoreSort
	{
		internal StoreSort()
		{
			// first check areaviewer for a selected Instance ->
			NWN2AreaViewer areaviewer;
			NWN2InstanceCollection collection;

			if ((areaviewer = NWN2ToolsetMainForm.App.GetActiveViewer() as NWN2AreaViewer) != null
				&& (collection = areaviewer.SelectedInstances) != null && collection.Count == 1
				&& collection[0] is NWN2StoreTemplate)
			{
				var store = collection[0] as NWN2StoreInstance;
				var its = new NWN2InstanceStoreItemCollection();


				// add items in the store of all types into 'its'
				int count = store.ArmorItems.Count;
				for (int i = 0; i != count; ++i)
					its.Add(store.ArmorItems[i]);

				store.ArmorItems.Clear();


				count = store.WeaponItems.Count;
				for (int i = 0; i != count; ++i)
					its.Add(store.WeaponItems[i]);

				store.WeaponItems.Clear();


				count = store.PotionItems.Count;
				for (int i = 0; i != count; ++i)
					its.Add(store.PotionItems[i]);

				store.PotionItems.Clear();


				count = store.RingItems.Count;
				for (int i = 0; i != count; ++i)
					its.Add(store.RingItems[i]);

				store.RingItems.Clear();


				count = store.MiscellaneousItems.Count;
				for (int i = 0; i != count; ++i)
					its.Add(store.MiscellaneousItems[i]);

				store.MiscellaneousItems.Clear();


				// sort the items that are in 'its' to their store-panels per their BaseItems.2da "StorePanel" val
				TwoDAReference TwoDaRef;
				int id;

				for (int i = 0; i != its.Count; ++i)
				{
					id = its[i].Item.BaseItem.Row;
					TwoDaRef = new TwoDAReference("baseitems", "StorePanel", false, id);

					switch (TwoDaRef.ToString())
					{
						default:
//						case "0": // Armor
							store.ArmorItems.Add(its[i]);
							break;

						case "1": // Weapon
							store.WeaponItems.Add(its[i]);
							break;

						case "2": // Potion or scroll (useables)
							store.PotionItems.Add(its[i]);
							break;

						case "3": // Ring etc. (trinkets)
							store.RingItems.Add(its[i]);
							break;

						case "4": // Miscellaneous
							store.MiscellaneousItems.Add(its[i]);
							break;
					}
				}

				var a = new INWN2Instance[] { store };
				NWN2ToolsetMainForm.App.AreaContents.SelectInstances(a); // update store panels.
			}
			else // second check blueprint tree for a selected Blueprint ->
			{
				object[] selection = NWN2ToolsetMainForm.App.BlueprintView.Selection;
				if (selection != null && selection.Length == 1
					&& (selection[0] as INWN2Template).ObjectType == NWN2ObjectType.Store)
				{
					var store = selection[0] as NWN2StoreBlueprint;
					var its = new NWN2BlueprintStoreItemCollection();


					// add items in the store of all types into 'its'
					int count = store.ArmorItems.Count;
					for (int i = 0; i != count; ++i)
						its.Add(store.ArmorItems[i]);

					store.ArmorItems.Clear();


					count = store.WeaponItems.Count;
					for (int i = 0; i != count; ++i)
						its.Add(store.WeaponItems[i]);

					store.WeaponItems.Clear();


					count = store.PotionItems.Count;
					for (int i = 0; i != count; ++i)
						its.Add(store.PotionItems[i]);

					store.PotionItems.Clear();


					count = store.RingItems.Count;
					for (int i = 0; i != count; ++i)
						its.Add(store.RingItems[i]);

					store.RingItems.Clear();


					count = store.MiscellaneousItems.Count;
					for (int i = 0; i != count; ++i)
						its.Add(store.MiscellaneousItems[i]);

					store.MiscellaneousItems.Clear();


					// sort the items that are in 'its' to their store-panels per their BaseItems.2da "StorePanel" val
					TwoDAReference TwoDaRef;
					int id;

					for (int i = 0; i != its.Count; ++i)
					{
						var it = new NWN2ItemInstance(its[i].Item);
						id = it.BaseItem.Row;
						TwoDaRef = new TwoDAReference("baseitems", "StorePanel", false, id);

						switch (TwoDaRef.ToString())
						{
							default:
//							case "0": // Armor
								store.ArmorItems.Add(its[i]);
								break;

							case "1": // Weapon
								store.WeaponItems.Add(its[i]);
								break;

							case "2": // Potion or scroll (useables)
								store.PotionItems.Add(its[i]);
								break;

							case "3": // Ring etc. (trinkets)
								store.RingItems.Add(its[i]);
								break;

							case "4": // Miscellaneous
								store.MiscellaneousItems.Add(its[i]);
								break;
						}
					}

					string label = (selection[0] as INWN2Object).LocalizedName[BWLanguages.CurrentLanguage];
					NWN2ToolsetMainForm.App.CreateNewPropertyPanel(selection, NWN2ToolsetMainForm.App.Module, false, label); // update store panels.
				}
			}
		}
	}
}
