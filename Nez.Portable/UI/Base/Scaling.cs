namespace Nez.UI
{
	public enum Scaling
	{
		/// <summary>
		/// Scales the source to fit the target while keeping the same aspect ratio. This may cause the source to be smaller than the
		/// target in one direction
		/// </summary>
		Fit,

		/// <summary>
		/// Scales the source to fill the target while keeping the same aspect ratio. This may cause the source to be larger than the
		/// target in one direction.
		/// </summary>
		Fill,

		/// <summary>
		/// Scales the source to fill the target in the x direction while keeping the same aspect ratio. This may cause the source to be
		/// smaller or larger than the target in the y direction.
		/// </summary>
		FillX,

		/// <summary>
		/// Scales the source to fill the target in the y direction while keeping the same aspect ratio. This may cause the source to be
		/// smaller or larger than the target in the x direction.
		/// </summary>
		FillY,

		/// <summary>
		/// Scales the source to fill the target. This may cause the source to not keep the same aspect ratio.
		/// </summary>
		Stretch,

		/// <summary>
		/// Scales the source to fill the target in the x direction, without changing the y direction. This may cause the source to not
		/// keep the same aspect ratio.
		/// </summary>
		StretchX,

		/// <summary>
		/// Scales the source to fill the target in the y direction, without changing the x direction. This may cause the source to not
		/// keep the same aspect ratio.
		/// </summary>
		StretchY,

		/// <summary>
		/// The source is not scaled.
		/// </summary>
		None
	}
}