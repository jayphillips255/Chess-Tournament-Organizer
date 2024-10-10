<template>
  <v-container>
    <h1>Conduct Tournament</h1>
    <v-row>
      <v-col style="width: 50%">
        <v-card>
          <h2 class="my-2 mx-2">Add Player</h2>
          <c-input
            :model="player"
            ref="firstName"
            label="First Name"
            for="firstName"
            class="mt-2 mx-2"
          ></c-input>
          <c-input
            :model="player"
            label="Last Name"
            for="lastName"
            class="mx-2"
          ></c-input>
          <c-input
            :model="player"
            label="Rating"
            for="rating"
            class="mx-2"
          ></c-input>
          <div>
            <v-btn
              @click="addPlayer()"
              color="grey-darken-1"
              append-icon="$plus"
              class="mx-2"
              >Add Player</v-btn
            >
            <div class="mt-2 mx-2" style="height: 20px">
              <span
                v-if="errors.firstName"
                style="color: red; margin-right: 5px"
              >
                {{ errors.firstName + ". " }}
              </span>
              <span v-if="errors.lastName" style="color: red">
                {{ errors.lastName + ". " }}
              </span>
              <span v-if="errors.rating" style="color: red">
                {{ errors.rating + ". " }}
              </span>
              <span v-if="addedSucessfully" style="color: green">
                Added sucessfully.
              </span>
            </div>
          </div>
          <h2 class="mt-4 mx-2">Standing:</h2>
          <v-table>
            <thead>
              <tr>
                <th>Rank</th>
                <th>Name</th>
                <th>Score</th>
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="(player, index) in tournament.players.sort(
                  (a, b) => (b.score ?? 0) - (a.score ?? 0),
                )"
                :key="player.$stableId"
              >
                <td style="width: 50px; text-align: center">
                  <span v-if="index === 0" style="font-size: 24px">🥇</span>
                  <span v-else-if="index === 1" style="font-size: 24px"
                    >🥈</span
                  >
                  <span v-else-if="index === 2" style="font-size: 24px"
                    >🥉</span
                  >
                </td>
                <td>{{ player.firstName + " " + player.lastName }}</td>
                <td>{{ player.score }}</td>
              </tr>
            </tbody>
          </v-table>
        </v-card>
      </v-col>
      <v-col style="width: 50%">
        <v-card>
          <h2 class="mt-2 mx-2">Pairings</h2>
          <h3 class="mt-2 mx-2">Round {{ tournament.currentRound }}</h3>
          <v-btn @click="autoPair()" class="my-2 mx-2" color="grey-darken-1">
            Auto Pair
          </v-btn>
          <v-btn
            @click="completeRound()"
            :disabled="!allOutcomesSelected"
            class="my-2 mx-2"
            color="grey-darken-1"
            >Complete Round</v-btn
          >
          <v-table>
            <thead>
              <tr>
                <th>Board</th>
                <th>Black</th>
                <th>White</th>
                <th>Result</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(pair, index) in playerPairs" :key="index">
                <td>{{ index + 1 }}</td>
                <td>{{ pair.black?.firstName }} {{ pair.black?.lastName }}</td>
                <td>{{ pair.white?.firstName }} {{ pair.white?.lastName }}</td>
                <td class="select-outcome">
                  <v-select
                    v-if="pair.white != null"
                    class="select-cell-height"
                    v-model="pair.outcome"
                    :items="OutcomeType.values"
                    item-title="displayName"
                  >
                  </v-select>
                </td>
              </tr>
            </tbody>
          </v-table>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { useRoute } from "vue-router";
import {
  PlayerViewModel,
  TournamentServiceViewModel,
  TournamentViewModel,
} from "@/viewmodels.g";
import { PlayerPair } from "@/models.g";
import { OutcomeType } from "@/metadata.g";
import { Game } from "@/models.g";

const route = useRoute();
const itemId = String(route.params.id);
const player = new PlayerViewModel();
const tournament = new TournamentViewModel();
const tournamentService = new TournamentServiceViewModel();
const playerPairs = ref<PlayerPair[]>([]);
const gameList: Game[] = [];

const errors = ref({
  firstName: "",
  lastName: "",
  rating: "",
});
var addedSucessfully = false;
tournament.$load(itemId);
tournament.$useAutoSave({ deep: true });

const allOutcomesSelected = computed(() => {
  if (playerPairs.value.length === 0) {
    return false;
  }
  return playerPairs.value.every(
    (pair) => pair.outcome !== null && pair.outcome !== undefined,
  );
});

function addPlayer() {
  errors.value.firstName = "";
  errors.value.lastName = "";
  errors.value.rating = "";
  if (!player.firstName) {
    errors.value.firstName = "First Name is required";
  }
  if (!player.lastName) {
    errors.value.lastName = "Last Name is required";
  }
  if (isNaN(Number(player.rating)) || Number(player.rating) < 0) {
    errors.value.rating = "Rating must be valid or empty";
  }
  if (
    !(errors.value.firstName || errors.value.lastName || errors.value.rating)
  ) {
    tournament.addToPlayers(player);
    tournament.$bulkSave();
    addedSucessfully = true;
    player.firstName = player.lastName = player.rating = "";
  } else {
    addedSucessfully = false;
  }
}

async function autoPair() {
  playerPairs.value = await tournamentService.getPlayerPairs(
    tournament.tournamentId,
  );
}

async function completeRound() {
  for (const pair of playerPairs.value) {
    gameList.push({
      blackId: pair.black?.playerId,
      whiteId: pair.white?.playerId,
      outcome: pair.outcome,
    } as Game);
  }
  await tournamentService.updatePlayers(gameList, tournament.tournamentId);
  playerPairs.value = [];
  tournament.$load(itemId);
}
</script>

<style scoped>
.select-cell-height {
  height: 40px;
}

.select-outcome {
  display: flex;
  align-items: center;
  width: 200px;
}
</style>
