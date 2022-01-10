using System.Collections.Generic;


namespace Nez.UI
{
	public class TabPane : Table
	{
		public Tab CurrentTab;
		public List<Tab> Tabs;
		public List<TabButton> TabButtons;
		private TabWindowStyle _style;
		private Table _buttonsTable;
		private Table _tabTable;

		public TabPane(TabWindowStyle style)
		{
			_style = style;
			Init();
		}

		private void Init()
		{
			SetSize(100, 100);

			SetBackground(_style.Background);

			Top().Left();

			Tabs = new List<Tab>();
			TabButtons = new List<TabButton>();

			_buttonsTable = new Table();
			_buttonsTable.SetFillParent(true);
			_buttonsTable.Top().Left();
			_tabTable = new Table();
			_tabTable.Top().Left();

			Row();
			Add(_buttonsTable).Fill().SetExpandX();
			Row();
			Add(_tabTable).Fill().SetExpandY();
		}

		public void AddTab(Tab tab)
		{
			Tabs.Add(tab);

			var tabBtn = new TabButton(tab, _style.TabButtonStyle);
			tabBtn.OnClick += () => { SetActiveTab(tabBtn.GetTab()); };
			TabButtons.Add(tabBtn);
			_buttonsTable.Add(tabBtn);

			if (Tabs.Count == 1)
			{
				CurrentTab = Tabs[0];
				_tabTable.Add(tab).Left().Top().Fill().Expand();

				tabBtn.ToggleOn();
			}

			if (Tabs.Count == 1)
				SetActiveTab(0);
		}

		public void SetActiveTab(int index)
		{
			var tab = Tabs[index];
			if (tab != CurrentTab)
			{
				_tabTable.Clear();
				_tabTable.Add(tab).Left().Top().Fill().Expand();

				TabButtons[index].ToggleOn();

				var i = Tabs.IndexOf(CurrentTab);
				TabButtons[i].ToggleOff();

				CurrentTab = tab;
			}
		}

		protected void SetActiveTab(Tab tab)
		{
			var i = Tabs.IndexOf(tab);
			SetActiveTab(i);
		}
	}
}