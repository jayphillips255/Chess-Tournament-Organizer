<template>
  <v-container style="width: 50%; float: left" class="ml-4">
    <h1>Create a New Tournament</h1>
    <v-col>
      <v-form ref="form" v-model="isFormValid">
        <c-input
          :model="tournament"
          id="tname"
          for="name"
          class="mt-2"
          label="Tournament Name"
          required
        ></c-input>
        <c-input
          :model="tournament"
          id="tdate"
          for="dateTime"
          class="mt-2"
          label="Date and Time"
        ></c-input>
        <c-input
          :model="tournament"
          id="ttype"
          for="type"
          class="mt-2"
          label="Type"
        ></c-input>
        <v-btn @click="createTournament()">Create</v-btn>
      </v-form>
    </v-col>
  </v-container>
</template>

<script setup lang="ts">
import { TournamentViewModel } from "@/viewmodels.g";

const tournament = new TournamentViewModel();

const isFormValid = ref(false);

function createTournament() {
  tournament.$save;
}
</script>
