# DeckOfCardsApi_Test_CSharp

The purpose for this project is to demonstrate API test automation on the Deck of Cards API in C#. You can find the API instructions on Deck of Cards here:
`http://deckofcardsapi.com`

The github repository for Deck of Cards API can also be found here:
`https://github.com/crobertsbmw/deckofcards`

**Test Dependencies**

Because this project was created using the Visual Studio IDE for a Standard .NET Test project, this should run on a system that can run .NET programs. 
At this time the project has been tested in a Windows 10 PC only.
Additional dependencies include:

- .NET 3.7
- Nunit3-console

**Test Details**

There are two Test Sets that will test the Deck of Cards API:

- DOCA_PositiveTests
- DOCA_NegativeTests

The positive set is geared towards a sanity check, just to verify if the API is running. This one contains 3 tests:

- CreateNewDeck
- CreateNewDeckWithJoker
- DrawCardsFromDeck

The negative test contains scenarios that are intended to make the application fail, so we can observe and inspect the results of the failures. These are the tests in this set:

- CreateDeckAndDrawZeroCards
- CreateDeckAndDrawAllCards
- CreateDeckAndOverDraw
- DrawCardsOnEmptyDeck
- InputInvalidCountValue

**Test Executions Instructions**

The tests on this project can be executed locally on a Windows 10 computer using command line instructions on a terminal. It requires NUnit3-Console to be installed in the system.
If you prefer, you can use an IDE you can use Visual Studio 2019 or later.

Command Line
1. Clone the project to a local directory in your Win 10 computer
2. Launch command line terminal as an Administrator
3. Navigate to the directory where NUnit3-console is installed (Usually C:\Program Files (x86)\NUnit.org\nunit-console>nunit3-console.exe)
4. Run the nunit3-console.exe program name followed by the directory location where the dll file for your CSharp project exists. c:\...\NUnit3-console\nunit3-console.exe c:\myCSharpSolution\ ..\myCSharpSolution.dll
5. The execution will yield pass/fail results on the tests

Visual Studio IDE 
1. Clone the project to a local directory in the computer that will run this test.
2. Launch Visual Studio
3. Select to open a Solution in the directory you cloned. Look for the SLN file
4. Build the project
5. Launch Test Explorer and run the tests you would like to excute.

**Note on failed test:**
 
The last test: InputInvalidCountValue is failing. The server is returning a 500 status code, and the Assert method cannot validate the condition set.
There is not enough info at this time to find out why the code is not able to handle the invalid input. The expected result on the test is that once a deck is created, 52 cards will exist, and because the Draw method should fail due to an invalid entry, the number of cards should remain at 52, and the Assert method should pass because of that. 
I will leave the failure to be recorded, and more research needs to be done when time permits. 
The research I would conduct to fix this issue includes:
1. Cloning the Deck of Cards Api project locally in my computer
2. Finding and fixing the code that throws the 500 code in this scenario
3. Forking the project for the approval process
4. Retesting when the changes make it to the Master repo  



