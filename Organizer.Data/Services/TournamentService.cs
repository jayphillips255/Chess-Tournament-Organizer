using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.JSInterop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organizer.Data.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Organizer.Data.Services.ITournamentService;

namespace Organizer.Data.Services;
public class TournamentService(AppDbContext db) : ITournamentService
{
    public PlayerPair[] GetPlayerPairs(string ThisTournamentId)
    {
        Tournament? thisTournament = db.Tournaments
            .FirstOrDefault(t => t.TournamentId == ThisTournamentId);
        Player[] players = [.. db.Players
            .Where(p => p.TournamentId == ThisTournamentId)
            .OrderByDescending(p => p.Score)];

        List<PlayerPair> pairs = [];
        List<Player> unpairedPlayers = [.. players];

        // Random pairings for first round
        if (thisTournament?.CurrentRound == 1)
        {
            var rng = new Random();
            rng.Shuffle(players);

            for (int i = 0; i < players.Length; i += 2)
            {
                if (i + 1 < players.Length)
                {
                    pairs.Add(new PlayerPair { Black = players[i], White = players[i + 1] });
                }
                else
                {
                    pairs.Add(new PlayerPair { Black = players[i], White = null });
                }
            }
        }
        // For rounds 2-End, pair by score. Avoid rematches if possible.
        // A player can recieve a full-point-bye only once.
        else
        {
            var playerScores = players
                .GroupBy(p => p.Score)
                .OrderByDescending(g => g.Key)
                .ToList();

            foreach (var group in playerScores)
            {
                for (int i = 0; i < group.Count(); i++)
                {
                    var player1 = group.ElementAt(i);
                    if (unpairedPlayers.Contains(player1))
                    {
                        var opponent = unpairedPlayers
                            .Where(p => p != player1 && !player1.PastOpponents.Contains(p))
                            .FirstOrDefault();

                        if (opponent != null)
                        {
                            pairs.Add(new PlayerPair { Black = player1, White = opponent });
                            unpairedPlayers.Remove(player1);
                            unpairedPlayers.Remove(opponent);
                        }
                    }
                }
            }
            while (unpairedPlayers.Count > 1)
            {
                var player1 = unpairedPlayers[0];
                Player? opponent = null;

                foreach (var group in playerScores)
                {
                    if (group.Any(p => p != player1 && !player1.PastOpponents.Contains(p)))
                    {
                        opponent = group
                            .Where(p => p != player1 && !player1.PastOpponents.Contains(p))
                            .FirstOrDefault();
                        if (opponent != null) break;
                    }
                }
                if (opponent == null)
                {
                    opponent = unpairedPlayers
                        .Where(p => p != player1)
                        .OrderBy(p => player1.PastOpponents.IndexOf(p)) // Least recent opponent
                        .FirstOrDefault();
                }
                if (opponent != null)
                {
                    pairs.Add(new PlayerPair { Black = player1, White = opponent });
                    unpairedPlayers.Remove(player1);
                    unpairedPlayers.Remove(opponent);
                }
            }
            if (unpairedPlayers.Count == 1)
            {
                var playerWithBye = unpairedPlayers[0];
                if (!playerWithBye.ReceivedFullPointBye)
                {
                    playerWithBye.ReceivedFullPointBye = true;
                    pairs.Add(new PlayerPair { Black = playerWithBye, White = null });
                }
            }
        }

        return [.. pairs];
    }


    public void UpdatePlayers(Game[] games, string tournamentId)
    {
        var thisTournament = db.Tournaments.FirstOrDefault(t => t.TournamentId == tournamentId);
        if (thisTournament != null) thisTournament.CurrentRound++;
        db.SaveChanges();

        foreach (var game in games)
        {
            var blackPlayer = game.BlackId != null
                ? db.Players.FirstOrDefault(p => p.PlayerId == game.BlackId)
                : null;
            var whitePlayer = game.WhiteId != null
                ? db.Players.FirstOrDefault(p => p.PlayerId == game.WhiteId)
                : null;

            // If White is null, Black is unpaired for the round.
            if (whitePlayer == null && blackPlayer != null)
            {
                if (blackPlayer.HasHalfPointBye)
                {
                    blackPlayer.HasHalfPointBye = false;
                    blackPlayer.Score += 0.5;
                }
                continue;
            }

            // If either player is null, skip this pair
            if (whitePlayer == null || blackPlayer == null)
            {
                continue;
            }
            else
            {
                switch (game.Outcome)
                {
                    case OutcomeType.WhiteWon:
                        whitePlayer.Score += 1.0;
                        break;

                    case OutcomeType.BlackWon:
                        blackPlayer.Score += 1.0;
                        break;

                    case OutcomeType.Draw:
                        blackPlayer.Score += 0.5;
                        whitePlayer.Score += 0.5;
                        break;
                }
                blackPlayer.NumGamesAsBlack += 1;
                whitePlayer.NumGamesAsWhite += 1;
                blackPlayer.PastOpponents.Add(whitePlayer);
                whitePlayer.PastOpponents.Add(blackPlayer);

                db.Players.Update(whitePlayer);
                db.Players.Update(blackPlayer);
                db.SaveChanges();
            }
        }
    }
}
