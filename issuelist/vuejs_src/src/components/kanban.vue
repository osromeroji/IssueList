<template>
    <div class="mainDiv">
        <div class="divcards">
            <card v-if="task.severity" :color="cardColor" :class="colorFondo">{{task.severity}}</card><br />
            <card>{{ asigneeName }}</card>
        </div>

        <div class="divtitulo">
            <h1 class="firstP">{{task.title}}</h1>
            <h3>{{ task.description }}</h3>
        </div>
    </div>
</template>
<script>
import card from './card.vue'
export default {
  components: {
    card
  },
  props: {
    task: {
      type: Object,
      default: () => ({})
      },
    colorFondo: String,
    asigneeName: String
  },
  computed: {
    cardColor() {
      const mappings = {
          "High": "red",
          "Medium": "yellow",
          "Low": "green",
          default: "teal"
      };
      return mappings[this.task.severity] || mappings.default;
    }
  }
};
</script>
<style scoped>
    .mainDiv {
        box-shadow: 0 0 5px 5px #666;
        border-color: white;
        border-style: solid;
        border-width: 0.2px;
        padding: -1;
        /*padding-bottom: 5px;
        padding-top: 3px;*/
        /*padding-left: 0.75rem;*/
        /*padding-right: 0.75rem;*/
        background-color: gray;
        width: 350px;
        border-radius: 5px;
    }

    .secondDiv {
        justify-content: center;
        
    }

    .thirdDiv {
        display: flex;
        align-items: center;
        justify-content: center;
        /*margin-top: 1rem;*/
        background-color: black;
    }

    .firstP, h3 {
        font-size: 0.875rem;
        /*line-height: 1.25rem;*/
        letter-spacing: 0.025em;
        font-weight: 600;
    }

    .firstImage {
        width: 1.5rem;
        height: 1.5rem;
        margin-left: 0.75rem;
        border-radius: 9999px;
    }

    .firstSpan {
        color: rgba(75, 85, 99);
        font-size: 0.875rem;
        /*line-height: 1.25rem;*/
    }
    .red {
        background-color: red;
        width: inherit;
        /*margin-top: 10px;*/
        height: 50px;
    }

    .green {
        background-color: green;
        width: inherit;
        /*margin-top: 10px;*/
        height: 50px;
    }

    .yellow {
        background-color: yellow;
        width: inherit;
       /* margin-top: 5px;*/
        height: 50px;
    }
    .card {
        float: right;
        margin: 2px;
        background-color: white;
    }
    .divtitulo {
        float: left;
    }
    .divcards {
        float: right;
    }

</style>
