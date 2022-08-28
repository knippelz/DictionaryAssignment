Dictionary Assignment

We have provided you with a file containing a list of words (dictionary.txt), the objective of this assignment is to find all six-letter words that are built of two concatenated smaller words, for example:
how + let => howlet
iris + in => irisin
in + door => indoor

Requirements
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






