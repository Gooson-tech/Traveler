namespace Nez
{
	public enum CoreEvents
	{
		/// <summary>
		/// fired when the graphics device resets. When this happens, any RenderTargets or other contents of VRAM will be wiped and need
		/// to be regenerated
		/// </summary>
		GraphicsDeviceReset,

		/// <summary>
		/// fired when the scene changes
		/// </summary>
		SceneChanged,

		/// <summary>
		/// fired when the device orientation changes
		/// </summary>
		OrientationChanged,

		/// <summary>
		/// fired when the game is exiting
		/// </summary>
		Exiting
	}
}