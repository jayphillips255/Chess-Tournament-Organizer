import * as $metadata from './metadata.g'
import * as $models from './models.g'
import * as $apiClients from './api-clients.g'
import { ViewModel, ListViewModel, ViewModelCollection, ServiceViewModel, DeepPartial, defineProps } from 'coalesce-vue/lib/viewmodel'

export interface PlayerViewModel extends $models.Player {
  playerId: string | null;
  firstName: string | null;
  lastName: string | null;
  rating: string | null;
  score: number | null;
  numGamesAsBlack: number | null;
  numGamesAsWhite: number | null;
  get pastOpponents(): ViewModelCollection<PlayerViewModel, $models.Player>;
  set pastOpponents(value: (PlayerViewModel | $models.Player)[] | null);
  receivedFullPointBye: boolean | null;
  hasHalfPointBye: boolean | null;
  tournamentId: string | null;
  get tournament(): TournamentViewModel | null;
  set tournament(value: TournamentViewModel | $models.Tournament | null);
}
export class PlayerViewModel extends ViewModel<$models.Player, $apiClients.PlayerApiClient, string> implements $models.Player  {
  
  constructor(initialData?: DeepPartial<$models.Player> | null) {
    super($metadata.Player, new $apiClients.PlayerApiClient(), initialData)
  }
}
defineProps(PlayerViewModel, $metadata.Player)

export class PlayerListViewModel extends ListViewModel<$models.Player, $apiClients.PlayerApiClient, PlayerViewModel> {
  
  constructor() {
    super($metadata.Player, new $apiClients.PlayerApiClient())
  }
}


export interface TournamentViewModel extends $models.Tournament {
  tournamentId: string | null;
  name: string | null;
  get players(): ViewModelCollection<PlayerViewModel, $models.Player>;
  set players(value: (PlayerViewModel | $models.Player)[] | null);
  type: $models.Type | null;
  dateTime: Date | null;
  currentRound: number | null;
}
export class TournamentViewModel extends ViewModel<$models.Tournament, $apiClients.TournamentApiClient, string> implements $models.Tournament  {
  
  
  public addToPlayers(initialData?: DeepPartial<$models.Player> | null) {
    return this.$addChild('players', initialData) as PlayerViewModel
  }
  
  constructor(initialData?: DeepPartial<$models.Tournament> | null) {
    super($metadata.Tournament, new $apiClients.TournamentApiClient(), initialData)
  }
}
defineProps(TournamentViewModel, $metadata.Tournament)

export class TournamentListViewModel extends ListViewModel<$models.Tournament, $apiClients.TournamentApiClient, TournamentViewModel> {
  
  constructor() {
    super($metadata.Tournament, new $apiClients.TournamentApiClient())
  }
}


export class SecurityServiceViewModel extends ServiceViewModel<typeof $metadata.SecurityService, $apiClients.SecurityServiceApiClient> {
  
  public get whoAmI() {
    const whoAmI = this.$apiClient.$makeCaller(
      this.$metadata.methods.whoAmI,
      (c) => c.whoAmI(),
      () => ({}),
      (c, args) => c.whoAmI())
    
    Object.defineProperty(this, 'whoAmI', {value: whoAmI});
    return whoAmI
  }
  
  constructor() {
    super($metadata.SecurityService, new $apiClients.SecurityServiceApiClient())
  }
}


export class TournamentServiceViewModel extends ServiceViewModel<typeof $metadata.TournamentService, $apiClients.TournamentServiceApiClient> {
  
  public get getPlayerPairs() {
    const getPlayerPairs = this.$apiClient.$makeCaller(
      this.$metadata.methods.getPlayerPairs,
      (c, thisTournamentId: string | null) => c.getPlayerPairs(thisTournamentId),
      () => ({thisTournamentId: null as string | null, }),
      (c, args) => c.getPlayerPairs(args.thisTournamentId))
    
    Object.defineProperty(this, 'getPlayerPairs', {value: getPlayerPairs});
    return getPlayerPairs
  }
  
  public get updatePlayers() {
    const updatePlayers = this.$apiClient.$makeCaller(
      this.$metadata.methods.updatePlayers,
      (c, games: $models.Game[] | null, tournamentId: string | null) => c.updatePlayers(games, tournamentId),
      () => ({games: null as $models.Game[] | null, tournamentId: null as string | null, }),
      (c, args) => c.updatePlayers(args.games, args.tournamentId))
    
    Object.defineProperty(this, 'updatePlayers', {value: updatePlayers});
    return updatePlayers
  }
  
  constructor() {
    super($metadata.TournamentService, new $apiClients.TournamentServiceApiClient())
  }
}


const viewModelTypeLookup = ViewModel.typeLookup = {
  Player: PlayerViewModel,
  Tournament: TournamentViewModel,
}
const listViewModelTypeLookup = ListViewModel.typeLookup = {
  Player: PlayerListViewModel,
  Tournament: TournamentListViewModel,
}
const serviceViewModelTypeLookup = ServiceViewModel.typeLookup = {
  SecurityService: SecurityServiceViewModel,
  TournamentService: TournamentServiceViewModel,
}

