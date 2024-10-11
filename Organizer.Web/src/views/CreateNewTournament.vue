<template>
  <v-container style="width: 50%; float: left" class="ml-4">
    <h1>Create New Tournament</h1>
    <v-col>
      <v-form ref="form">
        <v-text-field
          v-model="tournament.name"
          for="name"
          class="mt-2"
          label="Tournament Name"
        ></v-text-field>
        <v-text-field
          v-model="tournament.dateTime"
          for="dateTime"
          type="datetime-local"
          class="mt-2"
          label="Date and Time"
        ></v-text-field>
        <v-select
          v-model="tournament.type"
          for="type"
          item-title="displayName"
          :items="Types.values"
          class="mt-2"
          label="Type"
        ></v-select>
        <v-btn @click="createTournament()">Create</v-btn>
      </v-form>
      <div class="mt-2 mx-2" style="height: 20px">
        <span v-if="errors.name" style="color: red; margin-right: 5px">
          {{ errors.name + ". " }}
        </span>
        <span v-if="errors.dateTime" style="color: red">
          {{ errors.dateTime + ". " }}
        </span>
        <span v-if="errors.type" style="color: red">
          {{ errors.type + ". " }}
        </span>
        <span v-if="addedSucessfully" style="color: green">
          Added sucessfully.
        </span>
      </div>
    </v-col>
  </v-container>
</template>

<script setup lang="ts">
import { TournamentViewModel } from "@/viewmodels.g";
import { Type as Types } from "@/metadata.g";

const tournament = new TournamentViewModel();
const errors = ref({
  name: "",
  dateTime: "",
  type: "",
});
const addedSucessfully = ref(false);

async function createTournament() {
  errors.value.name = "";
  errors.value.dateTime = "";
  errors.value.type = "";
  if (!tournament.name) {
    errors.value.name = "Name is required";
  }
  if (!tournament.dateTime) {
    errors.value.dateTime = "Date and Time are required";
  }
  if (tournament.type === null) {
    errors.value.type = "Type is required";
  }
  if (
    errors.value.name === "" &&
    errors.value.dateTime === "" &&
    errors.value.type === ""
  ) {
    await tournament.$save();
    tournament.name = "";
    tournament.dateTime = null;
    tournament.type = null;
    addedSucessfully.value = true;
    setTimeout(() => {
      addedSucessfully.value = false;
    }, 5000);
  } else {
    addedSucessfully.value = false;
    setTimeout(() => {
      errors.value.name = "";
      errors.value.dateTime = "";
      errors.value.type = "";
    }, 5000);
  }
}
</script>
