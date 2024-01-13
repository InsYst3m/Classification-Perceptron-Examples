using FirstNumberClassification;

Console.WriteLine("First Number Classification.");

double[][] trainingCases =
[
	[0, 1, 1],
	[0, 1, 0],
	[1, 0, 0],
	[1, 1, 0]
];

double[] expectedResults = [0, 0, 1, 1];

Perceptron perceptron = new();

perceptron.Train(trainingCases, expectedResults);

double[][] casesToRun =
[
	[1, 1, 1],
	[0, 1, 1],
	[1, 0, 0],
	[0, 1, 0]
];

double[] expectedCaseResults = [1, 0, 1, 0];

for (int i = 0; i < casesToRun.Length; i++)
{
	double caseResult = perceptron.Run(casesToRun[i]);

	Console.WriteLine($"Perceptron input: [{string.Join(", ", casesToRun[i])}]");
	Console.WriteLine($"Perceptron result: {caseResult}");
	Console.WriteLine($"Expected result: {expectedCaseResults[i]}");
	Console.WriteLine("***************************");
}
