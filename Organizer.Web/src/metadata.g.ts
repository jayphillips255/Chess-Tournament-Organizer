import {
  Domain, getEnumMeta, solidify, ModelType, ObjectType,
  PrimitiveProperty, ForeignKeyProperty, PrimaryKeyProperty,
  ModelCollectionNavigationProperty, ModelReferenceNavigationProperty,
  HiddenAreas, BehaviorFlags
} from 'coalesce-vue/lib/metadata'


const domain: Domain = { enums: {}, types: {}, services: {} }
export const OutcomeType = domain.enums.OutcomeType = {
  name: "OutcomeType" as const,
  displayName: "Outcome Type",
  type: "enum",
  ...getEnumMeta<"BlackWon"|"WhiteWon"|"Draw">([
  {
    value: 0,
    strValue: "BlackWon",
    displayName: "Black Won",
  },
  {
    value: 1,
    strValue: "WhiteWon",
    displayName: "White Won",
  },
  {
    value: 2,
    strValue: "Draw",
    displayName: "Draw",
  },
  ]),
}
export const Type = domain.enums.Type = {
  name: "Type" as const,
  displayName: "Type",
  type: "enum",
  ...getEnumMeta<"Swiss"|"SingleElimination"|"RoundRobin">([
  {
    value: 0,
    strValue: "Swiss",
    displayName: "Swiss",
  },
  {
    value: 1,
    strValue: "SingleElimination",
    displayName: "Single Elimination",
  },
  {
    value: 2,
    strValue: "RoundRobin",
    displayName: "Round Robin",
  },
  ]),
}
export const Player = domain.types.Player = {
  name: "Player" as const,
  displayName: "Player",
  get displayProp() { return this.props.playerId }, 
  type: "model",
  controllerRoute: "Player",
  get keyProp() { return this.props.playerId }, 
  behaviorFlags: 7 as BehaviorFlags,
  props: {
    playerId: {
      name: "playerId",
      displayName: "Player Id",
      type: "string",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
      createOnly: true,
    },
    firstName: {
      name: "firstName",
      displayName: "First Name",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "First Name is required.",
      }
    },
    lastName: {
      name: "lastName",
      displayName: "Last Name",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Last Name is required.",
      }
    },
    rating: {
      name: "rating",
      displayName: "Rating",
      type: "string",
      role: "value",
    },
    score: {
      name: "score",
      displayName: "Score",
      type: "number",
      role: "value",
    },
    numGamesAsBlack: {
      name: "numGamesAsBlack",
      displayName: "Num Games As Black",
      type: "number",
      role: "value",
    },
    numGamesAsWhite: {
      name: "numGamesAsWhite",
      displayName: "Num Games As White",
      type: "number",
      role: "value",
    },
    pastOpponents: {
      name: "pastOpponents",
      displayName: "Past Opponents",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.Player as ModelType & { name: "Player" }) },
      },
      role: "value",
      dontSerialize: true,
    },
    receivedFullPointBye: {
      name: "receivedFullPointBye",
      displayName: "Received Full Point Bye",
      type: "boolean",
      role: "value",
    },
    hasHalfPointBye: {
      name: "hasHalfPointBye",
      displayName: "Has Half Point Bye",
      type: "boolean",
      role: "value",
    },
    tournamentId: {
      name: "tournamentId",
      displayName: "Tournament Id",
      type: "string",
      role: "foreignKey",
      get principalKey() { return (domain.types.Tournament as ModelType & { name: "Tournament" }).props.tournamentId as PrimaryKeyProperty },
      get principalType() { return (domain.types.Tournament as ModelType & { name: "Tournament" }) },
      get navigationProp() { return (domain.types.Player as ModelType & { name: "Player" }).props.tournament as ModelReferenceNavigationProperty },
      hidden: 3 as HiddenAreas,
      rules: {
        required: val => (val != null && val !== '') || "Tournament is required.",
      }
    },
    tournament: {
      name: "tournament",
      displayName: "Tournament",
      type: "model",
      get typeDef() { return (domain.types.Tournament as ModelType & { name: "Tournament" }) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.Player as ModelType & { name: "Player" }).props.tournamentId as ForeignKeyProperty },
      get principalKey() { return (domain.types.Tournament as ModelType & { name: "Tournament" }).props.tournamentId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.Tournament as ModelType & { name: "Tournament" }).props.players as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const Tournament = domain.types.Tournament = {
  name: "Tournament" as const,
  displayName: "Tournament",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "Tournament",
  get keyProp() { return this.props.tournamentId }, 
  behaviorFlags: 7 as BehaviorFlags,
  props: {
    tournamentId: {
      name: "tournamentId",
      displayName: "Tournament Id",
      type: "string",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
      createOnly: true,
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Name is required.",
      }
    },
    players: {
      name: "players",
      displayName: "Players",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.Player as ModelType & { name: "Player" }) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.Player as ModelType & { name: "Player" }).props.tournamentId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.Player as ModelType & { name: "Player" }).props.tournament as ModelReferenceNavigationProperty },
      dontSerialize: true,
    },
    type: {
      name: "type",
      displayName: "Type",
      type: "enum",
      get typeDef() { return Type },
      role: "value",
      rules: {
        required: val => val != null || "Type is required.",
      }
    },
    dateTime: {
      name: "dateTime",
      displayName: "Date Time",
      type: "date",
      dateKind: "datetime",
      noOffset: true,
      role: "value",
      rules: {
        required: val => val != null || "Date Time is required.",
      }
    },
    currentRound: {
      name: "currentRound",
      displayName: "Current Round",
      type: "number",
      role: "value",
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const Game = domain.types.Game = {
  name: "Game" as const,
  displayName: "Game",
  type: "object",
  props: {
    blackId: {
      name: "blackId",
      displayName: "Black Id",
      type: "string",
      role: "value",
    },
    whiteId: {
      name: "whiteId",
      displayName: "White Id",
      type: "string",
      role: "value",
    },
    outcome: {
      name: "outcome",
      displayName: "Outcome",
      type: "enum",
      get typeDef() { return OutcomeType },
      role: "value",
    },
  },
}
export const PlayerPair = domain.types.PlayerPair = {
  name: "PlayerPair" as const,
  displayName: "Player Pair",
  type: "object",
  props: {
    black: {
      name: "black",
      displayName: "Black",
      type: "model",
      get typeDef() { return (domain.types.Player as ModelType & { name: "Player" }) },
      role: "value",
      dontSerialize: true,
    },
    white: {
      name: "white",
      displayName: "White",
      type: "model",
      get typeDef() { return (domain.types.Player as ModelType & { name: "Player" }) },
      role: "value",
      dontSerialize: true,
    },
    outcome: {
      name: "outcome",
      displayName: "Outcome",
      type: "enum",
      get typeDef() { return OutcomeType },
      role: "value",
    },
  },
}
export const UserInfo = domain.types.UserInfo = {
  name: "UserInfo" as const,
  displayName: "User Info",
  type: "object",
  props: {
    id: {
      name: "id",
      displayName: "Id",
      type: "string",
      role: "value",
    },
    userName: {
      name: "userName",
      displayName: "User Name",
      type: "string",
      role: "value",
    },
  },
}
export const SecurityService = domain.services.SecurityService = {
  name: "SecurityService",
  displayName: "Security Service",
  type: "service",
  controllerRoute: "SecurityService",
  methods: {
    whoAmI: {
      name: "whoAmI",
      displayName: "Who AmI",
      transportType: "item",
      httpMethod: "GET",
      params: {
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "object",
        get typeDef() { return (domain.types.UserInfo as ObjectType & { name: "UserInfo" }) },
        role: "value",
      },
    },
  },
}
export const TournamentService = domain.services.TournamentService = {
  name: "TournamentService",
  displayName: "Tournament Service",
  type: "service",
  controllerRoute: "TournamentService",
  methods: {
    getPlayerPairs: {
      name: "getPlayerPairs",
      displayName: "Get Player Pairs",
      transportType: "item",
      httpMethod: "POST",
      params: {
        thisTournamentId: {
          name: "thisTournamentId",
          displayName: "This Tournament Id",
          type: "string",
          role: "value",
          rules: {
            required: val => (val != null && val !== '') || "This Tournament Id is required.",
          }
        },
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "collection",
        itemType: {
          name: "$collectionItem",
          displayName: "",
          role: "value",
          type: "object",
          get typeDef() { return (domain.types.PlayerPair as ObjectType & { name: "PlayerPair" }) },
        },
        role: "value",
      },
    },
    updatePlayers: {
      name: "updatePlayers",
      displayName: "Update Players",
      transportType: "item",
      httpMethod: "POST",
      params: {
        games: {
          name: "games",
          displayName: "Games",
          type: "collection",
          itemType: {
            name: "$collectionItem",
            displayName: "",
            role: "value",
            type: "object",
            get typeDef() { return (domain.types.Game as ObjectType & { name: "Game" }) },
          },
          role: "value",
          rules: {
            required: val => val != null || "Games is required.",
          }
        },
        tournamentId: {
          name: "tournamentId",
          displayName: "Tournament Id",
          type: "string",
          role: "value",
          rules: {
            required: val => (val != null && val !== '') || "Tournament Id is required.",
          }
        },
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "void",
        role: "value",
      },
    },
  },
}

interface AppDomain extends Domain {
  enums: {
    OutcomeType: typeof OutcomeType
    Type: typeof Type
  }
  types: {
    Game: typeof Game
    Player: typeof Player
    PlayerPair: typeof PlayerPair
    Tournament: typeof Tournament
    UserInfo: typeof UserInfo
  }
  services: {
    SecurityService: typeof SecurityService
    TournamentService: typeof TournamentService
  }
}

solidify(domain)

export default domain as unknown as AppDomain
