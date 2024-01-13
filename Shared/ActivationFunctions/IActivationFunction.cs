namespace Shared.ActivationFunctions;

/// <summary>
/// Describes base interface for the activation functions.
/// </summary>
public interface IActivationFunction
{
	/// <summary>
	/// Runs activation function to normalize neuron result (input value * weight value).
	/// </summary>
	/// <param name="neuronResult">The neuron calculation result.</param>
	/// <returns>
	/// Normalized result.
	/// </returns>
	double Activate(double neuronResult);
}
