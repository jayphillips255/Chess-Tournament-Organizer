<template>
  <v-container style="width: 50%; float: left" class="ml-4">
    <h1>Create a New Tournament</h1>
    <v-col>
      <v-form ref="form">
        <c-input
          :model="tournament"
          id="tname"
          for="name"
          class="mt-2"
          label="Tournament Name"
          clearable
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

const tournament = new TournamentViewModel();
const errors = ref({
  name: "",
  dateTime: "",
  type: "",
});
var addedSucessfully = false;

function createTournament() {
  errors.value.name = "";
  errors.value.dateTime = "";
  errors.value.type = "";

  if (!tournament.name) {
    errors.value.name = "Name is required";
  }
  if (tournament.dateTime == null) {
    errors.value.dateTime = "Date and Time are required";
  }
  if (tournament.type == null) {
    errors.value.type = "Type is required";
  }
  if (
    errors.value.name === "" &&
    errors.value.dateTime === "" &&
    errors.value.type === ""
  ) {
    tournament.$save();
    addedSucessfully = true;
  } else {
    addedSucessfully = false;
  }
}
</script>
