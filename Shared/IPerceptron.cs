namespace Shared;

/// <summary>
/// Describes methods for the simple perceptron neural network.
/// </summary>
public interface IPerceptron
{
	/// <summary>
	/// Runs perceptron to get classification result.
	/// </summary>
	/// <param name="caseInput">The input case to classify.</param>
	/// <returns>
	/// Perceptron classification result.
	/// </returns>
	double Run(double[] caseInput);

	/// <summary>
	/// Trains perceptron neural network.
	/// </summary>
	/// <param name="trainCaseInput">The input case to train neural network.</param>
	/// <param name="expectedCaseResult">The expected result for the provided input case to calculate error.</param>
	void Train(double[][] trainCaseInput, double[] expectedCaseResult);
}
