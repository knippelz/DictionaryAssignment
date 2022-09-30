dotnet build
$local = Get-Location
dotnet run --project .\DictionaryAssignment\DictionaryAssignment.csproj $local\dictionary.txt $local\output.txt