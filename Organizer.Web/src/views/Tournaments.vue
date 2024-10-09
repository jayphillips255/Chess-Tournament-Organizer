<template>
  <v-container>
    <h1>Tournaments</h1>
    <v-card
      v-for="tournament in tournaments.$items"
      :key="tournament.$stableId"
      class="mt-2"
    >
      <v-card-title>{{ tournament.name }}</v-card-title>
      <v-card-text
        >Number of Players: {{ tournament.players.length }}</v-card-text
      >
      <v-btn
        @click="conductTournament(tournament)"
        class="mb-2 ml-2"
        color="grey-darken-1"
        >Conduct Tournament</v-btn
      >
    </v-card>
    <v-btn @click="createNewTournament()" class="mt-2" append-icon="$plus"
      >Create New Tournament
    </v-btn>
  </v-container>
</template>

<script setup lang="ts">
import { TournamentListViewModel, TournamentViewModel } from "@/viewmodels.g";

const router = useRouter();

const tournaments = new TournamentListViewModel();
tournaments.$load();

function createNewTournament() {
  router.push({ name: "createNewTournament" });
}

function conductTournament(tournament: TournamentViewModel) {
  router.push({
    name: "conductTournament",
    params: { id: tournament.tournamentId },
  });
}
</script>
