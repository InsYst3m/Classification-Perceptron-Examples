namespace Shared.ActivationFunctions;

/// <summary>
/// Provides implementation for the Hard Limit activation function.
/// </summary>
/// <remarks>
/// The Hard Limit function means that if the neuron's result is lower than or equal to 0, then 0 is returned, otherwise 1.
/// </remarks>
public sealed class HardLimitActivationFunction : IActivationFunction
{
	/// <summary>
	/// Runs activation function to normalize neuron result (input value * weight value).
	/// </summary>
	/// <param name="neuronResult">The neuron calculation result.</param>
	/// <returns>
	/// Normalized result.
	/// </returns>
	public double Activate(double neuronResult)
	{
		return neuronResult <= 0 ? 0 : 1;
	}
}
