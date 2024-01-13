using Shared;
using Shared.ActivationFunctions;

namespace FirstNumberClassification;

/// <summary>
/// Provides methods for the simple perceptron neural network.
/// </summary>
/// <remarks>
/// Task: Given 3 numbers, the result of which must be the first number.
/// Example:
/// 1 0 1 = 1
/// 1 1 1 = 1
/// 1 0 0 = 1
/// 0 0 1 = 0
/// 0 1 1 = 0
/// </remarks>
/// <seealso cref="IPerceptron"/>
internal sealed class Perceptron : IPerceptron
{
	#region Constants

	private const int NUMBER_OF_NEURONS = 3;
	private const int NUMBER_OF_ITERATIONS = 50;

	/// <summary>
	/// The lower the number, the more accurate the classification result will be,
	/// which in turn leads to the need for more train cases to train the neural network.
	/// </summary>
	private const double LEARNING_RATE = 0.1;

	#endregion

	/// <inheritdoc cref="IActivationFunction" />
	private readonly IActivationFunction _activationFunction;

	/// <summary>
	/// Contains weights that will be used in the classification process.
	/// </summary>
	private readonly double[] _weiths;

	public Perceptron()
	{
		_activationFunction = new HardLimitActivationFunction();

		_weiths = new double[NUMBER_OF_NEURONS];
	}

	/// <inheritdoc />
	public double Run(double[] caseInput)
	{
		double result = 0;

		for (int index = 0; index < _weiths.Length; index++)
		{
			result += caseInput[index] * _weiths[index];
		}

		return _activationFunction.Activate(result);
	}

	/// <inheritdoc />
	public void Train(double[][] trainCases, double[] expectedCaseResult)
	{
		for (int iterationIndex = 0; iterationIndex < NUMBER_OF_ITERATIONS; iterationIndex++)
		{
			BalanceTrainCases(trainCases, expectedCaseResult);
		}
	}

	#region Private Members

	/// <summary>
	/// Goes through each train case <paramref name="trainCases"/> to rebalance existed weights <see cref="_weiths"/>.
	/// </summary>
	/// <param name="trainCases">The array with the train cases.</param>
	/// <param name="expectedCaseResult">The array with the expected results for the particular train case.</param>
	private void BalanceTrainCases(double[][] trainCases, double[] expectedCaseResult)
	{
		for (int caseIndex = 0; caseIndex < trainCases.Length; caseIndex++)
		{
			BalanceWeights(trainCases[caseIndex], expectedCaseResult[caseIndex]);
		}
	}

	/// <summary>
	/// Balances weights according to the provided train case <paramref name="trainCase"/>.
	/// </summary>
	/// <param name="trainCase">The train case.</param>
	/// <param name="expectedCaseResult">The expected result of the provided train case.</param>
	private void BalanceWeights(double[] trainCase, double expectedCaseResult)
	{
		double caseResult = Run(trainCase);
		double error = expectedCaseResult - caseResult;

		for (int weightIndex = 0; weightIndex < _weiths.Length; weightIndex++)
		{
			_weiths[weightIndex] = _weiths[weightIndex] + (LEARNING_RATE * error * trainCase[weightIndex]);
		}
	}

	#endregion
}
