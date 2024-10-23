# Cohere.NET

**Cohere.NET** provides a simple interface for interacting with the [Cohere API](https://cohere.com), enabling developers to integrate state-of-the-art language models into their .NET applications.

## Installation

You can install the SDK via NuGet:

```bash
dotnet add package CohereDotnet
```

Or in the Package Manager:

```bash
Install-Package CohereDotnet
```

## Getting Started

1. **API Key**: Sign up at [Cohere](https://cohere.com) to get your API key.

2. **Initialize the Client**:

    ```csharp
    using Cohere;
    using Cohere.Models;

    var apiKey = "your-api-key";
    var cohereClient = new CohereClient(apiKey);
    ```

3. **Example Usage**:

- **Generate Text**:

    ```csharp
    var response = await cohereClient.ChatAsync(new GenerateRequest
    {
        Messages = [
            {
                "role": "user",
                "content": "hello world!"
            }
        ]
        MaxTokens = 50
    });
    Console.WriteLine(response.FinishReason);
    ```

- **Classify Text**:

    ```csharp
    var response = await cohereClient.ClassifyAsync(new ClassifyRequest
    {
        Examples = new List<(string text, string label)>
        {
            (text="Dermatologists don't like her!", label="Spam"),
            (text="'Hello, open to this?'", label="Spam"),
            (text="Your parcel will be delivered today", label="Not spam"),
            (text="Review changes to our Terms and Conditions", label="Not spam"),
        };
        Inputs = new List<string>
        {
            "Confirm your email address",
            "hey i need u to send some $"
        };
    });
    Console.WriteLine(response.Classifications.First().Prediction);
    ```

- **Rerank Text**:

    ```csharp
    var response = await cohereClient.RerankAsync(new RerankRequest
    {
        Query = "What is the capital of the United States?"
        Documents = new List<string>
        {
            "Carson City is the capital city of the American state of Nevada.",
            "The Commonwealth of the Northern Mariana Islands is a group of islands in the Pacific Ocean. Its capital is Saipan.",
            "Capitalization or capitalisation in English grammar is the use of a capital letter at the start of a word. English usage varies from capitalization in other languages.",
            "Washington, D.C. (also known as simply Washington or D.C., and officially as the District of Columbia) is the capital of the United States. It is a federal district.",
            "Capital punishment (the death penalty) has existed in the United States since beforethe United States was a country. As of 2017, capital punishment is legal in 30 of the 50 states.",
        }
    });
    foreach (var result in Results)
    {
        Console.WriteLine(result.ToString());
    }
    ```

## Documentation

For full documentation, please refer to the [Cohere API Docs](https://docs.cohere.com/).

## Contributing

Contributions are welcome! Please open an issue or submit a pull request if you would like to contribute to the SDK.

## License

This project is licensed under the MIT License. See the [LICENSE](./LICENSE) file for more information.

---

This README provides a quick overview, installation instructions, basic examples, and links to full documentation, making it easy to get started with the Cohere CSharp SDK.
