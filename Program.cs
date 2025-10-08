// Jaden Olvera, 10-7-25, Lab 6: Madlibs #1
Console.Clear();
Console.Title = "Mad Libs: Console Edition!";
Console.WriteLine("Welcome to Mad Libs!\nWe'll take words like adjectives or nouns from you,\nthen use them to make a funny story!");
string originalStory = "A vacation is when you take a trip to some (adjective) place with your (adjective) family. Usually, you go to some place that is near (noun) or up on (noun). A good vacation place is one where you can ride (plural noun) or play (game) or go hunting for (plural noun). I like to spend my time (verb ending in “ing”) or (verb ending in “ing”). When parents go on a vacation, they spend their time eating three (plural noun) a day, and fathers play golf, and mothers sit around (verb ending in “ing”). Last summer, my little brother fell in (noun) and got poison (plant) all over his (part of the body). My family is going to go to (place) and I will practice (verb ending in “ing”). Parents need vacations more than kids because parents are always very (adjective) because they have to work (number) hours every day all year making enough (plural noun) to pay for the vacation.";
string[] storyWords = originalStory.Split(' ');
string newStory = "";
for (int index = 0; index < storyWords.GetLength(0); index++)
{
    // If the word starts with a parenthesis, we want to replace it with a user input
    if (storyWords[index][0] == '(')
    {
        // Start off with a string that matches the current index
        string wordToReplace = storyWords[index];
        bool searchingForParenthesis = true;

        // If the word that has the parenthesis contains the closing parenthesis, we don't have to look further
        for (int letter = 0; searchingForParenthesis == true && letter < storyWords[index].Length; letter++)
            if (storyWords[index][letter] == ')')
                searchingForParenthesis = false;

        // If we didn't find the closing parenthesis in the first word, we need to search later indices for it
        if (searchingForParenthesis == true)
        {
            // Start at the next index and look until we aren't searching anymore
            for (int indexToSearch = index + 1; searchingForParenthesis == true; indexToSearch++)
            {
                // Even if the current index doesn't contain the closing parenthesis
                // we want it to be added to the string we'll ask the user to replace later
                wordToReplace = wordToReplace + " " + storyWords[indexToSearch];

                // Looking through the current index and setting the searching flag to false if we find it
                for (int letter = 0; letter < storyWords[indexToSearch].Length; letter++)
                    if (storyWords[indexToSearch][letter] == ')')
                    {
                        searchingForParenthesis = false;
                    }

                // Need to set the index the top level loop is looking at so it doesn't check indices we're going to replace
                index = indexToSearch;
            }
        }
        // If the string we're replacing has a period at the end, we'll want it on the user's string too
        bool periodNeeded = false;
        if (wordToReplace[^1] == '.')
        {
            wordToReplace = wordToReplace.Trim('.');
            periodNeeded = true;
        }
        // Keep track if the string we're replacing needs "a" or "an" before it
        bool articleNeeded = false;
        if (wordToReplace == "(noun)")
            articleNeeded = true;

        // Trim off the parenthesis we worked so hard to find, so it looks nicer when we prompt the user
        wordToReplace = wordToReplace.Trim('(', ')');

        // Check if the string we're replacing starts with a vowel so we can use the proper "an" or "a"
        // Then print the prompt to the user for the string we'll use for the new story
        if (wordToReplace[0] == 'a' || wordToReplace[0] == 'e' || wordToReplace[0] == 'i' || wordToReplace[0] == 'o' || wordToReplace[0] == 'u')
            Console.Write($"\nPlease give me an {wordToReplace}: ");
        else
            Console.Write($"\nPlease give me a {wordToReplace}: ");
        string wordToInsert = Console.ReadLine().Trim(' ');

        // If the user just hits enter, the program crashes because it checks indices that don't exist
        // so we can fall back to this instead
        if (wordToInsert == "")
            wordToInsert = "pobber";

        // Adding the indefinite article if it needs one
        if (articleNeeded == true)
            if (wordToInsert[0] == 'a' || wordToInsert[0] == 'e' || wordToInsert[0] == 'i' || wordToInsert[0] == 'o' || wordToInsert[0] == 'u')
                newStory += " an";
            else
                newStory += " a";

        newStory = newStory + " " + wordToInsert;

        //Adding a period on the end if it needs one
        if (periodNeeded == true)
        {
            newStory += ".";
        }
    }
    else newStory = newStory + " " + storyWords[index];
}
Console.Clear();
Console.WriteLine("Here's your amazing Mad Lib! What a work of art!");
Console.WriteLine($"\n{newStory}");