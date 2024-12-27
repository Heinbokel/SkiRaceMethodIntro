using System.Text;

/// <summary>
/// Class which encapsulates the logic for processing ski races.
/// </summary>
public class SkiRaceProcessor {
    // Value for how much the height/distance effects a race's rating.
    public int DifficultyModifier {get; set;}

    // List to hold all of our entered race stats - instantiated to an empty collection.
    private List<RaceStats> RaceStats = [];

    /// <summary>
    /// Adds a new race stat to our list, calculating the rating within this method.
    /// </summary>
    /// <param name="skiRacer">The skiier who raced.</param>
    /// <param name="skiRun">The run the race took place on.</param>
    /// <param name="raceTime">The time taken to complete the race.</param>
    public void AddRaceStat(SkiRacer skiRacer, SkiRun skiRun, double raceTime) {
        // Generate a new RaceStats instance using the passed in data.
        RaceStats raceStats = new RaceStats{
            SkiRacer = skiRacer,
            SkiRun = skiRun,
            RaceTime = raceTime
        };
        
        // Calculate the new race stat's rating field.
        raceStats.Rating = this.CalculateRatingOutOfTen(raceStats);

        // Add the new race stat's to our list of race stats.
        this.RaceStats.Add(raceStats);
    }

    /// <summary>
    /// Calculates a rating, out of ten, for the given race stats.
    /// </summary>
    /// <param name="raceStats">The race stats to determine a score from.</param>
    /// <returns>Returns a rating out of 10, as a double, with 2 decimal points.</returns>
    private double CalculateRatingOutOfTen(RaceStats raceStats) {
        // Extract values from race stats.
        double raceTime = raceStats.RaceTime;
        double runHeight = raceStats.SkiRun.RunHeight;
        double runDistance = raceStats.SkiRun.RunDistance;

        // Step 1: Calculate a difficulty factor based on height and distance.
        double difficultyFactor = runHeight + (runDistance / this.DifficultyModifier);

        // Step 2: Adjust the race time by dividing it by the difficulty factor.
        double adjustedTime = raceTime / difficultyFactor;

        // Step 3: Convert the adjusted time into a rating out of 10.
        double rating = 10 - adjustedTime;

        // Step 4: Ensure the rating is between 1 and 10.
        rating = Math.Max(1, Math.Min(10, rating));

        // Step 5: Round the result to 2 decimal places and return it.
        return Math.Round(rating, 2);
    }

    /// <summary>
    /// Generates a ski race report for all ski races currently recorded.
    /// </summary>
    /// <returns>The report as a String.</returns>
    public string GenerateReport() {
        if (!RaceStats.Any()) {
            return "No race statistics available.";
        }

        var reportBuilder = new StringBuilder();
        reportBuilder.AppendLine("Ski Race Report:");
        reportBuilder.AppendLine("----------------");

        foreach (var stat in RaceStats) {
            reportBuilder.AppendLine(FormatRaceStats(stat));
        }

        return reportBuilder.ToString();
    }

    /// <summary>
    /// Generates a ski race report for a specific racer by their ID.
    /// </summary>
    /// <param name="racerID">The ID of the racer to filter by.</param>
    /// <returns>The filtered report as a String.</returns>
    public string GenerateReport(int racerID) {
        List<RaceStats> filteredStats = RaceStats
            .Where(stat => stat.SkiRacer.SkiRacerID == racerID)
            .ToList();

        if (!filteredStats.Any()) {
            return $"No race statistics available for racer with ID {racerID}.";
        }

        var reportBuilder = new StringBuilder();
        reportBuilder.AppendLine($"Ski Race Report for Racer {racerID}:");
        reportBuilder.AppendLine("----------------");

        foreach (var stat in filteredStats) {
            reportBuilder.AppendLine(FormatRaceStats(stat));
        }

        return reportBuilder.ToString();
    }

    /// <summary>
    /// Generates the race stats portion of the ski race report.
    /// </summary>
    /// <param name="stat">The race stats to format into a report.</param>
    /// <returns>Returns the race stats portion of the ski race report as a String.</returns>
    private static string FormatRaceStats(RaceStats stat) {
        var sb = new StringBuilder();
        sb.AppendLine($"Racer {stat.SkiRacer.SkiRacerID}: {stat.SkiRacer.FirstName} {stat.SkiRacer.LastName} - {stat.SkiRun.RunName}");
        sb.AppendLine($"  Race Time: {stat.RaceTime}s");
        sb.AppendLine($"  Rating: {stat.Rating}/10");
        return sb.ToString();
    }

}