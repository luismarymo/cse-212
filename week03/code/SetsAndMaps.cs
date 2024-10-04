using System.Text.Json;
using Microsoft.VisualBasic;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        //store the list of words in a set
        var wordsSet = new HashSet<string>(words);

        //create a list to store the symmetric words
        var symmetricList = new List<string>();

        //iterate through the strings in the set
        foreach (string word in wordsSet)
        {
            if (word[0] == word[1])
            {
                continue; //if the letters are the same, skip
            }

            //reverse the string to search for it in the set
            string reversed = string.Join("", word[1], word[0]);
            if (wordsSet.Contains(reversed))
            {
                //add to list of symmetric words and remove it from set
                //to avoid duplicates
                symmetricList.Add($"{string.Join(" & ", reversed, word)}");
                wordsSet.Remove(reversed);
            }
        }

        //return the list as array
        return symmetricList.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE

            if (degrees.ContainsKey(fields[3])) {
                degrees[fields[3]]++;
            }
            else {
                degrees[fields[3]] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        //create dictionary to store the characters
        //where the key is the character and the value
        //a list with two ints, to count for how many times
        //there's a certain letter in each word
        var wordDict = new Dictionary<char,List<int>>();

        // convert all letters in the string to lowercase
        word1 = word1.ToLower();
        word2 = word2.ToLower();

        foreach (char letter in word1)
        {
            if (letter == ' ') 
            {
                continue; //ignore spaces
            }

            if (wordDict.ContainsKey(letter)) 
            {
                wordDict[letter][0]++; //letter has been seen before
            }
            else {
                wordDict.Add(letter, [1]); //new letter, add to dictionary
            }
        }

        foreach (char letter in word2)
        {
            if (letter == ' ')
            {
                continue; //ignore spaces
            }

            if (!wordDict.ContainsKey(letter))
            {
                //the character is not in the first word
                //not an anagram
                return false;
            }

            if (wordDict[letter].Count == 1)
            {
                //if there is only one item in the list of the char
                //add an item to list to start counting for repetitions in word2
                wordDict[letter].Add(1); 
            }
            else {
                wordDict[letter][1]++; //letter has been seen before in word2
            }
        }

        foreach (var letter in wordDict)
        {
            if (letter.Value[0] != letter.Value[1]) //check for how many of one letter is in both words
            {
                return false; //the amount of letters in one word is not the same, not an anagram
            }
        }

        //all letters matched, so it is an anagram
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.

        //list to store the strings with earthquake descriptions
        var descriptions = new List<string>();

        //loop through the features and add the string descriptions
        foreach (var earthquake in featureCollection.Features) {
            descriptions.Add($"{earthquake.Properties.Place} - Mag {earthquake.Properties.Mag}");
        }

        //return the list as an array
        return descriptions.ToArray();
    }
}