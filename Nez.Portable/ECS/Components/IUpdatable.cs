﻿namespace Nez
{
	/// <summary>
	/// interface that when added to a Component lets Nez know that it wants the update method called each frame as long as the Component
	/// and Entity are enabled.
	/// </summary>
	public interface IUpdatable
	{
		bool Enabled { get; }
		int UpdateOrder { get; }

		void Update();
	}
}