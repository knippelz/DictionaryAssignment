# Dictionary Assignment

## How to Run This Assignment
1. Download the project from GitHub ([link here](https://github.com/tinyeye-zach/DictionaryAssignment.git))
2. Ensure that .NET 6.0 is installed ([link here](https://dotnet.microsoft.com/en-us/download/dotnet/6.0))
3. In Powershell (or your preferred terminal) navigate to the project directory
4. Enter the command ```dotnet build``` to build the project
5. Once the project is built, use the command ```dotnet run --project .\DictionaryAssignment\DictionaryAssignment.csproj``` to run it
6. If you want to input a target length parameter, add the target length (as a number) after at the end of the run command.
   - For example, if you want a target length of 4, then use ```dotnet run --project .\DictionaryAssignment\DictionaryAssignment.csproj 4```

## Highlighting some areas I need to improve on
I'm still learning C# and this was my first time using .NET. It would love to these tools - but as this is my first time and I'll highlight some areas where I know I struggled. I honestly was using Powershell and VS Code for most of this project, and didn't find the difference between VS Code and Visual Studio until I was reviewing a tutorial on unit testing at the end.
- Unit tests shouldn't be relying on the First() or Last() function of the list. I was struggling to get the correct comparison tools identified and installed in time, so I need to identify those in the future.
- Target Length Parameter - I'm not a big fan of the args[0] method I used. I heard of a few libraries such as commandlineparser at the end of this assignment, but wanted to see what was available without using external libraries.

## Assignment Description (provided by Mark Hollman)

We have provided you with a file containing a list of words (dictionary.txt), the objective of this assignment is to find all six-letter words that are built of two concatenated smaller words, for example:
how + let => howlet
iris + in => irisin
in + door => indoor

### Requirements
Using either C# or VB.net and .Net framework 4.5+ or .net 5+ write a console application that fulfills the following requirements:

Find 6 Letter Composite Words
Find all combinations of words which can be concatenated together to form a 6-letter word.

Output Format
The application should output all results to the console window and what words were used to construct the word in the following format:
{word_part_1} + {word_part_2} => {word}
For example:
how + let => howlet

Output Order
The output should be ordered alphabetically by the resulting word, and if multiple matches are found for the word, then the length of the first word should be used to order the results, for example:
how + let => howlet
howl + et => howlet
iris + in => irisin

Optional additions
The following are additional requirements which you may be asked to add to meet, if you are not explicitly asked to meet these requirements you may still do any you wish to, but are not obliged to do so:

Unit Tests
Provide a suite of unit tests to prove the validity of the application logic.

Target Length Parameter
Add support for a length parameter to be passed into the application which will override the default 6-character length.
 
Performance enhancements
Identify performance bottle necks and implement improvements to reduce the runtime. Document the bottlenecks you identify and the solution you implemented.


