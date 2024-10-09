import * as metadata from './metadata.g'
import { Model, DataSource, convertToModel, mapToModel, reactiveDataSource } from 'coalesce-vue/lib/model'

export enum OutcomeType {
  BlackWon = 0,
  WhiteWon = 1,
  Draw = 2,
}


export enum Type {
  Swiss = 0,
  SingleElimination = 1,
  RoundRobin = 2,
}


export interface Player extends Model<typeof metadata.Player> {
  playerId: string | null
  firstName: string | null
  lastName: string | null
  rating: string | null
  score: number | null
  numGamesAsBlack: number | null
  numGamesAsWhite: number | null
  pastOpponents: Player[] | null
  receivedFullPointBye: boolean | null
  hasHalfPointBye: boolean | null
  tournamentId: string | null
  tournament: Tournament | null
}
export class Player {
  
  /** Mutates the input object and its descendents into a valid Player implementation. */
  static convert(data?: Partial<Player>): Player {
    return convertToModel(data || {}, metadata.Player) 
  }
  
  /** Maps the input object and its descendents to a new, valid Player implementation. */
  static map(data?: Partial<Player>): Player {
    return mapToModel(data || {}, metadata.Player) 
  }
  
  static [Symbol.hasInstance](x: any) { return x?.$metadata === metadata.Player; }
  
  /** Instantiate a new Player, optionally basing it on the given data. */
  constructor(data?: Partial<Player> | {[k: string]: any}) {
    Object.assign(this, Player.map(data || {}));
  }
}


export interface Tournament extends Model<typeof metadata.Tournament> {
  tournamentId: string | null
  name: string | null
  players: Player[] | null
  type: Type | null
  dateTime: Date | null
  currentRound: number | null
}
export class Tournament {
  
  /** Mutates the input object and its descendents into a valid Tournament implementation. */
  static convert(data?: Partial<Tournament>): Tournament {
    return convertToModel(data || {}, metadata.Tournament) 
  }
  
  /** Maps the input object and its descendents to a new, valid Tournament implementation. */
  static map(data?: Partial<Tournament>): Tournament {
    return mapToModel(data || {}, metadata.Tournament) 
  }
  
  static [Symbol.hasInstance](x: any) { return x?.$metadata === metadata.Tournament; }
  
  /** Instantiate a new Tournament, optionally basing it on the given data. */
  constructor(data?: Partial<Tournament> | {[k: string]: any}) {
    Object.assign(this, Tournament.map(data || {}));
  }
}


export interface Game extends Model<typeof metadata.Game> {
  blackId: string | null
  whiteId: string | null
  outcome: OutcomeType | null
}
export class Game {
  
  /** Mutates the input object and its descendents into a valid Game implementation. */
  static convert(data?: Partial<Game>): Game {
    return convertToModel(data || {}, metadata.Game) 
  }
  
  /** Maps the input object and its descendents to a new, valid Game implementation. */
  static map(data?: Partial<Game>): Game {
    return mapToModel(data || {}, metadata.Game) 
  }
  
  static [Symbol.hasInstance](x: any) { return x?.$metadata === metadata.Game; }
  
  /** Instantiate a new Game, optionally basing it on the given data. */
  constructor(data?: Partial<Game> | {[k: string]: any}) {
    Object.assign(this, Game.map(data || {}));
  }
}


export interface PlayerPair extends Model<typeof metadata.PlayerPair> {
  black: Player | null
  white: Player | null
  outcome: OutcomeType | null
}
export class PlayerPair {
  
  /** Mutates the input object and its descendents into a valid PlayerPair implementation. */
  static convert(data?: Partial<PlayerPair>): PlayerPair {
    return convertToModel(data || {}, metadata.PlayerPair) 
  }
  
  /** Maps the input object and its descendents to a new, valid PlayerPair implementation. */
  static map(data?: Partial<PlayerPair>): PlayerPair {
    return mapToModel(data || {}, metadata.PlayerPair) 
  }
  
  static [Symbol.hasInstance](x: any) { return x?.$metadata === metadata.PlayerPair; }
  
  /** Instantiate a new PlayerPair, optionally basing it on the given data. */
  constructor(data?: Partial<PlayerPair> | {[k: string]: any}) {
    Object.assign(this, PlayerPair.map(data || {}));
  }
}


export interface UserInfo extends Model<typeof metadata.UserInfo> {
  id: string | null
  userName: string | null
}
export class UserInfo {
  
  /** Mutates the input object and its descendents into a valid UserInfo implementation. */
  static convert(data?: Partial<UserInfo>): UserInfo {
    return convertToModel(data || {}, metadata.UserInfo) 
  }
  
  /** Maps the input object and its descendents to a new, valid UserInfo implementation. */
  static map(data?: Partial<UserInfo>): UserInfo {
    return mapToModel(data || {}, metadata.UserInfo) 
  }
  
  static [Symbol.hasInstance](x: any) { return x?.$metadata === metadata.UserInfo; }
  
  /** Instantiate a new UserInfo, optionally basing it on the given data. */
  constructor(data?: Partial<UserInfo> | {[k: string]: any}) {
    Object.assign(this, UserInfo.map(data || {}));
  }
}


declare module "coalesce-vue/lib/model" {
  interface EnumTypeLookup {
    OutcomeType: OutcomeType
    Type: Type
  }
  interface ModelTypeLookup {
    Game: Game
    Player: Player
    PlayerPair: PlayerPair
    Tournament: Tournament
    UserInfo: UserInfo
  }
}
