// Instantiate a new SkiRaceProcessor instance with the Difficulty Modifier set to 10 (just an arbitrary number to test with).
SkiRaceProcessor processor = new SkiRaceProcessor{DifficultyModifier = 10};

// Create ski runs
SkiRun snowyRidge = new SkiRun { SkiRunID = 1, RunName = "Snowy Ridge", RunHeight = 200.5, RunDistance = 1200.75 };
SkiRun alpineBlast = new SkiRun { SkiRunID = 2, RunName = "Alpine Blast", RunHeight = 300.8, RunDistance = 1500.25 };
SkiRun glacierPeak = new SkiRun { SkiRunID = 3, RunName = "Glacier Peak", RunHeight = 100.0, RunDistance = 800.4 };
SkiRun frostbiteValley = new SkiRun { SkiRunID = 4, RunName = "Frostbite Valley", RunHeight = 250.3, RunDistance = 1100.5 };

// Create ski racers
SkiRacer johnDoe = new SkiRacer { SkiRacerID = 1, FirstName = "John", LastName = "Doe" };
SkiRacer janeSmith = new SkiRacer { SkiRacerID = 2, FirstName = "Jane", LastName = "Smith" };
SkiRacer alexBrown = new SkiRacer { SkiRacerID = 3, FirstName = "Alex", LastName = "Brown" };
SkiRacer taylorJohnson = new SkiRacer { SkiRacerID = 4, FirstName = "Taylor", LastName = "Johnson" };
SkiRacer chrisDavis = new SkiRacer { SkiRacerID = 5, FirstName = "Chris", LastName = "Davis" };

// Add race stats with varying performance. Paremeters are SkiRacer, SkiRun, double (race time).
processor.AddRaceStat(johnDoe, snowyRidge, 45.2);       
processor.AddRaceStat(janeSmith, alpineBlast, 82.7);    
processor.AddRaceStat(alexBrown, glacierPeak, 150.3);   
processor.AddRaceStat(taylorJohnson, frostbiteValley, 60.8); 
processor.AddRaceStat(chrisDavis, snowyRidge, 300.5);   
processor.AddRaceStat(johnDoe, alpineBlast, 75.5);      
processor.AddRaceStat(janeSmith, frostbiteValley, 55.6); 
processor.AddRaceStat(taylorJohnson, glacierPeak, 200.0); 

// Generate and display the report for all runs/racers.
string report = processor.GenerateReport();
Console.WriteLine(report);

// Generate and display the report for just the racer with ID 1.
Console.WriteLine(processor.GenerateReport(1));