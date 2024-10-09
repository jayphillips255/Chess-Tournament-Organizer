using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organizer.Data.Models;

namespace Organizer.Data.Services;
 
[Coalesce, Service]
public interface ITournamentService
{
    public enum OutcomeType
    {
        BlackWon,
        WhiteWon,
        Draw
    }
    public class PlayerPair
    {
        public Player? Black { get; set; }
        public Player? White { get; set; }
        public OutcomeType? Outcome { get; set; }
    }

    public class Game 
    {
        public string? BlackId { get; set; }
        public string? WhiteId { get; set; }
        public OutcomeType Outcome { get; set; }
    }

    PlayerPair[] GetPlayerPairs(string ThisTournamentId);

    void UpdatePlayers(Game[] games, string tournamentId);
}

// Source: https://stackoverflow.com/questions/108819/best-way-to-randomize-an-array-with-net
static class RandomExtensions
{
    public static void Shuffle<T>(this Random rng, T[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = rng.Next(n--);
            (array[k], array[n]) = (array[n], array[k]);
        }
    }
}
