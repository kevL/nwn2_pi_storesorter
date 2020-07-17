using System;

using NWN2Toolset.Plugins;

using TD.SandBar;


namespace nwn2_pi_storesorter
{
	/// <summary>
	/// NwN2 Electron toolset plugin.
	/// </summary>
	public class StoreSorter
		: INWN2Plugin
	{
		#region INWN2Plugin (interface)
		public MenuButtonItem PluginMenuItem
		{ get; set; }

		public object Preferences
		{ get; set; }

		/// <summary>
		/// Preferences will be stored in an XML-file w/ this label in
		/// "C:\Users\User\AppData\Local\NWN2 Toolset\Plugins" (or similar)
		/// but this plugin has no preferences.
		/// </summary>
		public string Name
		{ get; set; }

		/// <summary>
		/// The label of the operation on the toolset's "Plugins" menu.
		/// </summary>
		public string MenuName
		{
			get { return "Sort Merchant Store"; }
		}

		/// <summary>
		/// The caption on the titlebar of the plugin window. If this had a
		/// window; there is no window.
		/// This is also the name that appears in the toolset's Options.
		/// @note There are no options.
		/// </summary>
		public string DisplayName
		{
			get { return "Sort Merchant Store"; }
		}


		public void Load(INWN2PluginHost host)
		{}

		public void Startup(INWN2PluginHost host)
		{
			PluginMenuItem = host.GetMenuForPlugin(this);
			PluginMenuItem.Activate += storesort;
		}

		public void Shutdown(INWN2PluginHost host)
		{}

		public void Unload(INWN2PluginHost host)
		{}
		#endregion INWN2Plugin (interface)


		/// <summary>
		/// Handler that launches 'StoreSort' from the toolset's Plugins.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void storesort(object sender, EventArgs e)
		{
#if DEBUG
			logfile.createLogfile();
#endif
			StoreSort.SortStore();
		}
	}
}
