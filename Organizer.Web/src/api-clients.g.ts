import * as $metadata from './metadata.g'
import * as $models from './models.g'
import { AxiosPromise, AxiosRequestConfig, ModelApiClient, ServiceApiClient, ItemResult, ListResult } from 'coalesce-vue/lib/api-client'

export class PlayerApiClient extends ModelApiClient<$models.Player> {
  constructor() { super($metadata.Player) }
}


export class TournamentApiClient extends ModelApiClient<$models.Tournament> {
  constructor() { super($metadata.Tournament) }
}


export class SecurityServiceApiClient extends ServiceApiClient<typeof $metadata.SecurityService> {
  constructor() { super($metadata.SecurityService) }
  public whoAmI($config?: AxiosRequestConfig): AxiosPromise<ItemResult<$models.UserInfo>> {
    const $method = this.$metadata.methods.whoAmI
    const $params =  {
    }
    return this.$invoke($method, $params, $config)
  }
  
}


export class TournamentServiceApiClient extends ServiceApiClient<typeof $metadata.TournamentService> {
  constructor() { super($metadata.TournamentService) }
  public getPlayerPairs(thisTournamentId: string | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<$models.PlayerPair[]>> {
    const $method = this.$metadata.methods.getPlayerPairs
    const $params =  {
      thisTournamentId,
    }
    return this.$invoke($method, $params, $config)
  }
  
  public updatePlayers(games: $models.Game[] | null, tournamentId: string | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<void>> {
    const $method = this.$metadata.methods.updatePlayers
    const $params =  {
      games,
      tournamentId,
    }
    return this.$invoke($method, $params, $config)
  }
  
}


