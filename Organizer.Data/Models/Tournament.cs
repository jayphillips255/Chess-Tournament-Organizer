using IntelliTect.Coalesce.Api;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.Data.Models;

public class Tournament
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string TournamentId { get; init; } = null!;
    public required string Name { get; set; }
    [InverseProperty(nameof(Player.Tournament))]
    public ICollection<Player> Players { get; set; } = [];
    public required Type Type { get; set; }
    public required DateTime DateTime { get; set; }
    public int CurrentRound { get; set; } = 1;
}

public enum Type
{
    Swiss,
    SingleElimination,
    RoundRobin
}
