Sort Merchant Store
NwN2 Electron toolset plugin.
2020 jul 17
0.1.0.0

Installation
------------
Close the NwN2 Toolset.

Copy nwn2_pi_storesorter.dll to your

<install>\Neverwinter Nights 2\NWN2Toolset\Plugins

folder.

Open the toolset and go to View|Options|Security and change

AllowPlugins=Load all plugins

Close and reopen the toolset.


Usage
-----
This plugin is a simple command under the Plugins menu. It does not have its own
window nor any options.

For it to sort the inventory items in a Merchant Store, first either select an
instanced store in an open Area or select a blueprint of a store in the
Blueprint tree. Do NOT select more than 1 object. Then invoke the command under
the Plugins menu "Sort Merchant Store".

Any items in the selected store's inventory ought be sorted automatically in
accord with the value in BaseItems.2da under the "StorePanel" column. Valid
values range from 0..4

    toolset         NwN2
0   Armor           Armors
1   Weapon          Weapons
2   Potion          Useables
3   Ring            Trinkets
4   Miscellaneous   Misc

An invalid value in BaseItems.2da causes its item-type to get sorted into the
Armor panel (0) by default. No warning or error is shown -- it's up to you to
keep your Items and BaseItems valid.

The docked Property Panel in the toolset should get updated automatically to
reflect any changes. But a floating Property Panel won't be updated (because the
toolset hates us).


Notes
-----
The panel that an item appears in can differ between the Electron toolset and
the NwN2 executable. That is, a scroll that has been put into the toolset's
Miscellaneous panel would still appear in its store's Potions panel while
playing. The BaseItems.2da "StorePanel" column is used by NwN2 instead of the
panel it has been listed under in the toolset. This plugin simply synchronizes
a store's inventory with what the game expects.

It's also convenient to simply place a bunch of items into a store's Armor panel
(for example) then do "Sort Merchant Store" to shuffle the items to their proper
panels.
