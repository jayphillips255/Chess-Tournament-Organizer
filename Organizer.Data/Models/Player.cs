using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.Data.Models;


public class Player
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string PlayerId { get; init; } = null!;
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Rating { get; set; } = null;
    public double Score { get; set; } = 0;
    public int NumGamesAsBlack { get; set; } = 0;
    public int NumGamesAsWhite { get; set; } = 0;
    public List<Player> PastOpponents { get; set; } = [];
    public bool ReceivedFullPointBye {  get; set; } = false;
    public bool HasHalfPointBye { get; set; } = false;
    [Required]
    public string TournamentId { get; set; } = null!;
    public Tournament? Tournament { get; set; }
}
