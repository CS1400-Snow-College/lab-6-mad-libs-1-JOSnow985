// Jaden Olvera, 10-7-25, Lab 6: Madlibs #1
Console.Clear();
Console.Title = "Mad Libs: Console Edition!";
Console.WriteLine("Welcome to Mad Libs!\nWe'll take words like adjectives or nouns from you,\nthen use them to make a funny story!");
string originalStory = "A vacation is when you take a trip to some (adjective) place with your (adjective) family. Usually, you go to some place that is near a/an (noun) or up on a/an (noun). A good vacation place is one where you can ride (plural noun) or play (game) or go hunting for (plural noun). I like to spend my time (verb ending in “ing”) or (verb ending in “ing”). When parents go on a vacation, they spend their time eating three (plural noun) a day, and fathers play golf, and mothers sit around (verb ending in “ing”) Last summer, my little brother fell in a/an (noun) and got poison (plant) all over his (part of the body) My family is going to go to (place) and I will practice (verb ending in “ing”) Parents need vacations more than kids because parents are always very (adjective) and because they have to work (number) hours every day all year making enough (plural noun) to pay for the vacation.";
string[] storyWords = originalStory.Split(' ');
string newStory = "";
for (int index = 0; index < storyWords.GetLength(0); index++)
{
    // If the word starts with a parenthesis, we want to replace it with a user input
    if (storyWords[index][0] == '(')
    {
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
        // Trim off the parenthesis we worked so hard to find, so it looks nicer when we prompt the user
        wordToReplace = wordToReplace.Trim('(', ')');
        Console.Write($"\nPlease give me a/an {wordToReplace}: ");
        string wordToInsert = Console.ReadLine().Trim(' ');
        newStory = newStory + " " + wordToInsert;
    }
    else newStory = newStory + " " + storyWords[index];
}